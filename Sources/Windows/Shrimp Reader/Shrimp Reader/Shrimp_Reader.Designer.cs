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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shrimp_Reader));
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.Temp_Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.temperature_title = new System.Windows.Forms.Label();
            this.avg_humi = new System.Windows.Forms.Label();
            this.avg_temp_text = new System.Windows.Forms.Label();
            this.avg_temp = new System.Windows.Forms.Label();
            this.init_trip_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Temp_Graph)).BeginInit();
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
            this.stop_btn.Location = new System.Drawing.Point(264, 321);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(136, 45);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "Clear data";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_click);
            // 
            // Temp_Graph
            // 
            this.Temp_Graph.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.Temp_Graph.ChartAreas.Add(chartArea1);
            this.Temp_Graph.Location = new System.Drawing.Point(12, 45);
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
            // temperature_title
            // 
            this.temperature_title.AutoSize = true;
            this.temperature_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_title.Location = new System.Drawing.Point(12, 25);
            this.temperature_title.Name = "temperature_title";
            this.temperature_title.Size = new System.Drawing.Size(94, 17);
            this.temperature_title.TabIndex = 10;
            this.temperature_title.Text = "Temperature:";
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
            this.avg_temp_text.Location = new System.Drawing.Point(12, 265);
            this.avg_temp_text.Name = "avg_temp_text";
            this.avg_temp_text.Size = new System.Drawing.Size(65, 17);
            this.avg_temp_text.TabIndex = 13;
            this.avg_temp_text.Text = "Average:";
            // 
            // avg_temp
            // 
            this.avg_temp.AutoSize = true;
            this.avg_temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_temp.Location = new System.Drawing.Point(83, 265);
            this.avg_temp.Name = "avg_temp";
            this.avg_temp.Size = new System.Drawing.Size(0, 17);
            this.avg_temp.TabIndex = 14;
            // 
            // init_trip_btn
            // 
            this.init_trip_btn.Location = new System.Drawing.Point(61, 423);
            this.init_trip_btn.Name = "init_trip_btn";
            this.init_trip_btn.Size = new System.Drawing.Size(136, 45);
            this.init_trip_btn.TabIndex = 15;
            this.init_trip_btn.Text = "Setup trip data";
            this.init_trip_btn.UseVisualStyleBackColor = true;
            this.init_trip_btn.Click += new System.EventHandler(this.init_trip_btn_Click);
            // 
            // Shrimp_Reader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 574);
            this.Controls.Add(this.init_trip_btn);
            this.Controls.Add(this.avg_temp);
            this.Controls.Add(this.avg_temp_text);
            this.Controls.Add(this.avg_humi);
            this.Controls.Add(this.temperature_title);
            this.Controls.Add(this.Temp_Graph);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Shrimp_Reader";
            this.Text = "Shrimp Reader";
            ((System.ComponentModel.ISupportInitialize)(this.Temp_Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.DataVisualization.Charting.Chart Temp_Graph;
        private System.Windows.Forms.Label temperature_title;
        private System.Windows.Forms.Label avg_humi;
        private System.Windows.Forms.Label avg_temp_text;
        private System.Windows.Forms.Label avg_temp;
        private System.Windows.Forms.Button init_trip_btn;
    }
}

