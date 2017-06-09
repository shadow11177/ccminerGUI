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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.txtCMD = new System.Windows.Forms.TextBox();
            this.tmrProbe = new System.Windows.Forms.Timer(this.components);
            this.lblStat = new System.Windows.Forms.Label();
            this.lblBHash = new System.Windows.Forms.Label();
            this.lblRestart = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblBlock = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.chaHash = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tmrChart = new System.Windows.Forms.Timer(this.components);
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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lstLog.Size = new System.Drawing.Size(702, 108);
            this.lstLog.TabIndex = 1;
            // 
            // txtCMD
            // 
            this.txtCMD.Location = new System.Drawing.Point(93, 36);
            this.txtCMD.Name = "txtCMD";
            this.txtCMD.Size = new System.Drawing.Size(418, 20);
            this.txtCMD.TabIndex = 2;
            // 
            // tmrProbe
            // 
            this.tmrProbe.Interval = 1000;
            this.tmrProbe.Tick += new System.EventHandler(this.tmrProbe_Tick);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(9, 60);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(37, 13);
            this.lblStat.TabIndex = 3;
            this.lblStat.Text = "Offline";
            // 
            // lblBHash
            // 
            this.lblBHash.AutoSize = true;
            this.lblBHash.Location = new System.Drawing.Point(9, 73);
            this.lblBHash.Name = "lblBHash";
            this.lblBHash.Size = new System.Drawing.Size(72, 13);
            this.lblBHash.TabIndex = 4;
            this.lblBHash.Text = "B. Hashrate:0";
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Location = new System.Drawing.Point(9, 99);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(55, 13);
            this.lblRestart.TabIndex = 5;
            this.lblRestart.Text = "Restarts:0";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(9, 112);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(56, 13);
            this.lblDifficulty.TabIndex = 6;
            this.lblDifficulty.Text = "Difficulty:0";
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
            chartArea4.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.Name = "ChartArea1";
            this.chaHash.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend4.Name = "Legend1";
            this.chaHash.Legends.Add(legend4);
            this.chaHash.Location = new System.Drawing.Point(2, 307);
            this.chaHash.Name = "chaHash";
            this.chaHash.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series7.BorderColor = System.Drawing.Color.Blue;
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series7.Legend = "Legend1";
            series7.Name = "N. Hashrate";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chaHash.Series.Add(series7);
            this.chaHash.Size = new System.Drawing.Size(1217, 165);
            this.chaHash.TabIndex = 9;
            this.chaHash.Text = "chart1";
            this.chaHash.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // tmrChart
            // 
            this.tmrChart.Interval = 2000;
            this.tmrChart.Tick += new System.EventHandler(this.tmrChart_Tick);
            // 
            // chaStat
            // 
            this.chaStat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chaStat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.chaStat.BackImageTransparentColor = System.Drawing.Color.White;
            this.chaStat.BackSecondaryColor = System.Drawing.SystemColors.ButtonFace;
            this.chaStat.BorderlineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea5.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea5.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea5.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea5.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.BackSecondaryColor = System.Drawing.Color.Gray;
            chartArea5.BorderColor = System.Drawing.Color.Gray;
            chartArea5.Name = "ChartArea1";
            this.chaStat.ChartAreas.Add(chartArea5);
            legend5.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend5.Name = "Legend1";
            this.chaStat.Legends.Add(legend5);
            this.chaStat.Location = new System.Drawing.Point(2, 150);
            this.chaStat.Name = "chaStat";
            this.chaStat.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Lime;
            series8.IsValueShownAsLabel = true;
            series8.Legend = "Legend1";
            series8.Name = "Accepted";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series8.YValuesPerPoint = 6;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.Yellow;
            series9.IsValueShownAsLabel = true;
            series9.Legend = "Legend1";
            series9.Name = "Stales";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.Red;
            series10.IsValueShownAsLabel = true;
            series10.Legend = "Legend1";
            series10.Name = "Errors";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series10.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Color = System.Drawing.Color.DarkGreen;
            series11.Legend = "Legend1";
            series11.Name = "5M avg.";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series11.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chaStat.Series.Add(series8);
            this.chaStat.Series.Add(series9);
            this.chaStat.Series.Add(series10);
            this.chaStat.Series.Add(series11);
            this.chaStat.Size = new System.Drawing.Size(1217, 165);
            this.chaStat.TabIndex = 10;
            this.chaStat.Text = "chart2";
            this.chaStat.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblNHash
            // 
            this.lblNHash.AutoSize = true;
            this.lblNHash.Location = new System.Drawing.Point(9, 86);
            this.lblNHash.Name = "lblNHash";
            this.lblNHash.Size = new System.Drawing.Size(73, 13);
            this.lblNHash.TabIndex = 11;
            this.lblNHash.Text = "N. Hashrate:0";
            // 
            // tmrFeatherStat
            // 
            this.tmrFeatherStat.Interval = 10000;
            this.tmrFeatherStat.Tick += new System.EventHandler(this.tmrFeatherStat_Tick);
            // 
            // chaFTC
            // 
            this.chaFTC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chaFTC.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.Name = "ChartArea1";
            this.chaFTC.ChartAreas.Add(chartArea6);
            legend6.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend6.Name = "Legend1";
            this.chaFTC.Legends.Add(legend6);
            this.chaFTC.Location = new System.Drawing.Point(2, 459);
            this.chaFTC.Name = "chaFTC";
            this.chaFTC.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series12.BackSecondaryColor = System.Drawing.SystemColors.ButtonFace;
            series12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series12.Legend = "Legend1";
            series12.Name = "FTC -> EUR";
            series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chaFTC.Series.Add(series12);
            this.chaFTC.Size = new System.Drawing.Size(1217, 165);
            this.chaFTC.TabIndex = 12;
            this.chaFTC.Text = "chart3";
            this.chaFTC.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblStale
            // 
            this.lblStale.AutoSize = true;
            this.lblStale.Location = new System.Drawing.Point(124, 86);
            this.lblStale.Name = "lblStale";
            this.lblStale.Size = new System.Drawing.Size(40, 13);
            this.lblStale.TabIndex = 13;
            this.lblStale.Text = "Stale:0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(124, 99);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(38, 13);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "Error:0";
            // 
            // lblWorth
            // 
            this.lblWorth.AutoSize = true;
            this.lblWorth.Location = new System.Drawing.Point(124, 112);
            this.lblWorth.Name = "lblWorth";
            this.lblWorth.Size = new System.Drawing.Size(74, 13);
            this.lblWorth.TabIndex = 15;
            this.lblWorth.Text = "FTC -> EUR:0";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(294, 86);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(55, 13);
            this.lblBalance.TabIndex = 16;
            this.lblBalance.Text = "Balance:0";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(294, 99);
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
            this.menuStrip1.Size = new System.Drawing.Size(1231, 24);
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 621);
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
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.txtCMD);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.TextBox txtCMD;
        private System.Windows.Forms.Timer tmrProbe;
        private System.Windows.Forms.Label lblStat;
        public System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label lblBHash;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaHash;
        private System.Windows.Forms.Timer tmrChart;
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
    }
}

