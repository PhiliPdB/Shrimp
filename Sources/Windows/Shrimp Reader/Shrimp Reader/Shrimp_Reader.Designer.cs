namespace Shrimp_Reader
{
    partial class Shrimp_Reader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shrimp_Reader));
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.data_tb = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.Label();
            this.Temp_Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Humidity_Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.humidity_title = new System.Windows.Forms.Label();
            this.temperature_title = new System.Windows.Forms.Label();
            this.avg_humi_text = new System.Windows.Forms.Label();
            this.avg_humi = new System.Windows.Forms.Label();
            this.avg_temp_text = new System.Windows.Forms.Label();
            this.avg_temp = new System.Windows.Forms.Label();
            this.init_trip_btn = new System.Windows.Forms.Button();
            this.command_input = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Temp_Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Humidity_Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(61, 321);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(136, 45);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "View data";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(61, 372);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(136, 45);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "Clear data";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(61, 423);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(136, 45);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Save Data";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Visible = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // data_tb
            // 
            this.data_tb.BackColor = System.Drawing.SystemColors.Window;
            this.data_tb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.data_tb.HideSelection = false;
            this.data_tb.Location = new System.Drawing.Point(530, 321);
            this.data_tb.Multiline = true;
            this.data_tb.Name = "data_tb";
            this.data_tb.ReadOnly = true;
            this.data_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data_tb.Size = new System.Drawing.Size(275, 212);
            this.data_tb.TabIndex = 3;
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(527, 305);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(39, 13);
            this.output.TabIndex = 6;
            this.output.Text = "Output";
            // 
            // Temp_Graph
            // 
            this.Temp_Graph.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.Temp_Graph.ChartAreas.Add(chartArea1);
            this.Temp_Graph.Location = new System.Drawing.Point(417, 45);
            this.Temp_Graph.Name = "Temp_Graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.Temp_Graph.Series.Add(series1);
            this.Temp_Graph.Size = new System.Drawing.Size(388, 217);
            this.Temp_Graph.TabIndex = 7;
            this.Temp_Graph.Text = "chart1";
            this.Temp_Graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Temp_Graph_MouseMove);
            // 
            // Humidity_Graph
            // 
            this.Humidity_Graph.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.Humidity_Graph.ChartAreas.Add(chartArea2);
            this.Humidity_Graph.Location = new System.Drawing.Point(12, 45);
            this.Humidity_Graph.Name = "Humidity_Graph";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.Humidity_Graph.Series.Add(series2);
            this.Humidity_Graph.Size = new System.Drawing.Size(399, 217);
            this.Humidity_Graph.TabIndex = 8;
            this.Humidity_Graph.Text = "chart1";
            this.Humidity_Graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Humidity_Graph_MouseMove);
            // 
            // humidity_title
            // 
            this.humidity_title.AutoSize = true;
            this.humidity_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humidity_title.Location = new System.Drawing.Point(12, 29);
            this.humidity_title.Name = "humidity_title";
            this.humidity_title.Size = new System.Drawing.Size(66, 17);
            this.humidity_title.TabIndex = 9;
            this.humidity_title.Text = "Humidity:";
            // 
            // temperature_title
            // 
            this.temperature_title.AutoSize = true;
            this.temperature_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_title.Location = new System.Drawing.Point(417, 29);
            this.temperature_title.Name = "temperature_title";
            this.temperature_title.Size = new System.Drawing.Size(94, 17);
            this.temperature_title.TabIndex = 10;
            this.temperature_title.Text = "Temperature:";
            // 
            // avg_humi_text
            // 
            this.avg_humi_text.AutoSize = true;
            this.avg_humi_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_humi_text.Location = new System.Drawing.Point(12, 265);
            this.avg_humi_text.Name = "avg_humi_text";
            this.avg_humi_text.Size = new System.Drawing.Size(65, 17);
            this.avg_humi_text.TabIndex = 11;
            this.avg_humi_text.Text = "Average:";
            // 
            // avg_humi
            // 
            this.avg_humi.AutoSize = true;
            this.avg_humi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_humi.Location = new System.Drawing.Point(83, 265);
            this.avg_humi.Name = "avg_humi";
            this.avg_humi.Size = new System.Drawing.Size(0, 17);
            this.avg_humi.TabIndex = 12;
            // 
            // avg_temp_text
            // 
            this.avg_temp_text.AutoSize = true;
            this.avg_temp_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_temp_text.Location = new System.Drawing.Point(417, 265);
            this.avg_temp_text.Name = "avg_temp_text";
            this.avg_temp_text.Size = new System.Drawing.Size(65, 17);
            this.avg_temp_text.TabIndex = 13;
            this.avg_temp_text.Text = "Average:";
            // 
            // avg_temp
            // 
            this.avg_temp.AutoSize = true;
            this.avg_temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_temp.Location = new System.Drawing.Point(488, 265);
            this.avg_temp.Name = "avg_temp";
            this.avg_temp.Size = new System.Drawing.Size(0, 17);
            this.avg_temp.TabIndex = 14;
            // 
            // init_trip_btn
            // 
            this.init_trip_btn.Location = new System.Drawing.Point(275, 321);
            this.init_trip_btn.Name = "init_trip_btn";
            this.init_trip_btn.Size = new System.Drawing.Size(136, 45);
            this.init_trip_btn.TabIndex = 15;
            this.init_trip_btn.Text = "Setup trip data";
            this.init_trip_btn.UseVisualStyleBackColor = true;
            this.init_trip_btn.Click += new System.EventHandler(this.init_trip_btn_Click);
            // 
            // command_input
            // 
            this.command_input.AcceptsReturn = true;
            this.command_input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.command_input.Location = new System.Drawing.Point(530, 542);
            this.command_input.Name = "command_input";
            this.command_input.Size = new System.Drawing.Size(275, 20);
            this.command_input.TabIndex = 16;
            this.command_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.command_input_KeyPress);
            // 
            // Shrimp_Reader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 574);
            this.Controls.Add(this.command_input);
            this.Controls.Add(this.init_trip_btn);
            this.Controls.Add(this.avg_temp);
            this.Controls.Add(this.avg_temp_text);
            this.Controls.Add(this.avg_humi);
            this.Controls.Add(this.avg_humi_text);
            this.Controls.Add(this.temperature_title);
            this.Controls.Add(this.humidity_title);
            this.Controls.Add(this.Humidity_Graph);
            this.Controls.Add(this.Temp_Graph);
            this.Controls.Add(this.output);
            this.Controls.Add(this.data_tb);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Shrimp_Reader";
            this.Text = "Shrimp Reader";
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Temp_Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Humidity_Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox data_tb;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.DataVisualization.Charting.Chart Temp_Graph;
        private System.Windows.Forms.DataVisualization.Charting.Chart Humidity_Graph;
        private System.Windows.Forms.Label humidity_title;
        private System.Windows.Forms.Label temperature_title;
        private System.Windows.Forms.Label avg_humi_text;
        private System.Windows.Forms.Label avg_humi;
        private System.Windows.Forms.Label avg_temp_text;
        private System.Windows.Forms.Label avg_temp;
        private System.Windows.Forms.Button init_trip_btn;
        private System.Windows.Forms.TextBox command_input;
    }
}

