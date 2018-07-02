using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WnForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            int val = 0;
            if (Int32.TryParse(textBox2.Text, out val))
            {
                val = Convert.ToInt32(textBox2.Text);
            }
            ServiceReference.Service1Client myPxy = new ServiceReference.Service1Client();
            this.textBox2.Text = myPxy.c2f(val).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int val = 0;
            if (Int32.TryParse(textBox3.Text, out val))
            {
                val = Convert.ToInt32(textBox3.Text);
            }
            ServiceReference.Service1Client myPxy = new ServiceReference.Service1Client();
            this.textBox3.Text = myPxy.f2c(val).ToString();
        }
    }
}
