using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            int val = 0;
            //Convert string input to int, default to zero if it cannot convert
            if (Int32.TryParse(txt1.Text, out val))
            {
                val = Convert.ToInt32(txt1.Text);
            }
            ServiceReference.Service1Client myPxy = new ServiceReference.Service1Client();
            this.txt1.Text = myPxy.c2f(val).ToString();
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            int val = 0;
            //Convert string input to int, default to zero if it cannot convert
            if (Int32.TryParse(txt2.Text, out val))
            {
                val = Convert.ToInt32(txt2.Text);
            }
            ServiceReference.Service1Client myPxy = new ServiceReference.Service1Client();
            this.txt2.Text = myPxy.f2c(val).ToString();
        }
    }
}