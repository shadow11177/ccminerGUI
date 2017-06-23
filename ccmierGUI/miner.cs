using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccmierGUI
{
    class miner
    {
        public delegate void minerReportEventHandler(object sender, minerReportEventArgs e);
        public event minerReportEventHandler OnMinerReportEvent;

        public delegate void minerEventHandler(object sender, minerEventArgs e);
        public event minerEventHandler OnMinerEvent;

        minerCMD CMDminer;
        minerRPC RPCminer;

        public miner()
        {
        }

        public void Stop()
        {
            if (CMDminer != null)
            {
                CMDminer.Stop();
                CMDminer.OnMinerEvent -= InOnMinerEvent;
                CMDminer.OnMinerReportEvent -= InOnMinerReportEvent;
            }
            if (RPCminer != null)
            {
                RPCminer.Stop();
                RPCminer.OnMinerEvent -= InOnMinerEvent;
                RPCminer.OnMinerReportEvent -= InOnMinerReportEvent;
            }
        }

        public void Run()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            string type = settings["Miner"].Value;
            if (type == "0") //CCMiner
            {
                CMDminer = new minerCMD();
                CMDminer.OnMinerEvent += InOnMinerEvent;
                CMDminer.OnMinerReportEvent += InOnMinerReportEvent;

            }
            else if (type == "1") //BFGMiner / NSGMiner
            {
                RPCminer = new minerRPC();
                RPCminer.OnMinerEvent += InOnMinerEvent;
                RPCminer.OnMinerReportEvent += InOnMinerReportEvent;
            }
        }

        public void MinerReportEvent(minerReport report)
        {
            // Make sure someone is listening to event
            if (OnMinerReportEvent == null) return;

            minerReportEventArgs args = new minerReportEventArgs(report);
            OnMinerReportEvent(this, args);
        }

        private void InOnMinerReportEvent(object sender, minerReportEventArgs e)
        {
            MinerReportEvent(e.report);
        }

        public void MinerEvent(string Line)
        {
            // Make sure someone is listening to event
            if (OnMinerEvent == null) return;

            minerEventArgs args = new minerEventArgs(Line);
            OnMinerEvent(this, args);
        }

        private void InOnMinerEvent(object sender, minerEventArgs e)
        {
            MinerEvent(e.Line);
        }
    }

    public class minerReport
    {
        public int allhash { get; set; } // all GPU hashrates together
        public Dictionary<int, string[]> GPUs = new Dictionary<int, string[]>(); // all GPUS with their name and hashrate
        public string difficulty { get; set; } // current difficulty

        public int merror { get; set; } // new errors in the last minute
        public int allerror { get; set; } // all errors ever occured

        public int mshare { get; set; } // new shares in the last minute
        public int allshare { get; set; } // all shares ever occured

        public int mstale { get; set; } // new stales in the last minute
        public int allstale { get; set; } // all stales ever occured

        public int restarts { get; set; } // all stales ever occured

        public string block { get; set; } // the current block

        public string cmd { get; set; } // the current block
    }

    public class minerReportEventArgs : EventArgs
    {
        public minerReport report { get; private set; }

        public minerReportEventArgs(minerReport Report)
        {
            report = Report;
        }
    }

    public class minerEventArgs : EventArgs
    {
        public string Line { get; private set; } // the commandline send by the miner

        public minerEventArgs(string line)
        {
            Line = line;
        }
    }
}
