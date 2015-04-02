using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shrimp_Reader {
    public partial class Setup_Trip : Form {

        public Setup_Trip() {
            InitializeComponent();
            TravelDelay.Value = DateTime.Now;
        }

        private void setup_btn_Click(object sender, EventArgs e) {
            int time = decimal.ToInt32(Time_Hours.Value * 3600) + decimal.ToInt32(Time_Minutes.Value * 60);
            Shrimp_Reader.myport.WriteLine(time + "");

            DateTime now = DateTime.Now;
            TimeSpan delay = TravelDelay.Value.Subtract(now);
            
            Shrimp_Reader.myport.WriteLine(Convert.ToInt32(delay.TotalSeconds) + "");

            this.Close();
        }
    }
}
