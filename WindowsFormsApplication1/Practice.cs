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
    public partial class Practice :Form {
        private static readonly string[] SUPERSCRIPTS = new string[] { "\x2070" , "\x00b9" , "\x00b2" , "\x00b3" , "\x2074" , "\x2075" , "\x2076" , "\x2077" , "\x2078" , "\x2079" };

        Form startmenu;
        Random rnd = new Random();
        int exponent;
        int chainExponent;
        int dExponent;
        int frontNum;
        int frontDNum;
        int chainNum;
        int incorrect;
        int correct;
        int difficulty;

        public Practice(Form startmenu) {
            InitializeComponent();
            this.startmenu = startmenu;
        }

        private void Practice_Load(object sender , EventArgs e) {
            incorrect = 0;
            correct = 0;
            generateProblem();
        }

        private bool checkSimpleDerivative() {

            if (dExponent == 0) {
                textBox2.Text = frontDNum.ToString();
            }
            if (dExponent == 1) {
                textBox2.Text = frontDNum + "x";
            } else {
                textBox2.Text = frontDNum + "x" + toSuperscript(dExponent);
            }
            if (frontDNum == 0 && textBox3.Text == "0") {
                return true;
            }
            if (exponent == 0 && textBox3.Text == "0") {
                return true;
            }
            if (exponent == 1 && textBox3.Text == frontDNum.ToString()) {
                return true;
            }
            if (exponent == 2 && textBox3.Text == frontDNum + "x") {
                return true;
            }
            if (textBox3.Text == frontDNum + "x^" + dExponent) {
                return true;
            }
            return false;
        }

        private bool checkChainRule() {
            int chaindExponent = chainExponent - 1;
            textBox2.Text = string.Format("{0}({1}x{2}+{3}){4}({5}x{6})" , chainExponent , frontNum , toSuperscript(exponent) , chainNum , toSuperscript(chaindExponent) , frontDNum , toSuperscript(dExponent));
            string chain = string.Format("{0}({1}x^{2}+{3})^{4}({5}x^{6})" , chainExponent , frontNum , exponent , chainNum , chaindExponent , frontDNum , dExponent);
            if (textBox3.Text == chain) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if correct and lots of syntax exceptions. shows correct answer as well.
        /// </summary>
        private bool isCorrect() {
            dExponent = (exponent - 1);
            frontDNum = exponent * frontNum;
            if (difficulty == 1) {
                return checkSimpleDerivative();
            } else if (difficulty == 2) { //TODO: ADD EXCEPTIONS
                return checkChainRule();
            }
            return false;
        }

        /// <summary>
        /// generates and displays simple derivative
        /// </summary>
        private void simpleDerivative() {
            if (exponent == 0 && frontNum == 1) {
                textBox1.Text = "0";
            } else if (exponent == 0) {
                textBox1.Text = frontNum.ToString();
            } else if (frontNum == 1) {
                textBox1.Text = "x" + toSuperscript(exponent);
            } else
                textBox1.Text = frontNum + "x" + toSuperscript(exponent);
        }

        /// <summary>
        /// generates and displays chain rule
        /// </summary>
        private void chainRule() {
            exponent = rnd.Next(2 , 9);
            chainNum = rnd.Next(1 , 99);
            chainExponent = rnd.Next(2 , 6);
            textBox1.Text = "(" + frontNum + "x" + toSuperscript(exponent) + " + " + chainNum + ")" + toSuperscript(chainExponent);
        }

        /// <summary>
        /// random problem parser
        /// </summary>
        private void generateProblem() {
            textBox2.Clear();
            difficulty = rnd.Next(1 , 3);
            exponent = rnd.Next(-8 , 8);
            frontNum = rnd.Next(-12 , 15);
            if (difficulty == 1) {
                simpleDerivative();
            } else if (difficulty == 2) {
                chainRule();
            }
        }

        /// <summary>
        /// Creates superscript unicodes
        /// </summary>
        private string toSuperscript(int exponent) {
            if (exponent == 1) {
                return "";
            }
            bool neg = exponent < 0;
            exponent = Math.Abs(exponent);
            if (neg) {
                return "\x207b" + SUPERSCRIPTS[exponent];
            }
            return SUPERSCRIPTS[exponent];
        }

        /// <summary>
        /// Shows problem status message
        /// </summary>
        private void setMessage(string message) {
            lblMessage.Text = message;
            lblMessage.Show();
        }

        /// <summary>
        /// Hides problem status message
        /// </summary>
        private void hideMessage() {
            lblMessage.Text = "";
            lblMessage.Hide();
        }

        /// <summary>
        /// Checks Answer and works counter
        /// </summary>
        private void checkAnswer_Click(object sender , EventArgs e) {
            textBox3.Text = textBox3.Text.Trim();
            textBox3.Text = textBox3.Text.Replace(" " , "");
            if (isCorrect()) {
                setMessage("Correct");
                correct++;
            } else {
                setMessage("You stupit.");
                incorrect++;
            }
            lblCounter.Show();
            lblCounter.Text = string.Format("{0} / {1}" , correct , correct + incorrect);
            btnCheckAnswer.Enabled = false;
            btnNewProb.Enabled = true;
            textBox3.Enabled = false;
        }

        private void btnNewProb_Click(object sender , EventArgs e) {
            textBox3.Clear();
            btnCheckAnswer.Enabled = true;
            btnNewProb.Enabled = false;
            btnCheckAnswer.Enabled = false;
            hideMessage();
            generateProblem();
            textBox3.Enabled = true;
        }
        private void listView1_SelectedIndexChanged(object sender , EventArgs e) {

        }
        private void textBox2_TextChanged(object sender , EventArgs e) { }
        private void textBox1_TextChanged(object sender , EventArgs e) {

        }
        private void textBox3_TextChanged(object sender , EventArgs e) {
            label3.Visible = false;
            btnCheckAnswer.Enabled = true;
        }
        private void Practice_FormClosed(object sender , FormClosedEventArgs e) {
            startmenu.Show();
        }
        private void label1_Click(object sender , EventArgs e) {

        }
    }
}