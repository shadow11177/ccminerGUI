using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;

namespace ccmierGUI
{
    class poolCoinotron : pool
    {
        int APIError = 0;
        Timer Tick = new Timer();

        WebClient poolAPI = new WebClient();
        Uri APIAdress;

        string Worker = "";

        public poolCoinotron()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            string _conf_coinotronAPI = settings["CoinotronAPI"].Value;
            Worker = settings["Worker"].Value;
            poolAPI.DownloadStringCompleted += _API_coinotronCall;
            APIAdress = new Uri("https://www.coinotron.com/app?action=api&api_key=" + _conf_coinotronAPI);
            Tick.Interval = 10000;
            Tick.Tick += Tick_Tick;
            Tick.Start();
            poolAPI.DownloadStringAsync(APIAdress);
        }

        public new void Stop()
        {
            if (poolAPI.IsBusy)
            {
                poolAPI.CancelAsync();
            }
            Tick.Stop();
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            if(!poolAPI.IsBusy)
            {
                poolAPI.DownloadStringAsync(APIAdress);
            }
        }

        private void _API_coinotronCall(object sender, DownloadStringCompletedEventArgs e)
        {

            if (APIError < 5)
            {
                try
                {
                    string JSon = e.Result;
                    if (JSon.ToLower().Contains(Worker.ToLower()))
                    {
                        JSon = JSon.Replace("\"", "");
                        JSon = JSon.Substring(JSon.ToLower().IndexOf(Worker.ToLower()));
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
                            PoolEvent(DateTime.Now.ToOADate(), hashrate);
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
                if (MessageBox.Show("Coinotron API Request failed! Please check your configuration." + Environment.NewLine + "If the error stays please report to the Developer.", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
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
