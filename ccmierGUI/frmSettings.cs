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

        int _conf_pool = 0;

        List<string> currencies = new List<string>();
        public string[] CMiners;

        private void frmSettings_Load(object sender, EventArgs e)
        {
            cboMiner.Items.Clear();
            cboMiner.Items.AddRange(CMiners);
            cboMiner.SelectedIndex = 0;

            currencies.Add("aud");
            currencies.Add("eur");
            currencies.Add("gbp");
            currencies.Add("nzd");
            currencies.Add("usd");
            currencies.Add("btc");

            getConfig();

            
        }

        private void getConfig()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            
            cboMiner.SelectedIndex = Convert.ToInt32(settings["Miner"].Value);
            txtPath.Text = settings["Path"].Value;
            _conf_pool = Convert.ToInt32(settings["Pool"].Value);
            txtIntensity.Text = settings["Intensity"].Value;
            cboCurr.SelectedIndex = currencies.IndexOf(settings["Currency"].Value);
            numThreshhold.Value = Convert.ToInt32(settings["Threshold"].Value);

            if (_conf_pool == 0)
            {
                radCoinotron.Checked = true;
                txtAddress.Text = settings["FeathercoinWalletAddress"].Value;
                txtAPI.Text = settings["CoinotronAPI"].Value;
                txtUW.Text = settings["Worker"].Value;
                txtWP.Text = settings["Pass"].Value;
            }
            else
            {
                radP2Pool.Checked = true;
                txtAddress.Text = settings["FeathercoinWalletAddress"].Value;
                txtUW.Text = settings["PoolAddress"].Value;
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
            string pool = "0";
            string pooladress = "coinotron.com:3337";
            string pass = txtWP.Text;
            string worker = txtUW.Text;
            if (radP2Pool.Checked)
            {
                pooladress = txtUW.Text;
                pool = "1";
                pass = "x";
                worker = txtAddress.Text;
            }
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings["CoinotronAPI"].Value = txtAPI.Text;
            settings["Miner"].Value = cboMiner.SelectedIndex.ToString();
            settings["Path"].Value = txtPath.Text;
            settings["Pool"].Value = pool;
            settings["Intensity"].Value = txtIntensity.Text;
            settings["Worker"].Value = worker;
            settings["Currency"].Value = currencies[cboCurr.SelectedIndex];
            settings["FeathercoinWalletAddress"].Value = txtAddress.Text;
            settings["PoolAddress"].Value = pooladress;
            settings["Pass"].Value = pass;
            settings["Threshold"].Value = numThreshhold.Value.ToString();


            configFile.Save(ConfigurationSaveMode.Minimal,true);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtUW_Leave(object sender, EventArgs e)
        {
            txtUW.Text = txtUW.Text.Replace("tcp://", "").Replace("http://", "").Replace("https://", "");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ofdMiner.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdMiner.FileName;
            }
        }
    }
}
