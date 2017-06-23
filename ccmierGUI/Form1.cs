using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace ccmierGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        pool pool;
        miner mn;
        string _conf_walletFTC = "";
        string _conf_currency = "";
        int time = 60;
        List<string> CMiners = new List<string>(); //For the List in the config window

        private void frmMain_Load(object sender, EventArgs e)
        {
            CMiners.Add("CCMiner");
            CMiners.Add("NSGMiner");
            CMiners.Add("BFGMiner");

            //Load necessarry config parameters
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            _conf_walletFTC = settings["FeathercoinWalletAddress"].Value;
            _conf_currency = settings["Currency"].Value;

            //for initialising the chart (otherwise strange artifacts show up)
            chaStat.Series[0].Points.Add(new DataPoint(DateTime.Now.ToOADate(), 0));
            chaStat.Series[1].Points.Add(new DataPoint(DateTime.Now.ToOADate(), 0));
            chaStat.Series[2].Points.Add(new DataPoint(DateTime.Now.ToOADate(), 0));
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if(mn != null)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }

        private void Start()
        {
            btnStart.Text = "Stop";
            mn = new miner();
            mn.OnMinerEvent += Mn_OnMinerEvent;
            mn.OnMinerReportEvent += Mn_OnMinerReportEvent;
            mn.Run();
            pool = new pool();
            pool.OnPoolEvent += Pool_OnPoolEvent;
            pool.Run();
            tmrInitialise.Enabled = true;
        }

        private void Stop()
        {
            btnStart.Text = "Start";
            mn.Stop();
            mn.OnMinerEvent -= Mn_OnMinerEvent;
            mn.OnMinerReportEvent -= Mn_OnMinerReportEvent;
            mn = null;

            pool.OnPoolEvent -= Pool_OnPoolEvent;
            pool = null;
        }

        private void Mn_OnMinerReportEvent(object sender, minerReportEventArgs e)
        {
            Invoke(new Action(() =>
            {
                //Fill the Labels
                lblInitialise.Visible = false;
                lblAccepted.Text = "Accepted: " + e.report.allshare.ToString();
                lblBHash.Text = "B. Hashrate: " + e.report.allhash.ToString();
                lblBlock.Text = "Block: " + e.report.block;
                lblDifficulty.Text = "Difficulty: " + e.report.difficulty;
                lblError.Text = "Error: " + e.report.allerror.ToString();
                lblStale.Text = "Stale: " + e.report.allstale.ToString();
                lblCMD.Text = e.report.cmd;

                //GPU Chart
                DateTime tme = DateTime.Now;
                foreach (int GPUID in e.report.GPUs.Keys)
                {
                    string name = "(" + GPUID.ToString() + ") " + e.report.GPUs[GPUID][1];
                    Series gpu = chaHash.Series.FindByName(name);
                    if (gpu == null)
                    {
                        gpu = new Series(name);
                        gpu.BorderWidth = 3;
                        gpu.ChartType = SeriesChartType.Spline;
                        gpu.XValueType = ChartValueType.Time;
                        chaHash.Series.Add(gpu);
                    }
                    gpu.Points.Add(new DataPoint(tme.ToOADate(), e.report.GPUs[GPUID][0]));

                }

                //Share Cahrt
                if (e.report.mshare > 0)
                {
                    chaStat.Series[0].Points.Add(new DataPoint(tme.ToOADate(), e.report.mshare));
                }
                if (e.report.merror > 0)
                {
                    chaStat.Series[2].Points.Add(new DataPoint(tme.ToOADate(), e.report.merror));
                }
                if (e.report.mstale > 0)
                {
                    chaStat.Series[1].Points.Add(new DataPoint(tme.ToOADate(), e.report.mstale));
                }
                //5 min Average
                int count = chaStat.Series[0].Points.Count;
                int start = chaStat.Series[0].Points.Count - 5;
                start = start < 0 ? 0 : start;
                double avg = 0;
                for (int i = start; i < count; i++)
                {
                    avg += chaStat.Series[0].Points[i].YValues[0];
                }
                avg = avg / (count - start);
                chaStat.Series[3].Points.Add(new DataPoint(tme.ToOADate(), avg));

                foreach (Series ser in chaHash.Series)
                {
                    while (ser.Points.Count > 60)
                    {
                        ser.Points.RemoveAt(0);
                    }
                }

                //Scroll the chart view
                DateTime scroll = tme.AddHours(-1);
                chaStat.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();
                chaStat.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

                chaHash.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();
                chaHash.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

            }));
        }

        private void Mn_OnMinerEvent(object sender, minerEventArgs e)
        {
            Invoke(new Action(() =>
            {
                lstLog.Items.Add(e.Line);
                lstLog.SelectedIndex = lstLog.Items.Count - 1;
            }));
        }
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Stop();
            }
            catch
            { }
        }
        
        private void tmrFeatherStat_Tick(object sender, EventArgs e)
        {
            //getting the current value of the Feathercoin
            if(_conf_walletFTC != "")
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
                        chaFTC.Series[0].Points.Add(new DataPoint(tme.ToOADate(), value));
                    }

                    //scroll to the last 24 hours
                    chaFTC.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();
                    chaFTC.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

                    //scale the value so the chart looks more dramatic :-)
                    DataPoint dpmin = chaFTC.Series[0].Points.FindMinByValue("Y1");
                    DataPoint dpmax = chaFTC.Series[0].Points.FindMaxByValue("Y1");

                    int min = (int)(dpmin.YValues[0] * 100) -1;
                    int max = (int)(dpmax.YValues[0] * 100) +1;

                    chaFTC.ChartAreas[0].AxisY.Minimum = (double)min / 100;
                    chaFTC.ChartAreas[0].AxisY.Maximum = (double)max / 100;
                    
                    //clean up points that arent visible in the chart (older than 24hours)
                    if (chaFTC.Series[0].Points.Count > 8640)
                    {
                        chaFTC.Series[0].Points.RemoveAt(0);
                    }
                }
                catch { }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings frsettings = new frmSettings();
            frsettings.CMiners = CMiners.ToArray();
            if(frsettings.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stop();
                }
                catch { }

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                _conf_walletFTC = settings["FeathercoinWalletAddress"].Value;
                _conf_currency = settings["Currency"].Value;
            }
        }

        private void Pool_OnPoolEvent(object sender, poolEventArgs e)
        {
            //Update the hastrate reported by the pool
            lblNHash.Text = "N.Hashrate:" + e.value;
            chaHash.Series[0].Points.Add(new DataPoint(e.time, e.value));
            if (chaHash.Series[0].Points.Count > 60)
            {
                chaHash.Series[0].Points.RemoveAt(0);
            }
        }

        private void tmrInitialise_Tick(object sender, EventArgs e)
        {
            if(time>0)
            {
                time--;
                lblInitialise.Text = time.ToString();
            }
            else
            {
                tmrInitialise.Enabled = false;
            }
        }
    }
}
