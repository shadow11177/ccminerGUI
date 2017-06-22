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
using System.Net.Sockets;
using System.Threading;

namespace ccmierGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        pool pool;
        string _conf_walletFTC = "";
        string _conf_currency = "";
        int time = 60;
        miner mn;

        List<string> CMiners = new List<string>();

        private void frmMain_Load(object sender, EventArgs e)
        {
            CMiners.Add("CCMiner");
            CMiners.Add("NSGMiner");
            CMiners.Add("BFGMiner");

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            _conf_walletFTC = settings["FeathercoinWalletAddress"].Value;
            _conf_currency = settings["Currency"].Value;

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
                lblInitialise.Visible = false;
                lblAccepted.Text = "Accepted: " + e.report.allshare.ToString();
                lblBHash.Text = "B. Hashrate: " + e.report.allhash.ToString();
                lblBlock.Text = "Block: " + e.report.block;
                lblDifficulty.Text = "Difficulty: " + e.report.difficulty;
                lblError.Text = "Error: " + e.report.allerror.ToString();
                lblStale.Text = "Stale: " + e.report.allstale.ToString();
                lblCMD.Text = e.report.cmd;

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

                    chaFTC.ChartAreas[0].AxisX.Minimum = scroll.ToOADate();
                    chaFTC.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

                    DataPoint dpmin = chaFTC.Series[0].Points.FindMinByValue("Y1");
                    DataPoint dpmax = chaFTC.Series[0].Points.FindMaxByValue("Y1");

                    int min = (int)(dpmin.YValues[0] * 100) -1;
                    int max = (int)(dpmax.YValues[0] * 100) +1;

                    chaFTC.ChartAreas[0].AxisY.Minimum = (double)min / 100;
                    chaFTC.ChartAreas[0].AxisY.Maximum = (double)max / 100;

                    //chaFTC.Series[0].Points.Max<double>();

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
