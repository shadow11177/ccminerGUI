using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ccmierGUI
{
    class minerRPC : miner
    {
        Process miner = new Process();
        System.Windows.Forms.Timer Report = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer Initialise = new System.Windows.Forms.Timer(); //for getting the GPUS
        string path = "";

        minerReport mr = new minerReport();

        public minerRPC()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            path = settings["Path"].Value;
            string intensity = settings["Intensity"].Value;
            string PoolAddress = settings["PoolAddress"].Value;
            string worker = settings["Worker"].Value;
            string pass = settings["Pass"].Value;

            mr.block = "NA";

            mr.cmd = "--neoscrypt -I " + intensity + " -o stratum+tcp://" + PoolAddress + " --api-listen -u " + worker + " -p " + pass;

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
            Initialise.Interval = 10000;
            Initialise.Start();
            Initialise.Tick += getGPUS;
        }

        public new void Stop()
        {
            try
            {
                Initialise.Stop();
                Report.Stop();
                miner.Kill();
            }
            catch { }
        }

        private void getGPUS(object sender, EventArgs e)
        {
            Initialise.Stop();
            //for initialisation
            TcpClient clnt = new TcpClient("127.0.0.1", 4028);

            NetworkStream ns = clnt.GetStream();
            byte[] cmd = Encoding.ASCII.GetBytes("devdetail");
            ns.Write(cmd, 0, cmd.Length);
            int tout = 0;
            while (!ns.DataAvailable && tout < 10)
            {
                Thread.Sleep(100);
                tout++;
            }
            if (tout < 10)
            {
                tout = 0;
                List<byte> buf = new List<byte>();
                int b = ns.ReadByte();
                while (b > -1)
                {
                    buf.Add((byte)b);
                    b = ns.ReadByte();
                }
                string[] ret = Encoding.ASCII.GetString(buf.ToArray()).Split('|');
                for (int i = 1; i < ret.Count() - 1; i++)
                {
                    string[] data = ret[1].Split(',');
                    foreach (string dat in data)
                    {
                        string[] field = dat.Split('=');
                        string Name = "";
                        if (field[0] == "Model")
                        {
                            Name = field[1];
                            string[] empGPU = { "", Name, "" };
                            mr.GPUs.Add(i - 1, empGPU);
                        }
                    }
                }
            }
        }

        private void Report_Tick(object sender, EventArgs e)
        {
            // get GPU Hashrate/s
            TcpClient clnt = new TcpClient("127.0.0.1", 4028);
            NetworkStream ns = clnt.GetStream();
            byte[] cmd = Encoding.ASCII.GetBytes("devs");
            ns.Write(cmd, 0, cmd.Length);
            int tout = 0;
            while (!ns.DataAvailable && tout < 10)
            {
                Thread.Sleep(100);
                tout++;
            }
            if (tout < 10)
            {
                tout = 0;
                List<byte> buf = new List<byte>();
                int b = ns.ReadByte();
                while (b > -1)
                {
                    buf.Add((byte)b);
                    b = ns.ReadByte();
                }
                string[] ret = Encoding.ASCII.GetString(buf.ToArray()).Split('|');
                for (int i = 1; i < ret.Count() - 1; i++)
                {
                    string[] data = ret[1].Split(',');
                    foreach (string dat in data)
                    {
                        string[] field = dat.Split('=');
                        if (field[0] == "MHS 5s")
                        {
                            double mhs = Convert.ToDouble(field[1].Replace('.', ','));
                            int hashrate = (int)(mhs * 1000);
                            mr.GPUs[i - 1][0] = hashrate.ToString();
                        }
                    }
                }
            }
            //get other stats (share, stale, error...)
            clnt = new TcpClient("127.0.0.1", 4028);

            ns = clnt.GetStream();
            cmd = Encoding.ASCII.GetBytes("summary");
            ns.Write(cmd, 0, cmd.Length);
            tout = 0;
            while (!ns.DataAvailable && tout < 10)
            {
                Thread.Sleep(100);
                tout++;
            }
            if (tout < 10)
            {
                tout = 0;
                List<byte> buf = new List<byte>();
                int b = ns.ReadByte();
                while (b > -1)
                {
                    buf.Add((byte)b);
                    b = ns.ReadByte();
                }
                string ret = Encoding.ASCII.GetString(buf.ToArray()).Split('|')[1];
                string[] data = ret.Split(',');
                foreach (string dat in data)
                {
                    string[] field = dat.Split('=');
                    if (field[0] == "Hardware Errors")
                    {
                        int allerrornew = Convert.ToInt32(field[1]);
                        mr.merror = allerrornew - mr.allerror;
                        mr.allerror = allerrornew;
                    }
                    else if (field[0] == "Difficulty Accepted")
                    {
                        mr.difficulty = field[1];
                    }
                    else if (field[0] == "MHS av")
                    {
                        double mhs = Convert.ToDouble(field[1].Replace('.', ','));
                        int hashrate = (int)(mhs * 1000);
                        mr.allhash = hashrate;
                    }
                    else if (field[0] == "Rejected")
                    {
                        int allstalenew = Convert.ToInt32(field[1]);
                        mr.mstale = allstalenew - mr.allstale;
                        mr.allstale = allstalenew;
                    }
                    else if (field[0] == "Accepted")
                    {
                        int allsharenew = Convert.ToInt32(field[1]);
                        mr.mshare = allsharenew - mr.allshare;
                        mr.allshare = allsharenew;
                    }
                }
                
            }

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
            }
        }

        private void miner_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                MinerEvent(e.Data);
            }
        }

        private void makeRestart()
        {
            miner.OutputDataReceived -= miner_OutputDataReceived;
            miner.ErrorDataReceived -= miner_ErrorDataReceived;
            miner.CancelErrorRead();
            miner.CancelOutputRead();
            miner.Kill();

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
            //tmrProbe.Enabled = true;
        }
    }
}
