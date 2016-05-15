using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Practice : Form {
        private static readonly string[] SUPERSCRIPTS = new string[] { "\x2070", "\x00b9", "\x00b2", "\x00b3", "\x2074", "\x2075", "\x2076", "\x2077", "\x2078", "\x2079" };

        Form startmenu;
        Random rnd = new Random();
        int exponent;
        int frontNum;
        int incorrect;
        int correct;

        public Practice(Form startmenu) {
            InitializeComponent();
            this.startmenu = startmenu;
        }

        private void Practice_Load(object sender, EventArgs e) {
            incorrect = 0;
            correct = 0;
            generateProblem();
        }

        private bool isCorrect() { //checks if correct and lots of syntax exceptions.
            int frontDNum = exponent * frontNum;
            int dExponent = (exponent - 1);
            if (dExponent == 0) {
                textBox2.Text = frontDNum.ToString();
            }else if (dExponent == 1) {
                textBox2.Text = frontDNum + "x";
            }else
            textBox2.Text = frontDNum.ToString() + "x" + toSuperscript(dExponent);
            if (frontDNum == 0 && textBox3.Text == "0") {
                return true;
            }
            else if (exponent == 0 && textBox3.Text == "0") {
                return true;
            }
            else if (exponent == 1 && textBox3.Text == frontDNum.ToString()) {
                return true;
            }
            else if (exponent == 2 && textBox3.Text == frontDNum + "x") {
                return true;
            }
            else if (textBox3.Text == frontDNum + "x^" + dExponent) {
                return true;
            }
            return false;
        }

        private void generateProblem() { //Generates random problems
            textBox2.Clear();
            exponent = rnd.Next(-8, 8);
            frontNum = rnd.Next(-12, 15);
            if (exponent == 0 && frontNum == 1) {
                textBox1.Text = "0";
            }
            else if (exponent == 0) {
                textBox1.Text = frontNum.ToString();
            }
            else if (frontNum == 1) {
                textBox1.Text = "x" + toSuperscript(exponent);
            }
            else
                textBox1.Text = frontNum + "x" + toSuperscript(exponent);
        }

        private string toSuperscript(int exponent) { // creates superscript unicodes
            if (exponent == 1) {
                return "";
            }
            bool neg = exponent < 0; //207b for negative superscript
            exponent = Math.Abs(exponent);
            if (neg) {
                return "\x207b" + SUPERSCRIPTS[exponent];
            }
            return SUPERSCRIPTS[exponent];
        }

        private void setMessage(string message) { //Shows problem status message
            lblMessage.Text = message;
            lblMessage.Show();
        }
        private void hideMessage() { //Hides problem status message
            lblMessage.Text = "";
            lblMessage.Hide();
        }

        private void checkAnswer_Click(object sender, EventArgs e) { //Checks Answer and works counter
            textBox3.Text = textBox3.Text.Trim();
            if (isCorrect()) {
                setMessage("Correct");
                correct++;
            }
            else {
                setMessage("You stupit.");
                incorrect++;
            }
            lblCounter.Show();
            lblCounter.Text = string.Format("{0} / {1}", correct, correct + incorrect);
            btnCheckAnswer.Enabled = false;
            btnNewProb.Enabled = true;
        }

        private void btnNewProb_Click(object sender, EventArgs e) { 
            textBox3.Clear();
            btnCheckAnswer.Enabled = true;
            btnNewProb.Enabled = false;
            hideMessage();
            generateProblem();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            label3.Visible = false;
        }

        private void Practice_FormClosed(object sender, FormClosedEventArgs e) {
            startmenu.Show();
        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
