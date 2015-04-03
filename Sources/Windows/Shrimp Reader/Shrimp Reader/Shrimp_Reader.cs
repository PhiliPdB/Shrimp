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
using System.Windows.Forms.DataVisualization.Charting;

namespace Shrimp_Reader {
    public partial class Shrimp_Reader : Form {

        private Form setup_trip = new Setup_Trip();
        public static SerialPort myport;                    // Serial port
        private string in_data;                             // Data in save string
        private string data;                                // in_data string without the \r
        private static string port;                         // Serial port name
        private List<int> temperature = new List<int>();    // Temperatures over time
        private List<int> humidity = new List<int>();       // Humidities over time

        private bool tempStarted = false;                   // If temp logging is started the boolean is true
        private bool humiStarted = false;                   // Same as above, but for humidity
        private bool tempLogging = false;
        private bool humiLogging = false;

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public Shrimp_Reader() {
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
                getData();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Error");
                port = PromptPort.ShowDialog("Please select a port", "Port");
            }
        }

        public void getData() {
            Temp_Graph.Series["Series1"].Points.Clear();
            Humidity_Graph.Series["Series1"].Points.Clear();
            temperature.Clear();
            humidity.Clear();

            humiLogging = true;
            myport.WriteLine("viewHumi");
            myport.WriteLine("viewTemp");
            myport.WriteLine("viewAvgHumidity");
            myport.WriteLine("viewAvgTemp");
        }

        public void init_Temp_Graph() {
            for (int i = 0; i < temperature.Count; i++) {
                Temp_Graph.Series["Series1"].Points.AddXY(i, temperature[i]);
            }
        }
        
        void getTemp(object sender, EventArgs e) {
            if (data.Equals("End")) {
                tempStarted = false;
                tempLogging = false;
                init_Temp_Graph();
            }
            
            if (tempStarted && !humiStarted) temperature.Add(int.Parse(data));

            if (data.Equals("Start")) tempStarted = true;
        }

        public void init_Humi_Graph() {
            for (int i = 0; i < humidity.Count; i++) {
                Humidity_Graph.Series["Series1"].Points.AddXY(i, humidity[i]);
            }
        }

        void getHumi(object sender, EventArgs e) {
            if (data.Equals("End")) {
                humiStarted = false;
                humiLogging = false;
                tempLogging = true;
                init_Humi_Graph();
            }

            if (!tempStarted && humiStarted) humidity.Add(int.Parse(data));

            if (data.Equals("Start")) humiStarted = true;
        }

        void getAverages(object sender, EventArgs e) {
            if (data.Contains("avgHumi")) avg_humi.Text = data.Replace("avgHumi: ", "") + "%";
            if (data.Contains("avgTemp")) avg_temp.Text = data.Replace("avgTemp: ", "") + "°C";
        }

        void myport_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            
            in_data = myport.ReadLine();
            data = in_data.Replace("\r", "");
            
            // Displays what the Shrimp sends
            this.Invoke(new EventHandler(displaydata_event));
            // Initialize the graphs
            if (tempLogging && !humiLogging) this.Invoke(new EventHandler(getTemp));
            if (humiLogging && !tempLogging) this.Invoke(new EventHandler(getHumi));

            if (data.Contains("avg")) this.Invoke(new EventHandler(getAverages));
        }

        private void displaydata_event(object sender, EventArgs e) {
            data_tb.AppendText(in_data + "\n");
        }

        private void stop_btn_click(object sender, EventArgs e) {
            try {
                myport.WriteLine("clearData");
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

        private void init_trip_btn_Click(object sender, EventArgs e) {
            myport.WriteLine("setTravelTime");
            setup_trip.ShowDialog();
        }

        // Display label when hovering temperature graph
        void Temp_Graph_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = Temp_Graph.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results) {
                if (result.ChartElementType == ChartElementType.DataPoint) {
                    var prop = result.Object as DataPoint;
                    if (prop != null) {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2) {
                            tooltip.Show("X=" + prop.XValue + ", Temperature =" + prop.YValues[0] + "°C",
                                this.Temp_Graph, pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        // Display label when hovering humidity graph
        void Humidity_Graph_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = Humidity_Graph.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results) {
                if (result.ChartElementType == ChartElementType.DataPoint) {
                    var prop = result.Object as DataPoint;
                    if (prop != null) {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2) {
                            tooltip.Show("X=" + prop.XValue + ", Humidity =" + prop.YValues[0] + "%",
                                this.Humidity_Graph, pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
    }
}
