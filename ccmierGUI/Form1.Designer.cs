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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.lblStall = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblWorth = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chaHash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaFTC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
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
            this.lstLog.Location = new System.Drawing.Point(517, 14);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(702, 108);
            this.lstLog.TabIndex = 1;
            // 
            // txtCMD
            // 
            this.txtCMD.Location = new System.Drawing.Point(93, 14);
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
            this.lblStat.Location = new System.Drawing.Point(9, 38);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(37, 13);
            this.lblStat.TabIndex = 3;
            this.lblStat.Text = "Offline";
            // 
            // lblBHash
            // 
            this.lblBHash.AutoSize = true;
            this.lblBHash.Location = new System.Drawing.Point(9, 51);
            this.lblBHash.Name = "lblBHash";
            this.lblBHash.Size = new System.Drawing.Size(72, 13);
            this.lblBHash.TabIndex = 4;
            this.lblBHash.Text = "B. Hashrate:0";
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Location = new System.Drawing.Point(9, 77);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(55, 13);
            this.lblRestart.TabIndex = 5;
            this.lblRestart.Text = "Restarts:0";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(9, 90);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(56, 13);
            this.lblDifficulty.TabIndex = 6;
            this.lblDifficulty.Text = "Difficulty:0";
            // 
            // lblBlock
            // 
            this.lblBlock.AutoSize = true;
            this.lblBlock.Location = new System.Drawing.Point(124, 37);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(46, 13);
            this.lblBlock.TabIndex = 7;
            this.lblBlock.Text = "Block: - ";
            // 
            // lblAccepted
            // 
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Location = new System.Drawing.Point(124, 51);
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
            chartArea1.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea1.Name = "ChartArea1";
            this.chaHash.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend1.Name = "Legend1";
            this.chaHash.Legends.Add(legend1);
            this.chaHash.Location = new System.Drawing.Point(2, 307);
            this.chaHash.Name = "chaHash";
            this.chaHash.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BackSecondaryColor = System.Drawing.SystemColors.ButtonFace;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series1.Legend = "Legend1";
            series1.Name = "B. Hashrate";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.BorderColor = System.Drawing.Color.Blue;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series2.Legend = "Legend1";
            series2.Name = "N. Hashrate";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chaHash.Series.Add(series1);
            this.chaHash.Series.Add(series2);
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
            chartArea2.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea2.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Gray;
            chartArea2.BorderColor = System.Drawing.Color.Gray;
            chartArea2.Name = "ChartArea1";
            this.chaStat.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend2.Name = "Legend1";
            this.chaStat.Legends.Add(legend2);
            this.chaStat.Location = new System.Drawing.Point(2, 150);
            this.chaStat.Name = "chaStat";
            this.chaStat.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Lime;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Accepted";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series3.YValuesPerPoint = 6;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Yellow;
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Stalls";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Red;
            series5.IsValueShownAsLabel = true;
            series5.Legend = "Legend1";
            series5.Name = "Errors";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.DarkGreen;
            series6.Legend = "Legend1";
            series6.Name = "5M avg.";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chaStat.Series.Add(series3);
            this.chaStat.Series.Add(series4);
            this.chaStat.Series.Add(series5);
            this.chaStat.Series.Add(series6);
            this.chaStat.Size = new System.Drawing.Size(1217, 165);
            this.chaStat.TabIndex = 10;
            this.chaStat.Text = "chart2";
            this.chaStat.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblNHash
            // 
            this.lblNHash.AutoSize = true;
            this.lblNHash.Location = new System.Drawing.Point(9, 64);
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
            chartArea3.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea3.Name = "ChartArea1";
            this.chaFTC.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend3.Name = "Legend1";
            this.chaFTC.Legends.Add(legend3);
            this.chaFTC.Location = new System.Drawing.Point(2, 459);
            this.chaFTC.Name = "chaFTC";
            this.chaFTC.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series7.BackSecondaryColor = System.Drawing.SystemColors.ButtonFace;
            series7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "FTC -> EUR";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chaFTC.Series.Add(series7);
            this.chaFTC.Size = new System.Drawing.Size(1217, 165);
            this.chaFTC.TabIndex = 12;
            this.chaFTC.Text = "chart3";
            this.chaFTC.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // lblStall
            // 
            this.lblStall.AutoSize = true;
            this.lblStall.Location = new System.Drawing.Point(124, 64);
            this.lblStall.Name = "lblStall";
            this.lblStall.Size = new System.Drawing.Size(36, 13);
            this.lblStall.TabIndex = 13;
            this.lblStall.Text = "Stall:0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(124, 77);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(38, 13);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "Error:0";
            // 
            // lblWorth
            // 
            this.lblWorth.AutoSize = true;
            this.lblWorth.Location = new System.Drawing.Point(124, 90);
            this.lblWorth.Name = "lblWorth";
            this.lblWorth.Size = new System.Drawing.Size(74, 13);
            this.lblWorth.TabIndex = 15;
            this.lblWorth.Text = "FTC -> EUR:0";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(294, 64);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(55, 13);
            this.lblBalance.TabIndex = 16;
            this.lblBalance.Text = "Balance:0";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(294, 77);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(43, 13);
            this.lblValue.TabIndex = 17;
            this.lblValue.Text = "Value:0";
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
            this.Controls.Add(this.lblStall);
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
            this.Name = "frmMain";
            this.Text = "ccminerGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chaHash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chaFTC)).EndInit();
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
        private System.Windows.Forms.Label lblStall;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblWorth;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblValue;
    }
}

