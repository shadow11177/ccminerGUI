using System;
using System.Configuration;

namespace ccmierGUI
{
    class pool
    {
        public delegate void poolEventHandler(object sender, poolEventArgs e);
        public event poolEventHandler OnPoolEvent;

        poolCoinotron CTRON;
        poolP2Pool P2P;

        public pool()
        {
        }

        public void Run()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            string Pool = settings["Pool"].Value;

            if (Pool == "0") //Coinotron
            {
                string CoinotronAPI = settings["CoinotronAPI"].Value;
                if (CoinotronAPI != "")
                {
                    CTRON = new poolCoinotron();
                    CTRON.OnPoolEvent += InOnPoolEvent;
                }
            }
            else if (Pool == "1") //P2Pool
            {
                P2P = new poolP2Pool();
                P2P.OnPoolEvent += InOnPoolEvent;
            }
        }

        public void Stop()
        {
            if(CTRON != null)
            {
                CTRON.Stop();
            }
            if(P2P != null)
            {
                P2P.Stop();
            }
        }
        
        public void PoolEvent(double time, string value)
        {
            // Make sure someone is listening to event
            if (OnPoolEvent == null) return;

            poolEventArgs args = new poolEventArgs(time, value);
            OnPoolEvent(this, args);
        }

        private void InOnPoolEvent(object sender, poolEventArgs e)
        {
            PoolEvent(e.time, e.value);
        }
    }

    public class poolEventArgs : EventArgs
    {
        public double time { get; private set; }
        public string value { get; private set; }

        public poolEventArgs(double Time, string Value)
        {
            time = Time;
            value = Value;
        }
    }
}
