using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
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
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Text = "";
            comboBoxPorts.Items.Clear();
            if(ports.Length != 0)
            {
                comboBoxPorts.Items.AddRange(ports);
                comboBoxPorts.SelectedIndex = 0;
            }

            timer.Enabled = true;

            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.ChartAreas[0].AxisY.Minimum = -10;
            chart.ChartAreas[0].AxisY.Interval = 2;

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            chart.Series[0].XValueType = ChartValueType.DateTime;

            chart.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisX.Interval = 1;

            chart.Series[0].Points.AddXY(DateTime.Now, 50);
        }
        int _countSeconds = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            _countSeconds++;
            if(_countSeconds == 60)
            {
                _countSeconds = 0;
                chart.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                chart.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

                chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                chart.ChartAreas[0].AxisX.Interval = 1;
            }
            //DateTime timeNow = DateTime.Now;
            //chart.Series[0].Points.AddXY(timeNow, 50);
        }

        private void ConnectPort(object sender, EventArgs e)
        {
            if (buttonConnect.Text == "Подключится")
            {
                try
                {
                    serialPort.PortName = comboBoxPorts.Text;
                    serialPort.Open();
                    serialPort.ReadTimeout = 500;
                    buttonConnect.Text = "Отключится";
                    comboBoxPorts.Enabled = false;
                    ButtonPortsUpdate.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("ошибка подключения");
                }
            }
            else if(buttonConnect.Text == "Отключится")
            {
                serialPort.Close();
                buttonConnect.Text = "Подключится";
                comboBoxPorts.Enabled = true;
                ButtonPortsUpdate.Enabled = true;
                //chart.Series.Clear();
                chart.Series[0].Points.Clear();
            }
        }

        private void ButtonPortsUpdate_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Text = "";
            comboBoxPorts.Items.Clear();
            if (ports.Length != 0)
            {
                comboBoxPorts.Items.AddRange(ports);
                comboBoxPorts.SelectedIndex = 0;
            }
        }

        string DataIN;
        string DateT;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)//Получаем данные из порта
        {
            BeginInvoke(new EventHandler(ClearTxt));//Асинхронно
            DataIN = serialPort.ReadLine();
            BeginInvoke(new EventHandler(ShowData));
        }
        private void ShowData(object sender, EventArgs e)
        {
            DateT = DataIN;
            textBoxBottomTemp.Text = DateT;
        }
        private void ClearTxt(object sender, EventArgs e)
        {
            chart.Series[0].Points.AddXY(DateTime.Now, DateT);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(serialPort.IsOpen) serialPort.Close();
        }
    }
}
