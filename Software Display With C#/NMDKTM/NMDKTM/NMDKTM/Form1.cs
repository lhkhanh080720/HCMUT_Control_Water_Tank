using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;         //import export port computer
using System.IO.Ports;   //import export port computer
using ZedGraph;

namespace NMDKTM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int TickStart, intMode = 1;
        string pause =  "9600" ;
        private void Connect_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") //errol 1: dont select com
            {
                MessageBox.Show("Select COM Port", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if(serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                Connect.Text = "CONNECT";
                Connect.BackColor = Color.Lime;
                comboBox1.Enabled = true;
            }
            else if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = int.Parse(pause);
                serialPort1.Open();
                Connect.Text = "DISCONNECT";
                Connect.BackColor = Color.Red;
                comboBox1.Enabled = false;
                Send_SP.Enabled = true;
            }       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;    //display name of Port in terminal
        }

        private void Form1_main(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // save the name of port

            foreach (string port in ports)               //name of port will send in combo box
            {
                comboBox1.Items.Add(port);
            }

            GraphPane mypanne = zedGraphControl1.GraphPane;
            mypanne.Title.Text = "Water Level Height";
            mypanne.XAxis.Title.Text = "Time (s)";
            mypanne.YAxis.Title.Text = "Height (cm)";

            RollingPointPairList list = new RollingPointPairList(60000);
            RollingPointPairList list1 = new RollingPointPairList(60000);
            LineItem curve = mypanne.AddCurve("SetPoint", list,Color.Red, SymbolType.None);
            LineItem curve1 = mypanne.AddCurve("Value", list1, Color.Blue, SymbolType.None);
            mypanne.XAxis.Scale.Min = 0;
            mypanne.XAxis.Scale.Max = 30;
            mypanne.XAxis.Scale.MinorStep = 1;
            mypanne.XAxis.Scale.MajorStep = 5;
            zedGraphControl1.AxisChange();
            TickStart = Environment.TickCount;
        }

        public void draw(string setpoint, string current)
        {
            double intsetpoint;
            double intcurrent;
            double.TryParse(setpoint, out intsetpoint);
            double.TryParse(current, out intcurrent);
            if (zedGraphControl1.GraphPane.CurveList.Count <= 0) return;
            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem curve1 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            if (curve == null) return;
            if (curve1 == null) return;
            IPointListEdit list = curve.Points as  IPointListEdit;
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            if (list == null) return;
            if (list1 == null) return;
            double time = (Environment.TickCount - TickStart) / 1000.0;
            list.Add(time, intsetpoint);
            list1.Add(time, intcurrent);
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                if (intMode == 1)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }
                else
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = 0;
                }
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        String data = "";
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data += serialPort1.ReadExisting();
            if (data.Length > 2)
            {
                Invoke(new MethodInvoker(() => draw(data,data )));
                data = "";
            }
        }

        private void PbMode_Click(object sender, EventArgs e)
        {
            if (PbMode.Text == "SROLL")
            {
                intMode = 1;
                PbMode.Text = "COMPACT";
            }
            else
            {
                intMode = 0;
                PbMode.Text = "SROLL";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //draw("100", "200");
        }

        private void SendSP(object sender, EventArgs e)
        {
            serialPort1.Write("#TEXT" + SetPoint.Text + "#\n");
        }
    }
}
