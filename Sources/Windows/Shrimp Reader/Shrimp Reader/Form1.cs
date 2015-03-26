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
using System.IO;

namespace Shrimp_Reader {
    public partial class Form1 : Form {

        private SerialPort myport;      // Serial port
        private string in_data;         // Data in save string
        private static string port;     // Serial port name

        public Form1() {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e) {
            Select_Port();
        }

        private void Select_Port() {
            // Ask the port of the arduino
            port = PromptPort.ShowDialog("Please select a port", "Port");
            // Configure serial port
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = port;
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += myport_DataReceived;
            try {
                myport.Open();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Form1_Click(object sender, EventArgs e) {

        }

        private void start_btn_Click(object sender, EventArgs e) {
            if (!myport.IsOpen) {
                try {
                    myport.Open();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            try {
                myport.WriteLine("viewData");
                data_tb.Text = "";
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Error");
                port = PromptPort.ShowDialog("Please select a port", "Port");
            }
        }

        void myport_DataReceived(object sender, SerialDataReceivedEventArgs e) {
           
           in_data = myport.ReadLine();

           this.Invoke(new EventHandler(displaydata_event));
        }

        private void displaydata_event(object sender, EventArgs e) {
            data_tb.AppendText(in_data + "\n");
        }

        private void stop_btn_click(object sender, EventArgs e) {
            try {
                myport.Close();
            } catch (Exception ex2) {
                MessageBox.Show(ex2.Message, "Error");
            }
        }

        private void save_btn_Click(object sender, EventArgs e) {
            Stream fileStream;
            // Configure save file dialog box
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "ShrimpData"; // Default file name
            sfd.DefaultExt = ".txt"; // Default file extension
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // Filter files by extension
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            // Show save file dialog box
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = sfd.OpenFile()) != null)
                {
                    // Code to convert the textbox to bytes.
                    byte[] byteArray = Encoding.UTF8.GetBytes(data_tb.Text);
                    MemoryStream data = new MemoryStream(byteArray);

                    // Code to save the file.
                    data.Position = 0;
                    data.WriteTo(fileStream);
                    fileStream.Close();
                }
            }
        }

        // Prompt for port dialog
        public static class PromptPort {
            public static string ShowDialog(string text, string caption) {
                Form prompt = new Form();
                prompt.Width = 300;
                prompt.Height = 150;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = caption;
                prompt.StartPosition = FormStartPosition.CenterScreen;
                // Design elements
                Label textLabel = new Label() { Left = 25, Top = 20, Text = text };
                ComboBox comboBox = new ComboBox() { Left = 125, Top = 20, Width = 136 };
                Button confirmation = new Button() { Text = "Ok", Left = 161, Width = 100, Top = 70 };
                Button exit = new Button() { Text = "Exit", Left = 25, Width = 100, Top = 70 };
                // Set click events
                confirmation.Click += (sender, e) => {
                    prompt.Close();
                    if (comboBox.Text.ToString() == "") port = PromptPort.ShowDialog("Please select a port", "Port"); ;
                };
                exit.Click += (sender, e) => { Application.Exit(); };
                // Load all available ports
                var ports = SerialPort.GetPortNames();
                comboBox.DataSource = ports;
                // Add the objects
                prompt.Controls.Add(comboBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(exit);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.CancelButton = exit;
                prompt.ControlBox = false;
                prompt.ShowDialog();

                return comboBox.Text.ToString(); // Return the name of the selected port
            }
        }
    }
}
