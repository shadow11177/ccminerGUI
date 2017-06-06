using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Forms.DataVisualization.Charting;

namespace ccmierGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string _conf_coinotronAPI = "";
        string _conf_coinotronWRK = "";
        string _conf_walletFTC = "";
        string _conf_currency = "";
        string _conf_p2pool = "";
        WebClient poolAPI = new WebClient();
        Uri APIAdress;

        private void frmMain_Load(object sender, EventArgs e)
        {
            //coinotronAPI = ;
            string[] config = ConfigurationManager.AppSettings.AllKeys;

            foreach(string key in config)
            {
                switch( key)
                {
                    case "CoinotronAPI":
                        _conf_coinotronAPI = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "CoinotronWorker":
                        _conf_coinotronWRK = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "Currency":
                        _conf_currency = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "FeathercoinWalletAddress":
                        _conf_walletFTC = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "ccminerArgs":
                        txtCMD.Text = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "p2poolAddress":
                        _conf_p2pool = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                }
            }

            bool haspool = false;
            if (_conf_coinotronAPI != "" && _conf_coinotronWRK != "")
            {
                haspool = true;
                poolAPI.DownloadStringCompleted += _API_coinotronCall;
                APIAdress = new Uri("https://www.coinotron.com/app?action=api&api_key=" + _conf_coinotronAPI);
            }
            else if (_conf_p2pool != "" && _conf_walletFTC != "")
            {
                haspool = true;
                poolAPI.DownloadStringCompleted += _API_p2poolCall;
                APIAdress = new Uri(_conf_p2pool + "/local_stats");
            }

            if (!haspool)
            {
                chaHash.Series.RemoveAt(1);
            }

            chaStat.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(DateTime.Now.ToOADate(), 0));
            chaStat.Series[1].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(DateTime.Now.ToOADate(), 0));
            chaStat.Series[2].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(DateTime.Now.ToOADate(), 0));
        }

        Process ccminer;

        bool restart = false;
        int restarts = 0;

        int minute = 0;
        int mhits = 0;
        int merror = 0;
        int mstall = 0;

        int lastacc = 0;

        int allerror = 0;
        int allstall = 0;

        List<int> acc5m = new List<int>();
        Dictionary<int, string[]> GPUs = new Dictionary<int, string[]>();

        DateTime lastupdate;

        bool running = false;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(running)
            {
                running = false;
                btnStart.Text = "Start";
                ccminer.OutputDataReceived -= Ccminer_OutputDataReceived;
                ccminer.ErrorDataReceived -= Ccminer_ErrorDataReceived;
                ccminer.CancelErrorRead();
                ccminer.CancelOutputRead();
                ccminer.Kill();
            }
            else
            {
                lastupdate = DateTime.Now;
                tmrFeatherStat_Tick(null, null);
                tmrFeatherStat.Enabled = true;
                running = true;
                btnStart.Text = "Stop";
                minute = DateTime.Now.Minute;
                ccminer = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ccminer.exe",
                        Arguments = txtCMD.Text,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                ccminer.OutputDataReceived += Ccminer_OutputDataReceived;
                ccminer.ErrorDataReceived += Ccminer_ErrorDataReceived;
                ccminer.Start();
                ccminer.BeginOutputReadLine();
                ccminer.BeginErrorReadLine();
                tmrProbe.Enabled = true;
                tmrChart.Enabled = true;
            }
            
        }

        DateTime hashtime;

        private void Ccminer_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.Contains("GPU #") && !e.Data.Contains("does not validate on CPU!")) //[2017-06-06 17:37:36] GPU #0: GeForce GTX 970, 246[0m
                {
                    string num = e.Data.Substring(e.Data.IndexOf('#') + 1);
                    string gpuname = num.Substring(num.IndexOf(':') + 2);
                    gpuname = gpuname.Remove(gpuname.IndexOf(','));
                    num = num.Remove(num.IndexOf(':'));
                    //int numgpu = e.Data

                    

                    int pos = e.Data.LastIndexOf('\u001b');
                    string hashrate = e.Data.Substring(47, pos - 47);
                    long rate = Convert.ToInt64(hashrate);
                    lastupdate = DateTime.Now;
                    if (rate <= 50)
                    {
                        restart = true;
                    }
                    else
                    {
                        int numgpu = Convert.ToInt32(num);
                        if (!GPUs.ContainsKey(numgpu))
                        {
                            string[] newGPU = { hashrate, gpuname , ""};
                            GPUs.Add(numgpu, newGPU);
                        }
                        else
                        {
                            GPUs[numgpu][0] = ((Convert.ToInt32(GPUs[numgpu][0]) + (int)rate) / 2).ToString();
                        }
                    }
                    lblBHash.Invoke(
                        new Action(() =>
                        {
                            int allhash = 0;
                            foreach(int gpuid in GPUs.Keys)
                            {
                                allhash = allhash + Convert.ToInt32(GPUs[gpuid][0]);
                            }
                            lblBHash.Text = "B. Hashrate:" + allhash.ToString();
                        }));
                }
                else if (e.Data.Contains("Stratum difficulty"))
                {
                    int pos = e.Data.LastIndexOf('\u001b');
                    string difficulty = e.Data.Substring(53, pos - 53);
                    lblDifficulty.Invoke(
                        new Action(() =>
                        {
                            lblDifficulty.Text = "Difficulty:" + difficulty;
                        }));

                }
                else if (e.Data.Contains("does not validate on CPU!"))
                {
                    merror++;
                    allerror++;
                    lblError.Invoke(
                    new Action(() =>
                    {
                        lblError.Text = "Error:" + allerror.ToString();
                    }));
                }
                else if (e.Data.Contains("neoscrypt block"))
                {
                    int pos = e.Data.LastIndexOf('\u001b');
                    string block = e.Data.Substring(62, pos - 62);
                    lblBlock.Invoke(
                        new Action(() =>
                        {
                            lblBlock.Text = "Block:" + block;
                        }));

                }
                else if (e.Data.Contains("accepted: "))
                {
                    int pos = e.Data.LastIndexOf(':');
                    int spos = e.Data.LastIndexOf(')');
                    string rate = e.Data.Substring(pos+2, spos - (pos+1));
                    int acc = Convert.ToInt32(rate.Split('/')[0]);
                    if(acc != lastacc)
                    {
                        lastacc = acc;
                        mhits++;
                    }
                    else
                    {
                        allstall++;
                        lblStale.Invoke(
                        new Action(() =>
                        {
                            lblStale.Text = "Stale:" + allstall.ToString();
                        }));
                        mstall++;
                    }
                    lblAccepted.Invoke(
                        new Action(() =>
                        {
                            lblAccepted.Text = "Accepted:" + rate + " - " + e.Data.Substring(1, 19);
                        }));

                }
                else
                {
                    lstLog.Invoke(new Action(() =>
                    {
                        lstLog.Items.Add(e.Data);
                    }));
                }
            }
        }

        private void Ccminer_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(e.Data != null)
            {
                lstLog.Invoke(new Action(() =>
                {
                    lstLog.Items.Add(e.Data);
                }));
            }
        }

        private void tmrProbe_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ccminer.HasExited)
                {
                    lblStat.Text = "Offline";
                    tmrProbe.Enabled = false;
                    makeRestart(); 
                }
                else
                {
                    lblStat.Text = "Online";
                }
            }
            catch
            {
                lblStat.Text = "Offline";
            }
            
            int diff = lastupdate.AddMinutes(5).CompareTo(DateTime.Now);

            DateTime show = DateTime.Now;
            TimeSpan shows = show.Subtract(lastupdate);
            

            this.Text = "ccminerGUI - " + shows.ToString(@"mm\:ss");

            if (diff < 0)
            {
                restart = true;
            }

            if (restart)
            {
                restart = false;
                tmrProbe.Enabled = false;
                lblStat.Text = "Offline";
                makeRestart();
                restarts++;
                lblRestart.Text = "Restarts:" + restarts;
            }

        }

        private void makeRestart()
        {
            ccminer.OutputDataReceived -= Ccminer_OutputDataReceived;
            ccminer.ErrorDataReceived -= Ccminer_ErrorDataReceived;
            ccminer.CancelErrorRead();
            ccminer.CancelOutputRead();
            ccminer.Kill();

            ccminer = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ccminer.exe",
                    Arguments = txtCMD.Text,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            ccminer.OutputDataReceived += Ccminer_OutputDataReceived;
            ccminer.ErrorDataReceived += Ccminer_ErrorDataReceived;
            ccminer.Start();
            ccminer.BeginOutputReadLine();
            ccminer.BeginErrorReadLine();
            tmrProbe.Enabled = true;
        }

        private void tmrChart_Tick(object sender, EventArgs e)
        {
            if (minute != DateTime.Now.Minute)
            {
                DateTime tme = DateTime.Now;
                tme = tme.AddSeconds(tme.Second * -1);
                DateTime scroll = tme.AddHours(-1);

                foreach(int GPUID in GPUs.Keys)
                {
                    if(GPUs[GPUID][2] == "")
                    {
                        Series newgpu = new Series("(" +GPUID.ToString() + ") " + GPUs[GPUID][1]);
                        newgpu.BorderWidth = 3;
                        newgpu.ChartType = SeriesChartType.Spline;
                        GPUs[GPUID][2] = chaHash.Series.Count.ToString();
                        chaHash.Series.Add(newgpu);
                    }
                    int gpuchart = Convert.ToInt32(GPUs[GPUID][2]);
                    chaHash.Series[gpuchart].Points.Add(new DataPoint(tme.ToOADate(), GPUs[GPUID][0]));

                }

                chaHash.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();
                acc5m.Add(mhits);
                while(acc5m.Count >= 6)
                {
                    acc5m.RemoveAt(0);
                }
                double avg = 0;
                for(int i =0; i< acc5m.Count;i++)
                {
                    avg += acc5m[i];
                }
                avg = avg / acc5m.Count;
                chaStat.Series[3].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(tme.ToOADate(), avg));

                if (mhits > 0)
                {
                    chaStat.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(tme.ToOADate(), mhits));
                    mhits = 0;
                }
                if (merror > 0)
                {
                    chaStat.Series[2].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(tme.ToOADate(), merror));
                    merror = 0;
                }
                if (mstall > 0)
                {
                    chaStat.Series[1].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(tme.ToOADate(), mstall));
                    mstall = 0;
                }

                hashtime = tme;
                poolAPI.DownloadStringAsync(APIAdress);

                DateTime max = tme.AddMinutes(1);
                chaStat.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();
                chaStat.ChartAreas[0].AxisX.Maximum = max.ToOADate();
                minute = tme.Minute;
            }

            if (chaHash.Series[0].Points.Count > 60)
            {
                chaHash.Series[0].Points.RemoveAt(0);
            }
            if (chaStat.Series[0].Points.Count > 60)
            {
                chaStat.Series[0].Points.RemoveAt(0);
            }
            if (chaStat.Series[1].Points.Count > 60)
            {
                chaStat.Series[1].Points.RemoveAt(0);
            }
            if (chaStat.Series[2].Points.Count > 60)
            {
                chaStat.Series[2].Points.RemoveAt(0);
            }
        }

        bool APIError = false;

        private void _API_coinotronCall(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!APIError)
                {
                    string JSon = e.Result;
                    JSon = JSon.Replace("\"", "");
                    JSon = JSon.Substring(JSon.IndexOf(_conf_coinotronWRK));
                    JSon = JSon.Remove(JSon.IndexOf("}"));
                    string[] parts = JSon.Split(',');
                    string hashrate = "";
                    foreach (string part in parts)
                    {
                        if (part.Contains("hash"))
                        {
                            hashrate = part.Split(':')[1];
                        }
                    }

                    if (hashrate != "")
                    {
                        lblNHash.Text = "N. Hashrate:" + hashrate;
                        chaHash.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(hashtime.ToOADate(), hashrate));
                    }
                }
            }
            catch
            {
                APIError = true;
                MessageBox.Show("Coinotron API Request failed! Please check your configuration." + Environment.NewLine + "If the error stays please report to the Developer.");
            }
        }

        private void _API_p2poolCall(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!APIError)
                {
                    string JSon = e.Result;
                    JSon = JSon.Replace("\"", "");
                    if (JSon.IndexOf(_conf_walletFTC) > 0)
                    {
                        JSon = JSon.Substring(JSon.IndexOf(_conf_walletFTC));
                        JSon = JSon.Remove(JSon.IndexOf("}"));
                        string[] parts = JSon.Split(',');
                        string hashrate = "";
                        foreach (string part in parts)
                        {
                            if (part.Contains(_conf_walletFTC))
                            {
                                hashrate = part.Split(':')[1];
                            }
                        }
                        if (hashrate != "")
                        {
                            double rate = Convert.ToDouble(hashrate.Replace('.', ','));
                            rate = rate / 1000;
                            lblNHash.Text = "N. Hashrate:" + rate.ToString("N2");
                            chaHash.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(hashtime.ToOADate(), rate));
                        }
                    }
                }
            }
            catch
            {

                APIError = true;
                MessageBox.Show("P2Pool API Request failed! Please check your configuration." + Environment.NewLine + "If the error stays please report to the Developer.");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ccminer.Kill();
            }
            catch
            { }
        }

        private void tmrFeatherStat_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime tme = DateTime.Now;
                tme = tme.AddSeconds(tme.Second * -1);
                DateTime scroll = tme.AddDays(-1);

                WebClient clnt = new WebClient();
                string worth = clnt.DownloadString("http://api.feathercoin.com/?output=" + _conf_currency + "&amount=1&json=0");
                string amount = clnt.DownloadString("http://api.feathercoin.com/?output=balance&address=" + _conf_walletFTC + "&json=0");
                double value = Convert.ToDouble(worth.Replace('.',','));

                lblBalance.Text = "Balance:" + amount;
                lblWorth.Text = "FTC -> " + _conf_currency.ToUpper() + ":" + worth;
                lblValue.Text = "Value:" + (Convert.ToDouble(amount.Replace('.', ',')) * Convert.ToDouble(worth.Replace('.', ','))).ToString();

                if(value > 0)
                {
                    chaFTC.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(tme.ToOADate(), value));
                }

                chaFTC.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();

                if (chaFTC.Series[0].Points.Count > 8640)
                {
                    chaFTC.Series[0].Points.RemoveAt(0);
                }
            }
            catch { }
        }
    }
}
