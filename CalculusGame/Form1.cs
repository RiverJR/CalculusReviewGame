using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculusGame {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnPractice_Click(object sender , EventArgs e) {
            Form practice = new Practice(this);
            this.Hide();
            practice.Show();
        }
    }
}
