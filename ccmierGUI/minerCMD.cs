using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccmierGUI
{
    class minerCMD : miner
    {
        Process miner = new Process();
        System.Windows.Forms.Timer Report = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer Watchdog = new System.Windows.Forms.Timer();
        string path = "";
        int hashtick = 0; //Counts the number of watchdog ticks betwen hashrate reports
        minerReport mr = new minerReport();

        public minerCMD()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            path = settings["Path"].Value;
            string intensity = settings["Intensity"].Value;
            string PoolAddress = settings["PoolAddress"].Value;
            string worker = settings["Worker"].Value;
            string pass = settings["Pass"].Value;
            
            mr.cmd = "-a neoscrypt -i " + intensity + " -o stratum+tcp://" + PoolAddress + " -u " + worker + " -p " + pass;

            Run();
        }

        private void Watchdog_Tick(object sender, EventArgs e)
        {
            if(hashtick >= 60)
            {
                makeRestart();
            }
            else
            {
                try
                {
                    if (miner.HasExited)
                    {
                        makeRestart();
                    }
                }
                catch
                {
                    makeRestart();
                }
            }
            hashtick++;
        }

        public new void Stop()
        {
            try
            {
                hashtick = 0;
                Report.Stop();
                Watchdog.Stop();
                miner.Kill();
            }
            catch { }
        }

        public new void Run()
        {
            miner = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = mr.cmd,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            miner.OutputDataReceived += miner_OutputDataReceived;
            miner.ErrorDataReceived += miner_ErrorDataReceived;
            miner.Start();
            miner.BeginOutputReadLine();
            miner.BeginErrorReadLine();
            Report.Interval = 60000;
            Report.Start();
            Report.Tick += Report_Tick;
            Watchdog.Interval = 5000;
            Watchdog.Start();
            Watchdog.Tick += Watchdog_Tick;
        }

        private void Report_Tick(object sender, EventArgs e)
        {
            MinerReportEvent(mr);
            mr.merror = 0;
            mr.mshare = 0;
            mr.mstale = 0;
        }

        private void miner_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                MinerEvent(e.Data);
                handleoutput(e.Data);
            }
        }

        private void miner_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                MinerEvent(e.Data);
                handleoutput(e.Data);
            }
        }

        private void handleoutput(string data)
        {
            if (data.Contains("GPU #") && !data.Contains("does not validate on CPU!") && !data.Contains("Intensity")) //[2017-06-06 17:37:36] GPU #0: GeForce GTX 970, 246[0m
            {
                string num = data.Substring(data.IndexOf('#') + 1);
                string gpuname = num.Substring(num.IndexOf(':') + 2);
                gpuname = gpuname.Remove(gpuname.IndexOf(','));
                num = num.Remove(num.IndexOf(':'));
                int pos = data.LastIndexOf('\u001b');
                if (data.Contains("."))
                {
                    pos = data.LastIndexOf('.');
                }
                int start = data.IndexOf(gpuname) + gpuname.Length + 2;
                string hashrate = data.Substring(start, pos - start);
                long rate = Convert.ToInt64(hashrate);

                if (rate <= 50) //Must be configurable !!!
                {
                    makeRestart();
                }
                else
                {
                    hashtick = 0;
                    int numgpu = Convert.ToInt32(num);
                    if (!mr.GPUs.ContainsKey(numgpu))
                    {
                        string[] newGPU = { hashrate, gpuname, "" };
                        mr.GPUs.Add(numgpu, newGPU);
                    }
                    else
                    {
                        int lasthash = Convert.ToInt32(mr.GPUs[numgpu][0]);
                        if ((int)rate < lasthash * 2)
                        {
                            mr.GPUs[numgpu][0] = ((lasthash + (int)rate) / 2).ToString();
                        }
                    }
                }

                mr.allhash = 0;
                foreach (int gpuid in mr.GPUs.Keys)
                {
                    mr.allhash = mr.allhash + Convert.ToInt32(mr.GPUs[gpuid][0]);
                }
            }
            else if (data.Contains("Stratum difficulty"))
            {
                int pos = data.LastIndexOf('\u001b');
                mr.difficulty = data.Substring(53, pos - 53);

            }
            else if (data.Contains("does not validate on CPU!"))
            {
                mr.merror++;
                mr.allerror++;
            }
            else if (data.Contains("neoscrypt block"))
            {
                int pos = data.LastIndexOf('\u001b');
                mr.block = data.Substring(data.IndexOf("neoscrypt block") + 15, pos - (data.IndexOf("neoscrypt block") + 15));

            }
            else if (data.Contains("accepted: "))
            {
                hashtick = 0;
                int pos = data.LastIndexOf(':');
                int spos = data.LastIndexOf(')');
                string rate = data.Substring(pos + 2, spos - (pos + 1));
                int acc = Convert.ToInt32(rate.Split('/')[0]);
                if (acc != mr.allshare)
                {
                    mr.allshare = acc;
                    mr.mshare++;
                }
                else
                {
                    mr.allstale++;
                    mr.mstale++;
                }
            }
        }

        private void makeRestart()
        {
            Stop();
            Thread.Sleep(100);
            mr.restarts++;
            Run();
        }
    }
}
