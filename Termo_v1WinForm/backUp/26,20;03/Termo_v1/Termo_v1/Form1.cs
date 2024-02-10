using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Termo_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;

            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.ChartAreas[0].AxisY.Minimum = 0;

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            chart.Series[0].XValueType = ChartValueType.DateTime;

            chart.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisX.Interval = 1;

            chart.Series[0].Points.AddXY(DateTime.Now, 50);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //DateTime timeNow = DateTime.Now;
            //chart.Series[0].Points.AddXY(timeNow, 50);
        }
    }
}
