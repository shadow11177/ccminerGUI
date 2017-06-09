using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ccmierGUI
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        string _conf_coinotronAPI = "";
        string _conf_coinotronWRK = "";
        string _conf_coinotronWRKP = "";
        string _conf_currency = "";
        string _conf_walletFTC = "";
        string _conf_Args = "";
        string _conf_p2pool = "";

        List<string> currencies = new List<string>();

        private void frmSettings_Load(object sender, EventArgs e)
        {
            currencies.Add("aud");
            currencies.Add("eur");
            currencies.Add("gbp");
            currencies.Add("nzd");
            currencies.Add("usd");
            currencies.Add("btc");

            getConfig();

            if(_conf_coinotronWRK != "")
            {
                radCoinotron.Checked = true;
                txtAddress.Text = _conf_walletFTC;
                txtAPI.Text = _conf_coinotronAPI;
                txtUW.Text = _conf_coinotronWRK;
                txtWP.Text = _conf_coinotronWRKP;
            }
            else
            {
                radP2Pool.Checked = true;
                txtAddress.Text = _conf_walletFTC;
                txtUW.Text = _conf_p2pool.Replace("tcp://", "").Replace("http://", "").Replace("https://", "");
            }
            cboCurr.SelectedIndex = currencies.IndexOf(_conf_currency);
        }

        private void getConfig()
        {
            string[] config = ConfigurationManager.AppSettings.AllKeys;

            foreach (string key in config)
            {
                switch (key)
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
                        _conf_Args = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "p2poolAddress":
                        _conf_p2pool = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                    case "CoinotronWorkerPass":
                        _conf_coinotronWRKP = ConfigurationManager.AppSettings.GetValues(key)[0];
                        break;
                }
            }
        }

        private void radCoinotron_CheckedChanged(object sender, EventArgs e)
        {
            if(radCoinotron.Checked)
            {
                txtWP.Enabled = true;
                txtAPI.Enabled = true;
                lblUW.Text = "User.Worker:";
            }
        }

        private void radP2Pool_CheckedChanged(object sender, EventArgs e)
        {

            if (radP2Pool.Checked)
            {
                txtWP.Enabled = false;
                txtAPI.Enabled = false;
                txtWP.Text = "";
                txtAPI.Text = "";
                lblUW.Text = "PoolAddress:";
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (radP2Pool.Checked)
            {
                AddOrUpdateAppSettings("CoinotronAPI", txtAPI.Text);
                AddOrUpdateAppSettings("CoinotronWorker", txtUW.Text);
                AddOrUpdateAppSettings("Currency", currencies[cboCurr.SelectedIndex]);
                AddOrUpdateAppSettings("FeathercoinWalletAddress", txtAddress.Text);
                AddOrUpdateAppSettings("ccminerArgs", "-a neoscrypt -i 15 -o stratum+tcp://" + txtUW.Text + " -u " + txtWP.Text + " -p x");
                AddOrUpdateAppSettings("p2poolAddress", "http://" + txtUW.Text);
                AddOrUpdateAppSettings("CoinotronWorkerPass", txtWP.Text);
            }

            if (radCoinotron.Checked)
            {
                AddOrUpdateAppSettings("CoinotronAPI", txtAPI.Text);
                AddOrUpdateAppSettings("CoinotronWorker", txtUW.Text);
                AddOrUpdateAppSettings("Currency", currencies[cboCurr.SelectedIndex]);
                AddOrUpdateAppSettings("FeathercoinWalletAddress", txtAddress.Text);
                AddOrUpdateAppSettings("ccminerArgs", "-a neoscrypt -i 15 -o stratum+tcp://coinotron.com:3337 -u " + txtUW.Text + " -p " + txtWP.Text);
                AddOrUpdateAppSettings("p2poolAddress", "");
                AddOrUpdateAppSettings("CoinotronWorkerPass", txtWP.Text);


            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch 
            {
            }
        }

        private void txtUW_Leave(object sender, EventArgs e)
        {
            txtUW.Text = txtUW.Text.Replace("tcp://", "").Replace("http://", "").Replace("https://", "");
        }
    }
}
