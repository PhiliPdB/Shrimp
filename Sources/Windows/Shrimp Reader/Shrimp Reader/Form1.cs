using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Shrimp_Reader
{
    public partial class Form1 : Form
    {
        private SerialPort myport;
        private DateTime datetime;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.portname = port_name_tb.Text;
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += myport_DataReceived;
            try{
                myport.Open();
                data_tb.Text = "";
            }
                catch(Exception ex){
                    MessageBox.Show(ex.Message,"Error");
                }
        }

        void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            datetime = DateTime.Now;

            string time = datetime.Hour + ":"+datetime.Minute+":"+datetime.Second;
            string in_data = myport.ReadLine();
            data_tb.Text = time+"\t\t\t\t\tt"+in_data;

        }
    }
}
