namespace Termo_v1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.ButtonPortsUpdate = new System.Windows.Forms.Button();
            this.textBoxBottomLable = new System.Windows.Forms.TextBox();
            this.textBoxBottomTemp = new System.Windows.Forms.TextBox();
            this.bottomStart = new System.Windows.Forms.Button();
            this.bottomStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_setPoint_bt = new System.Windows.Forms.TextBox();
            this.btn_Save_senPoint_bt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // chart
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(256, 13);
            this.chart.Name = "chart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "текущая температура";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.LegendText = "заданная тепмература";
            series2.Name = "Series2";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(1108, 611);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(12, 12);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPorts.TabIndex = 1;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(139, 13);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(111, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Подключится";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ConnectPort);
            // 
            // ButtonPortsUpdate
            // 
            this.ButtonPortsUpdate.Location = new System.Drawing.Point(139, 42);
            this.ButtonPortsUpdate.Name = "ButtonPortsUpdate";
            this.ButtonPortsUpdate.Size = new System.Drawing.Size(111, 23);
            this.ButtonPortsUpdate.TabIndex = 3;
            this.ButtonPortsUpdate.Text = "Обновить";
            this.ButtonPortsUpdate.UseVisualStyleBackColor = true;
            this.ButtonPortsUpdate.Click += new System.EventHandler(this.ButtonPortsUpdate_Click);
            // 
            // textBoxBottomLable
            // 
            this.textBoxBottomLable.Location = new System.Drawing.Point(12, 113);
            this.textBoxBottomLable.Name = "textBoxBottomLable";
            this.textBoxBottomLable.Size = new System.Drawing.Size(130, 22);
            this.textBoxBottomLable.TabIndex = 4;
            this.textBoxBottomLable.Text = "Температура Низ";
            // 
            // textBoxBottomTemp
            // 
            this.textBoxBottomTemp.Location = new System.Drawing.Point(12, 141);
            this.textBoxBottomTemp.Name = "textBoxBottomTemp";
            this.textBoxBottomTemp.Size = new System.Drawing.Size(100, 22);
            this.textBoxBottomTemp.TabIndex = 5;
            // 
            // bottomStart
            // 
            this.bottomStart.Location = new System.Drawing.Point(12, 300);
            this.bottomStart.Name = "bottomStart";
            this.bottomStart.Size = new System.Drawing.Size(75, 23);
            this.bottomStart.TabIndex = 6;
            this.bottomStart.Text = "Старт";
            this.bottomStart.UseVisualStyleBackColor = true;
            this.bottomStart.Click += new System.EventHandler(this.bottomStart_Click);
            // 
            // bottomStop
            // 
            this.bottomStop.Location = new System.Drawing.Point(12, 346);
            this.bottomStop.Name = "bottomStop";
            this.bottomStop.Size = new System.Drawing.Size(75, 23);
            this.bottomStop.TabIndex = 7;
            this.bottomStop.Text = "Стоп";
            this.bottomStop.UseVisualStyleBackColor = true;
            this.bottomStop.Click += new System.EventHandler(this.bottomStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 169);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Заданная температатура низ";
            // 
            // textBox_setPoint_bt
            // 
            this.textBox_setPoint_bt.Location = new System.Drawing.Point(12, 197);
            this.textBox_setPoint_bt.Name = "textBox_setPoint_bt";
            this.textBox_setPoint_bt.Size = new System.Drawing.Size(100, 22);
            this.textBox_setPoint_bt.TabIndex = 10;
            this.textBox_setPoint_bt.Text = "100";
            // 
            // btn_Save_senPoint_bt
            // 
            this.btn_Save_senPoint_bt.Location = new System.Drawing.Point(118, 197);
            this.btn_Save_senPoint_bt.Name = "btn_Save_senPoint_bt";
            this.btn_Save_senPoint_bt.Size = new System.Drawing.Size(99, 23);
            this.btn_Save_senPoint_bt.TabIndex = 11;
            this.btn_Save_senPoint_bt.Text = "Сохранить";
            this.btn_Save_senPoint_bt.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 707);
            this.Controls.Add(this.btn_Save_senPoint_bt);
            this.Controls.Add(this.textBox_setPoint_bt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bottomStop);
            this.Controls.Add(this.bottomStart);
            this.Controls.Add(this.textBoxBottomTemp);
            this.Controls.Add(this.textBoxBottomLable);
            this.Controls.Add(this.ButtonPortsUpdate);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button ButtonPortsUpdate;
        private System.Windows.Forms.TextBox textBoxBottomLable;
        private System.Windows.Forms.TextBox textBoxBottomTemp;
        private System.Windows.Forms.Button bottomStart;
        private System.Windows.Forms.Button bottomStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_setPoint_bt;
        private System.Windows.Forms.Button btn_Save_senPoint_bt;
    }
}

