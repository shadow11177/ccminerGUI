namespace ccmierGUI
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.radP2Pool = new System.Windows.Forms.RadioButton();
            this.radCoinotron = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUW = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAPI = new System.Windows.Forms.Label();
            this.txtUW = new System.Windows.Forms.TextBox();
            this.txtWP = new System.Windows.Forms.TextBox();
            this.txtAPI = new System.Windows.Forms.TextBox();
            this.cboCurr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMiner = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ofdMiner = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIntensity = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(271, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radP2Pool
            // 
            this.radP2Pool.AutoSize = true;
            this.radP2Pool.Location = new System.Drawing.Point(6, 42);
            this.radP2Pool.Name = "radP2Pool";
            this.radP2Pool.Size = new System.Drawing.Size(59, 17);
            this.radP2Pool.TabIndex = 1;
            this.radP2Pool.Text = "P2Pool";
            this.radP2Pool.UseVisualStyleBackColor = true;
            this.radP2Pool.CheckedChanged += new System.EventHandler(this.radP2Pool_CheckedChanged);
            // 
            // radCoinotron
            // 
            this.radCoinotron.AutoSize = true;
            this.radCoinotron.Checked = true;
            this.radCoinotron.Location = new System.Drawing.Point(6, 19);
            this.radCoinotron.Name = "radCoinotron";
            this.radCoinotron.Size = new System.Drawing.Size(70, 17);
            this.radCoinotron.TabIndex = 2;
            this.radCoinotron.TabStop = true;
            this.radCoinotron.Text = "Coinotron";
            this.radCoinotron.UseVisualStyleBackColor = true;
            this.radCoinotron.CheckedChanged += new System.EventHandler(this.radCoinotron_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radP2Pool);
            this.groupBox1.Controls.Add(this.radCoinotron);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mining Pool";
            // 
            // lblUW
            // 
            this.lblUW.AutoSize = true;
            this.lblUW.Location = new System.Drawing.Point(15, 96);
            this.lblUW.Name = "lblUW";
            this.lblUW.Size = new System.Drawing.Size(70, 13);
            this.lblUW.TabIndex = 4;
            this.lblUW.Text = "User.Worker:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "WorkerPassword:";
            // 
            // lblAPI
            // 
            this.lblAPI.AutoSize = true;
            this.lblAPI.Location = new System.Drawing.Point(15, 140);
            this.lblAPI.Name = "lblAPI";
            this.lblAPI.Size = new System.Drawing.Size(48, 13);
            this.lblAPI.TabIndex = 6;
            this.lblAPI.Text = "API-Key:";
            // 
            // txtUW
            // 
            this.txtUW.Location = new System.Drawing.Point(109, 93);
            this.txtUW.Name = "txtUW";
            this.txtUW.Size = new System.Drawing.Size(318, 20);
            this.txtUW.TabIndex = 7;
            this.txtUW.Leave += new System.EventHandler(this.txtUW_Leave);
            // 
            // txtWP
            // 
            this.txtWP.Location = new System.Drawing.Point(109, 115);
            this.txtWP.Name = "txtWP";
            this.txtWP.Size = new System.Drawing.Size(318, 20);
            this.txtWP.TabIndex = 8;
            // 
            // txtAPI
            // 
            this.txtAPI.Location = new System.Drawing.Point(109, 137);
            this.txtAPI.Name = "txtAPI";
            this.txtAPI.Size = new System.Drawing.Size(318, 20);
            this.txtAPI.TabIndex = 9;
            // 
            // cboCurr
            // 
            this.cboCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurr.FormattingEnabled = true;
            this.cboCurr.Items.AddRange(new object[] {
            "Australian Dollar",
            "Euro",
            "Great Britain Pound",
            "New Zeland Dollar",
            "US Dollar",
            "Bitcoin"});
            this.cboCurr.Location = new System.Drawing.Point(109, 159);
            this.cboCurr.Name = "cboCurr";
            this.cboCurr.Size = new System.Drawing.Size(318, 21);
            this.cboCurr.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "DisplayCurrency:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(109, 182);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(318, 20);
            this.txtAddress.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(15, 185);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(75, 13);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Wallet Adress:";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.Location = new System.Drawing.Point(352, 282);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 14;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Miner:";
            // 
            // cboMiner
            // 
            this.cboMiner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMiner.FormattingEnabled = true;
            this.cboMiner.Location = new System.Drawing.Point(109, 205);
            this.cboMiner.Name = "cboMiner";
            this.cboMiner.Size = new System.Drawing.Size(318, 21);
            this.cboMiner.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(109, 230);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(238, 20);
            this.txtPath.TabIndex = 17;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(353, 228);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ofdMiner
            // 
            this.ofdMiner.FileName = "Miner.exe";
            this.ofdMiner.Filter = "Neoscrypt-Miner|*.exe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Intensity:";
            // 
            // txtIntensity
            // 
            this.txtIntensity.Location = new System.Drawing.Point(109, 254);
            this.txtIntensity.Name = "txtIntensity";
            this.txtIntensity.Size = new System.Drawing.Size(318, 20);
            this.txtIntensity.TabIndex = 20;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 316);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIntensity);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMiner);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCurr);
            this.Controls.Add(this.txtAPI);
            this.Controls.Add(this.txtWP);
            this.Controls.Add(this.txtUW);
            this.Controls.Add(this.lblAPI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUW);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radP2Pool;
        private System.Windows.Forms.RadioButton radCoinotron;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAPI;
        private System.Windows.Forms.TextBox txtUW;
        private System.Windows.Forms.TextBox txtWP;
        private System.Windows.Forms.TextBox txtAPI;
        private System.Windows.Forms.ComboBox cboCurr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMiner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.OpenFileDialog ofdMiner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIntensity;
    }
}