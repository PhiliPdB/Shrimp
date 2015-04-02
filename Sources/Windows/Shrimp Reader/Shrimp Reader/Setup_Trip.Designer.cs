namespace Shrimp_Reader
{
    partial class Setup_Trip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Trip));
            this.cancel_btn = new System.Windows.Forms.Button();
            this.setup_btn = new System.Windows.Forms.Button();
            this.Question1 = new System.Windows.Forms.Label();
            this.Question2 = new System.Windows.Forms.Label();
            this.TravelDelay = new System.Windows.Forms.DateTimePicker();
            this.Time_Txt = new System.Windows.Forms.Label();
            this.Time_Hours = new System.Windows.Forms.NumericUpDown();
            this.Time_Minutes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Time_Hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Time_Minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(12, 216);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(119, 33);
            this.cancel_btn.TabIndex = 0;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // setup_btn
            // 
            this.setup_btn.Location = new System.Drawing.Point(162, 216);
            this.setup_btn.Name = "setup_btn";
            this.setup_btn.Size = new System.Drawing.Size(110, 33);
            this.setup_btn.TabIndex = 1;
            this.setup_btn.Text = "Setup";
            this.setup_btn.UseVisualStyleBackColor = true;
            this.setup_btn.Click += new System.EventHandler(this.setup_btn_Click);
            // 
            // Question1
            // 
            this.Question1.AutoSize = true;
            this.Question1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Question1.Location = new System.Drawing.Point(9, 9);
            this.Question1.Name = "Question1";
            this.Question1.Size = new System.Drawing.Size(243, 17);
            this.Question1.TabIndex = 5;
            this.Question1.Text = "How long takes the journey? (hh:mm)";
            // 
            // Question2
            // 
            this.Question2.AutoSize = true;
            this.Question2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Question2.Location = new System.Drawing.Point(9, 67);
            this.Question2.Name = "Question2";
            this.Question2.Size = new System.Drawing.Size(259, 17);
            this.Question2.TabIndex = 6;
            this.Question2.Text = "When do you want to start with logging?";
            // 
            // TravelDelay
            // 
            this.TravelDelay.CustomFormat = "MM-dd-yyyy HH:mm";
            this.TravelDelay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TravelDelay.Location = new System.Drawing.Point(124, 87);
            this.TravelDelay.Name = "TravelDelay";
            this.TravelDelay.Size = new System.Drawing.Size(148, 20);
            this.TravelDelay.TabIndex = 7;
            this.TravelDelay.Value = new System.DateTime(2015, 3, 31, 18, 37, 2, 0);
            // 
            // Time_Txt
            // 
            this.Time_Txt.AutoSize = true;
            this.Time_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Txt.Location = new System.Drawing.Point(211, 29);
            this.Time_Txt.Name = "Time_Txt";
            this.Time_Txt.Size = new System.Drawing.Size(12, 17);
            this.Time_Txt.TabIndex = 8;
            this.Time_Txt.Text = ":";
            // 
            // Time_Hours
            // 
            this.Time_Hours.Location = new System.Drawing.Point(162, 29);
            this.Time_Hours.Name = "Time_Hours";
            this.Time_Hours.Size = new System.Drawing.Size(43, 20);
            this.Time_Hours.TabIndex = 9;
            // 
            // Time_Minutes
            // 
            this.Time_Minutes.Location = new System.Drawing.Point(229, 29);
            this.Time_Minutes.Name = "Time_Minutes";
            this.Time_Minutes.Size = new System.Drawing.Size(43, 20);
            this.Time_Minutes.TabIndex = 10;
            // 
            // Setup_Trip
            // 
            this.AcceptButton = this.setup_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Time_Minutes);
            this.Controls.Add(this.Time_Hours);
            this.Controls.Add(this.Time_Txt);
            this.Controls.Add(this.TravelDelay);
            this.Controls.Add(this.Question2);
            this.Controls.Add(this.Question1);
            this.Controls.Add(this.setup_btn);
            this.Controls.Add(this.cancel_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setup_Trip";
            this.Text = "Setup Trip";
            ((System.ComponentModel.ISupportInitialize)(this.Time_Hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Time_Minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button setup_btn;
        private System.Windows.Forms.Label Question1;
        private System.Windows.Forms.Label Question2;
        private System.Windows.Forms.DateTimePicker TravelDelay;
        private System.Windows.Forms.Label Time_Txt;
        private System.Windows.Forms.NumericUpDown Time_Hours;
        private System.Windows.Forms.NumericUpDown Time_Minutes;
    }
}