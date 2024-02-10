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
            chart.MouseWheel += Chart_MouseWheel;
        }
        int _chartHeight = 100;
        int _charWidth = 60;
        int _chartXminimum = 0;
        int _chartYminimum = -10;
        string DataIN;
        string DateT;
        DateTime startDt;
        int moveCharX;
        int moveCharY;
        int mouseSensetive = 2;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Text = "";
            comboBoxPorts.Items.Clear();
            startDt = DateTime.Now;
            if(ports.Length != 0)
            {
                comboBoxPorts.Items.AddRange(ports);
                comboBoxPorts.SelectedIndex = 0;
            }

            timer.Enabled = true;

            chart.ChartAreas[0].AxisY.Interval = 5;
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart.ChartAreas[0].AxisX.Interval = 5;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            chart.Series[0].XValueType = ChartValueType.DateTime;

            reloadChart();
            chart.Series[0].Points.AddXY(DateTime.Now, 50);
        }
        int _countSeconds = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            _countSeconds++;
            if(_countSeconds >= _charWidth)
            {
                //MessageBox.Show("DateTimeOld");
                _countSeconds = 0;
                startDt = DateTime.Now;
                reloadChart() ;
            }
            //chart.Series[0].Points.AddXY(DateTime.Now, 50);
        }
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            moveCharX = e.X;
            moveCharY = e.Y;
        }
        int countMove = 0;
        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                countMove++;
                if (countMove >= mouseSensetive)
                {
                    if (e.X < moveCharX) { _chartXminimum++; _charWidth++; }
                    if (e.X > moveCharX) { _chartXminimum--; _charWidth--; }
                    if (e.Y > moveCharY) { _chartYminimum++; _chartHeight++; }
                    if (e.Y < moveCharY) { _chartYminimum--; _chartHeight--; }
                    //_chartXminimum -= (e.X  - moveCharX);
                    //_charWidth -= (e.X - moveCharX);
                    //_chartHeight += (e.Y - moveCharY);
                    //_chartYminimum += (e.Y - moveCharY);
                    moveCharX = e.X;
                    moveCharY = e.Y;
                    reloadChart();
                    countMove = 0;
                }
            }
        }
        private void Chart_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _chartHeight -= 3;
                _charWidth--;
                _chartXminimum++;
                _chartYminimum++;
            }
            else if (e.Delta < 0)
            {
                _chartHeight += 3;
                _charWidth++;
                _chartXminimum--;
                _chartYminimum--;
            }
            reloadChart();
        }
        private void reloadChart()
        {
            chart.ChartAreas[0].AxisY.Maximum = _chartHeight;
            chart.ChartAreas[0].AxisY.Minimum = _chartYminimum;

            chart.ChartAreas[0].AxisX.Minimum = startDt.AddSeconds(_chartXminimum).ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = startDt.AddSeconds(_charWidth).ToOADate();
            
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
            chart.Series[1].Points.AddXY(DateTime.Now, Convert.ToInt32(textBox_setPoint_bt.Text));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(serialPort.IsOpen) serialPort.Close();
        }

        private void bottomStart_Click(object sender, EventArgs e)
        {

        }

        private void bottomStop_Click(object sender, EventArgs e)
        {

        }
    }
}
