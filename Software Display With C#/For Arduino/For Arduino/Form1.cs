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

namespace For_Arduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // save the name of port

            foreach(string port in ports)               //name of port will send in combo box
            {
                comboBox1.Items.Add(port);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;    //display name of Port in terminal
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    textBox1.BackColor = Color.Red; //when disconnect oke -> switch color form green to red
                    textBox1.Text = "Disconnected!";
                    comboBox1.Enabled = true;       //unlock COM Port

                }
                else
                {
                    MessageBox.Show("COM Port is connected and ready for use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM Port is not found. Please check your COM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") //errol 1: dont select com
            {
                MessageBox.Show("Select COM Port", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        MessageBox.Show("COM Port is connected and ready for use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        serialPort1.Open();
                        textBox1.BackColor = Color.Lime; //when connect oke -> switch color form red to green
                        textBox1.Text = "Connecting...";
                        comboBox1.Enabled = false;       //lock COM Port
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboB(object sender, ControlEventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;    //display name of Port in terminal
        }
    }
}
