using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flashcard flashcard = new Flashcard(this);
            flashcard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Practice practice   = new Practice(this);
            practice.Show();

        }
    }
}
