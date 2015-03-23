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

namespace Shrimp_Reader {
    public partial class Form1 : Form {

        private SerialPort myport;
        private DateTime datetime;
        private string in_data;

        public Form1() {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e) {
            var ports = SerialPort.GetPortNames();
            port_name_cb.DataSource = ports;
        }

        private void Form1_Click(object sender, EventArgs e) {

        }

        private void start_btn_Click(object sender, EventArgs e) {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = port_name_cb.SelectedItem.ToString();
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += myport_DataReceived;
            try {
                myport.Open();
                data_tb.Text = "";
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        void myport_DataReceived(object sender, SerialDataReceivedEventArgs e) {
           
           in_data = myport.ReadLine();

           this.Invoke(new EventHandler(displaydata_event));
        }

        private void displaydata_event(object sender, EventArgs e) {
           datetime = DateTime.Now; 
            string time = datetime.Hour + ":"+datetime.Minute+":"+datetime.Second;
            data_tb.AppendText(time + "\t\t\t" + in_data + "\n");
        }

        private void stop_btn_click(object sender, EventArgs e) {
            try {
                myport.Close();
            } catch (Exception ex2) {
                MessageBox.Show(ex2.Message, "Error");
            }
        }
    }
}
