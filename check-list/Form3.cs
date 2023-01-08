using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace check_list
{
    public partial class Form3 : Form
    {
        public string D;
        public string N1;
        public bool N2;
        public Form3()
        {
            N2 = false;
            InitializeComponent();
            
            
        }

        private void button17_Click(Button button17, object value)
        {
            
        }

        private void Form3_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (N2)
            {
                N2= false;
                textBox1.Text = "0";
            }
            Button B = (Button)sender;
            if(textBox1.Text=="0")
                textBox1.Text = B.Text;
            else
            textBox1.Text=textBox1.Text+ B.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            double dn1, dn2, res;

            res = 0;
            dn1 = Convert.ToDouble(N1);
            dn2 = Convert.ToDouble(textBox1.Text);
            if(D=="+") 
            {
                res = dn1 + dn2;
            }
            if (D == "-")
            {
                res = dn1 - dn2;
            }
            if (D == "×")
            {
                res = dn1 * dn2;
            }
            if (D == "/")
            {
                res = dn1 / dn2;
            }
            if (D == "%")
            {
                res = dn1 * dn2 / 100;
            }

            D = "=";
            N2 = true;
            textBox1.Text = res.ToString();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }

        private void button20_Click(object sender, EventArgs e)
        {

            Button B = (Button)sender;
            D = B.Text;
            N1 = textBox1.Text;
            N2 = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double dn, res;
            dn = Convert.ToDouble(textBox1.Text);
            res = Math.Sqrt(dn);
            textBox1.Text = res.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double dn, res;
            dn = Convert.ToDouble(textBox1.Text);
            res = Math.Pow(dn, 2);
            textBox1.Text = res.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double dn, res;
            dn = Convert.ToDouble(textBox1.Text);
            res = 1/dn;
            textBox1.Text = res.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            double dn, res;
            dn = Convert.ToDouble(textBox1.Text);
            res = -dn;
            textBox1.Text = res.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if(!textBox1.Text.Contains(",")) 
            textBox1.Text = textBox1.Text + ",";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0,textBox1.Text.Length - 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void button17_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue ==(char)Keys.NumPad1)
            {
                button17_Click(button17, null);
            }
        }

        private void button20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Oemplus)
            {
                button20_Click(button20, null);
            }
        }
    }
}
