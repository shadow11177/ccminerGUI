namespace ccmierGUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea28 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend28 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series55 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea29 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend29 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series56 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series57 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series58 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series59 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea30 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend30 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series60 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblBHash = new System.Windows.Forms.Label();
            this.lblRestart = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblBlock = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.chaHash = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chaStat = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblNHash = new System.Windows.Forms.Label();
            this.tmrFeatherStat = new System.Windows.Forms.Timer(this.components);
            this.chaFTC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStale = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblWorth = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCMD = new System.Windows.Forms.Label();
            this.lblInitialise = new System.Windows.Forms.Label();
            this.tmrInitialise = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chaHash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaFTC)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 34);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(517, 36);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(701, 108);
            this.lstLog.TabIndex = 1;
            // 
            // lblBHash
            // 
            this.lblBHash.AutoSize = true;
            this.lblBHash.Location = new System.Drawing.Point(9, 60);
            this.lblBHash.Name = "lblBHash";
            this.lblBHash.Size = new System.Drawing.Size(75, 13);
            this.lblBHash.TabIndex = 4;
            this.lblBHash.Text = "B. Hashrate: 0";
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Location = new System.Drawing.Point(9, 86);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(55, 13);
            this.lblRestart.TabIndex = 5;
            this.lblRestart.Text = "Restarts:0";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(9, 99);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(59, 13);
            this.lblDifficulty.TabIndex = 6;
            this.lblDifficulty.Text = "Difficulty: 0";
            // 
            // lblBlock
            // 
            this.lblBlock.AutoSize = true;
            this.lblBlock.Location = new System.Drawing.Point(124, 59);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(46, 13);
            this.lblBlock.TabIndex = 7;
            this.lblBlock.Text = "Block: - ";
            // 
            // lblAccepted
            // 
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Location = new System.Drawing.Point(124, 73);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(65, 13);
            this.lblAccepted.TabIndex = 8;
            this.lblAccepted.Text = "Accepted:  -";
            // 
            // chaHash
            // 
            this.chaHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chaHash.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea28.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea28.Name = "ChartArea1";
            this.chaHash.ChartAreas.Add(chartArea28);
            legend28.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend28.Name = "Legend1";
            this.chaHash.Legends.Add(legend28);
            this.chaHash.Location = new System.Drawing.Point(2, 307);
            this.chaHash.Name = "chaHash";
            this.chaHash.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series55.BorderColor = System.Drawing.Color.Blue;
            series55.BorderWidth = 3;
            series55.ChartArea = "ChartArea1";
            series55.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series55.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series55.Legend = "Legend1";
            series55.Name = "N. Hashrate";
            series55.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chaHash.Series.Add(series55);
            this.chaHash.Size = new System.Drawing.Size(1216, 165);
            this.chaHash.TabIndex = 9;
            this.chaHash.Text = "chart1";
            this.chaHash.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // chaStat
            // 
            this.chaStat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chaStat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chaStat.BackImageTransparentColor = System.Drawing.Color.White;
            this.chaStat.BackSecondaryColor = System.Drawing.SystemColors.ButtonFace;
            this.chaStat.BorderlineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea29.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea29.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea29.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea29.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea29.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea29.BackSecondaryColor = System.Drawing.Color.Gray;
            chartArea29.BorderColor = System.Drawing.Color.Gray;
            chartArea29.Name = "ChartArea1";
            this.chaStat.ChartAreas.Add(chartArea29);
            legend29.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend29.Name = "Legend1";
            this.chaStat.Legends.Add(legend29);
            this.chaStat.Location = new System.Drawing.Point(2, 150);
            this.chaStat.Name = "chaStat";
            this.chaStat.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series56.BorderWidth = 3;
            series56.ChartArea = "ChartArea1";
            series56.Color = System.Drawing.Color.Lime;
            series56.IsValueShownAsLabel = true;
            series56.Legend = "Legend1";
            series56.Name = "Accepted";
            series56.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series56.YValuesPerPoint = 6;
            series56.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series57.BorderWidth = 3;
            series57.ChartArea = "ChartArea1";
            series57.Color = System.Drawing.Color.Yellow;
            series57.IsValueShownAsLabel = true;
            series57.Legend = "Legend1";
            series57.Name = "Stales";
            series57.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series57.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series58.ChartArea = "ChartArea1";
            series58.Color = System.Drawing.Color.Red;
            series58.IsValueShownAsLabel = true;
            series58.Legend = "Legend1";
            series58.Name = "Errors";
            series58.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series58.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series59.BorderWidth = 3;
            series59.ChartArea = "ChartArea1";
            series59.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series59.Color = System.Drawing.Color.DarkGreen;
            series59.Legend = "Legend1";
            series59.Name = "5M avg.";
            series59.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series59.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chaStat.Series.Add(series56);
            this.chaStat.Series.Add(series57);
            this.chaStat.Series.Add(series58);
            this.chaStat.Series.Add(series59);
            this.chaStat.Size = new System.Drawing.Size(1216, 165);
            this.chaStat.TabIndex = 10;
            this.chaStat.Text = "chart2";
            this.chaStat.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblNHash
            // 
            this.lblNHash.AutoSize = true;
            this.lblNHash.Location = new System.Drawing.Point(9, 73);
            this.lblNHash.Name = "lblNHash";
            this.lblNHash.Size = new System.Drawing.Size(73, 13);
            this.lblNHash.TabIndex = 11;
            this.lblNHash.Text = "N. Hashrate:0";
            // 
            // tmrFeatherStat
            // 
            this.tmrFeatherStat.Enabled = true;
            this.tmrFeatherStat.Interval = 10000;
            this.tmrFeatherStat.Tick += new System.EventHandler(this.tmrFeatherStat_Tick);
            // 
            // chaFTC
            // 
            this.chaFTC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chaFTC.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea30.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea30.Name = "ChartArea1";
            this.chaFTC.ChartAreas.Add(chartArea30);
            legend30.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend30.Name = "Legend1";
            this.chaFTC.Legends.Add(legend30);
            this.chaFTC.Location = new System.Drawing.Point(2, 459);
            this.chaFTC.Name = "chaFTC";
            this.chaFTC.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series60.BackSecondaryColor = System.Drawing.SystemColors.ButtonFace;
            series60.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series60.ChartArea = "ChartArea1";
            series60.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series60.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series60.Legend = "Legend1";
            series60.Name = "FTC -> EUR";
            series60.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chaFTC.Series.Add(series60);
            this.chaFTC.Size = new System.Drawing.Size(1216, 165);
            this.chaFTC.TabIndex = 12;
            this.chaFTC.Text = "chart3";
            this.chaFTC.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblStale
            // 
            this.lblStale.AutoSize = true;
            this.lblStale.Location = new System.Drawing.Point(124, 86);
            this.lblStale.Name = "lblStale";
            this.lblStale.Size = new System.Drawing.Size(43, 13);
            this.lblStale.TabIndex = 13;
            this.lblStale.Text = "Stale: 0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(124, 99);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(41, 13);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "Error: 0";
            // 
            // lblWorth
            // 
            this.lblWorth.AutoSize = true;
            this.lblWorth.Location = new System.Drawing.Point(294, 59);
            this.lblWorth.Name = "lblWorth";
            this.lblWorth.Size = new System.Drawing.Size(74, 13);
            this.lblWorth.TabIndex = 15;
            this.lblWorth.Text = "FTC -> EUR:0";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(294, 73);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(55, 13);
            this.lblBalance.TabIndex = 16;
            this.lblBalance.Text = "Balance:0";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(294, 86);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(43, 13);
            this.lblValue.TabIndex = 17;
            this.lblValue.Text = "Value:0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1230, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblCMD
            // 
            this.lblCMD.AutoSize = true;
            this.lblCMD.Location = new System.Drawing.Point(93, 39);
            this.lblCMD.Name = "lblCMD";
            this.lblCMD.Size = new System.Drawing.Size(97, 13);
            this.lblCMD.TabIndex = 19;
            this.lblCMD.Text = "Command line Args";
            // 
            // lblInitialise
            // 
            this.lblInitialise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitialise.Font = new System.Drawing.Font("Microsoft Sans Serif", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialise.Location = new System.Drawing.Point(2, 153);
            this.lblInitialise.Name = "lblInitialise";
            this.lblInitialise.Size = new System.Drawing.Size(1228, 462);
            this.lblInitialise.TabIndex = 20;
            this.lblInitialise.Text = "Charts not Ready";
            this.lblInitialise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrInitialise
            // 
            this.tmrInitialise.Interval = 1000;
            this.tmrInitialise.Tick += new System.EventHandler(this.tmrInitialise_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 613);
            this.Controls.Add(this.lblInitialise);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblWorth);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblStale);
            this.Controls.Add(this.chaFTC);
            this.Controls.Add(this.lblNHash);
            this.Controls.Add(this.chaStat);
            this.Controls.Add(this.chaHash);
            this.Controls.Add(this.lblAccepted);
            this.Controls.Add(this.lblBlock);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblRestart);
            this.Controls.Add(this.lblBHash);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblCMD);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(773, 193);
            this.Name = "frmMain";
            this.Text = "ccminerGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chaHash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaFTC)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label lblBHash;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaHash;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaStat;
        private System.Windows.Forms.Label lblNHash;
        private System.Windows.Forms.Timer tmrFeatherStat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaFTC;
        private System.Windows.Forms.Label lblStale;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblWorth;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblCMD;
        private System.Windows.Forms.Label lblInitialise;
        private System.Windows.Forms.Timer tmrInitialise;
    }
}

