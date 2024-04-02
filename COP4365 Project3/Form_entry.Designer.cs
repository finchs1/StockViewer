namespace COP4365_Project3
{
    partial class Form_entry
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog_csv = new System.Windows.Forms.OpenFileDialog();
            this.button_load = new System.Windows.Forms.Button();
            this.chart_csticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker_startdate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_enddate = new System.Windows.Forms.DateTimePicker();
            this.label_startdate = new System.Windows.Forms.Label();
            this.label_enddate = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.radioButton_daily = new System.Windows.Forms.RadioButton();
            this.radioButton_weekly = new System.Windows.Forms.RadioButton();
            this.radioButton_monthly = new System.Windows.Forms.RadioButton();
            this.label_period = new System.Windows.Forms.Label();
            this.comboBox_pattern = new System.Windows.Forms.ComboBox();
            this.label_pattern = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_csticks)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_csv
            // 
            this.openFileDialog_csv.Filter = "All Stock files|*.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly Sto" +
    "cks|*-Month.csv";
            this.openFileDialog_csv.InitialDirectory = "..\\..\\..\\..\\Stock Data";
            this.openFileDialog_csv.Multiselect = true;
            this.openFileDialog_csv.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_csv_FileOk);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(218, 45);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(80, 43);
            this.button_load.TabIndex = 4;
            this.button_load.Text = "Load Stock File";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Visible = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // chart_csticks
            // 
            this.chart_csticks.BackColor = System.Drawing.Color.DimGray;
            chartArea3.AlignWithChartArea = "ChartArea_Volume";
            chartArea3.AxisX.Title = "Date";
            chartArea3.AxisY.Title = "Price";
            chartArea3.Name = "ChartArea_OHLC";
            chartArea4.AlignWithChartArea = "ChartArea_OHLC";
            chartArea4.AxisX.Title = "Date";
            chartArea4.AxisY.Title = "Volume";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_csticks.ChartAreas.Add(chartArea3);
            this.chart_csticks.ChartAreas.Add(chartArea4);
            legend2.Name = "Legend1";
            this.chart_csticks.Legends.Add(legend2);
            this.chart_csticks.Location = new System.Drawing.Point(12, 94);
            this.chart_csticks.Name = "chart_csticks";
            series3.ChartArea = "ChartArea_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceUpColor=Green, PriceDownColor=Red";
            series3.Legend = "Legend1";
            series3.Name = "Series_OHLC";
            series3.XValueMember = "date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueMembers = "high,low,open,close";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea_Volume";
            series4.Legend = "Legend1";
            series4.Name = "Series_Volume";
            series4.XValueMember = "date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.YValueMembers = "volume";
            this.chart_csticks.Series.Add(series3);
            this.chart_csticks.Series.Add(series4);
            this.chart_csticks.Size = new System.Drawing.Size(1266, 450);
            this.chart_csticks.TabIndex = 15;
            this.chart_csticks.Text = "Ticker";
            // 
            // dateTimePicker_startdate
            // 
            this.dateTimePicker_startdate.Location = new System.Drawing.Point(12, 24);
            this.dateTimePicker_startdate.Name = "dateTimePicker_startdate";
            this.dateTimePicker_startdate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startdate.TabIndex = 24;
            this.dateTimePicker_startdate.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_enddate
            // 
            this.dateTimePicker_enddate.Location = new System.Drawing.Point(12, 68);
            this.dateTimePicker_enddate.Name = "dateTimePicker_enddate";
            this.dateTimePicker_enddate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_enddate.TabIndex = 25;
            // 
            // label_startdate
            // 
            this.label_startdate.AutoSize = true;
            this.label_startdate.Location = new System.Drawing.Point(12, 6);
            this.label_startdate.Name = "label_startdate";
            this.label_startdate.Size = new System.Drawing.Size(72, 13);
            this.label_startdate.TabIndex = 26;
            this.label_startdate.Text = "Starting Date:";
            // 
            // label_enddate
            // 
            this.label_enddate.AutoSize = true;
            this.label_enddate.Location = new System.Drawing.Point(12, 51);
            this.label_enddate.Name = "label_enddate";
            this.label_enddate.Size = new System.Drawing.Size(69, 13);
            this.label_enddate.TabIndex = 27;
            this.label_enddate.Text = "Ending Date:";
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(218, 24);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(80, 20);
            this.button_update.TabIndex = 28;
            this.button_update.Text = "Update Chart";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // radioButton_daily
            // 
            this.radioButton_daily.AutoSize = true;
            this.radioButton_daily.Enabled = false;
            this.radioButton_daily.Location = new System.Drawing.Point(1223, 22);
            this.radioButton_daily.Name = "radioButton_daily";
            this.radioButton_daily.Size = new System.Drawing.Size(48, 17);
            this.radioButton_daily.TabIndex = 21;
            this.radioButton_daily.TabStop = true;
            this.radioButton_daily.Text = "Daily";
            this.radioButton_daily.UseVisualStyleBackColor = true;
            this.radioButton_daily.CheckedChanged += new System.EventHandler(this.radioButton_PeriodCheckedChanged);
            // 
            // radioButton_weekly
            // 
            this.radioButton_weekly.AutoSize = true;
            this.radioButton_weekly.Enabled = false;
            this.radioButton_weekly.Location = new System.Drawing.Point(1223, 68);
            this.radioButton_weekly.Name = "radioButton_weekly";
            this.radioButton_weekly.Size = new System.Drawing.Size(61, 17);
            this.radioButton_weekly.TabIndex = 22;
            this.radioButton_weekly.TabStop = true;
            this.radioButton_weekly.Text = "Weekly";
            this.radioButton_weekly.UseVisualStyleBackColor = true;
            this.radioButton_weekly.CheckedChanged += new System.EventHandler(this.radioButton_PeriodCheckedChanged);
            // 
            // radioButton_monthly
            // 
            this.radioButton_monthly.AutoSize = true;
            this.radioButton_monthly.Enabled = false;
            this.radioButton_monthly.Location = new System.Drawing.Point(1223, 45);
            this.radioButton_monthly.Name = "radioButton_monthly";
            this.radioButton_monthly.Size = new System.Drawing.Size(62, 17);
            this.radioButton_monthly.TabIndex = 19;
            this.radioButton_monthly.TabStop = true;
            this.radioButton_monthly.Text = "Monthly";
            this.radioButton_monthly.UseVisualStyleBackColor = true;
            this.radioButton_monthly.CheckedChanged += new System.EventHandler(this.radioButton_PeriodCheckedChanged);
            // 
            // label_period
            // 
            this.label_period.AutoSize = true;
            this.label_period.Location = new System.Drawing.Point(1220, 6);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(40, 13);
            this.label_period.TabIndex = 29;
            this.label_period.Text = "Period:";
            // 
            // comboBox_pattern
            // 
            this.comboBox_pattern.DisplayMember = "Bearish";
            this.comboBox_pattern.FormattingEnabled = true;
            this.comboBox_pattern.Location = new System.Drawing.Point(1047, 22);
            this.comboBox_pattern.Name = "comboBox_pattern";
            this.comboBox_pattern.Size = new System.Drawing.Size(121, 21);
            this.comboBox_pattern.TabIndex = 30;
            this.comboBox_pattern.SelectedIndexChanged += new System.EventHandler(this.pattern_changed);
            // 
            // label_pattern
            // 
            this.label_pattern.AutoSize = true;
            this.label_pattern.Location = new System.Drawing.Point(1044, 6);
            this.label_pattern.Name = "label_pattern";
            this.label_pattern.Size = new System.Drawing.Size(44, 13);
            this.label_pattern.TabIndex = 31;
            this.label_pattern.Text = "Pattern:";
            // 
            // Form_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 556);
            this.Controls.Add(this.label_pattern);
            this.Controls.Add(this.comboBox_pattern);
            this.Controls.Add(this.label_period);
            this.Controls.Add(this.radioButton_monthly);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.radioButton_weekly);
            this.Controls.Add(this.label_enddate);
            this.Controls.Add(this.radioButton_daily);
            this.Controls.Add(this.label_startdate);
            this.Controls.Add(this.dateTimePicker_enddate);
            this.Controls.Add(this.dateTimePicker_startdate);
            this.Controls.Add(this.chart_csticks);
            this.Controls.Add(this.button_load);
            this.MaximizeBox = false;
            this.Name = "Form_entry";
            this.Text = "Stock Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.chart_csticks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog_csv;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_csticks;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_enddate;
        private System.Windows.Forms.Label label_startdate;
        private System.Windows.Forms.Label label_enddate;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.RadioButton radioButton_daily;
        private System.Windows.Forms.RadioButton radioButton_weekly;
        private System.Windows.Forms.RadioButton radioButton_monthly;
        private System.Windows.Forms.Label label_period;
        private System.Windows.Forms.ComboBox comboBox_pattern;
        private System.Windows.Forms.Label label_pattern;
    }
}

