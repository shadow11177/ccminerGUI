using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;

namespace ccmierGUI
{
    class poolP2Pool : pool
    {
        int APIError = 0;
        Timer Tick = new Timer();

        string walletFTC = "";

        WebClient poolAPI = new WebClient();
        Uri APIAdress;

        public poolP2Pool()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            string _conf_p2pool = "http://" + settings["PoolAddress"].Value;
            poolAPI.DownloadStringCompleted += _API_p2poolCall;
            APIAdress = new Uri(_conf_p2pool + "/local_stats");

            walletFTC = settings["FeathercoinWalletAddress"].Value;

            Tick.Interval = 60000;
            Tick.Tick += Tick_Tick;
            Tick.Start();
        }

        public new void Stop()
        {
            if(poolAPI.IsBusy)
            {
                poolAPI.CancelAsync();
            }
            Tick.Stop();
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            if (!poolAPI.IsBusy)
            {
                poolAPI.DownloadStringAsync(APIAdress);
            }
        }

        private void _API_p2poolCall(object sender, DownloadStringCompletedEventArgs e)
        {
            if (APIError < 5)
            {
                try
                {
                    string JSon = e.Result;
                    if (JSon.ToLower().Contains(walletFTC.ToLower()))
                    {
                        JSon = JSon.Replace("\"", "");
                        if (JSon.IndexOf(walletFTC) > 0)
                        {
                            JSon = JSon.Substring(JSon.IndexOf("miner_hash_rates"));
                            JSon = JSon.Remove(JSon.IndexOf("}"));
                            JSon = JSon.Substring(JSon.IndexOf("{"));
                            string[] parts = JSon.Split(',');
                            string hashrate = "";
                            foreach (string part in parts)
                            {
                                if (part.Contains(walletFTC))
                                {
                                    hashrate = part.Split(':')[1];
                                }
                            }
                            if (hashrate != "")
                            {
                                string rate = hashrate.Replace('.', ',');
                                rate = (Convert.ToInt32(rate.Split(',')[0]) / 1000).ToString();
                                PoolEvent(DateTime.Now.ToOADate(), rate);
                            }
                        }
                        APIError = 0;
                    }
                    else
                    {
                        APIError++;
                    }
                }
                catch
                {
                    APIError++;
                }
            }
            else if (APIError == 5)
            {
                APIError++;
                if (MessageBox.Show("P2Pool API Request failed! Please check your configuration." + Environment.NewLine + "If the error stays please report to the Developer.", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    APIError = 0;
                }
                else
                {
                    Tick.Stop();
                }
            }
        }
    }
}
