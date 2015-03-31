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
    }
}
