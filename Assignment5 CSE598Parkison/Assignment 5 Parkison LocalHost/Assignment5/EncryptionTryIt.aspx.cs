using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class EncryptionTryIt : System.Web.UI.Page
    { 
        //calling methods from encryption service
        protected void Button1_Click(object sender, EventArgs e)
        {
            EncryptionService.Service1Client proxy = new EncryptionService.Service1Client();
            TextBox2.Text = proxy.encrypt(TextBox1.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EncryptionService.Service1Client proxy = new EncryptionService.Service1Client();
            TextBox4.Text = proxy.decrypt(TextBox3.Text);
        }
    }
}