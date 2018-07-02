using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Web.Services;
using System.Web.Script.Services;
using Accounts;

namespace Assignment5
{

    public partial class Register : Page
    {
        private const string imageLength = "5";
        private const string Uri = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";
        protected void Page_Load(object sender, EventArgs e)
        {
            //generate new image string and image if the session doesnt have an active one already
            if (Session["imageString"] == null)
            {
                //use ASU service to get image and string
                ImageVerifier.ServiceClient proxy = new ImageVerifier.ServiceClient();
                Session["imageString"] = proxy.GetVerifierString(imageLength);
                Image1.ImageUrl = Uri + Session["imageString"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Submit data to server. Check if account already exists, if not, save the new account
            //and update Session object. Redirects to member page.
            string imageString = Session["imageString"].ToString();
            if (imageString.Equals(TextBox4.Text))
            {
                EncryptionService.Service1Client proxy = new EncryptionService.Service1Client();
                Account account = new Account(proxy.encrypt(TextBox1.Text), proxy.encrypt(TextBox5.Text), 
                    proxy.encrypt(TextBox6.Text), proxy.encrypt(TextBox7.Text));
                if (!(account.find()))
                {
                    account.saveAccount();

                    if (Session["memberLoggedIn"] == null)
                    {
                        Session["memberLoggedIn"] = true;
                        Session["email"] = proxy.encrypt(TextBox5.Text);
                        Response.Redirect("Member.aspx", false);
                    }                        
                }
                else
                {
                    //alert user if duplicat email/account
                    ClientScript.RegisterStartupScript(this.GetType(), "duplicateAccount", "duplicateAccount()", true);
                }
            }
            else
            {
                //alert user that image string failed
                TextBox4.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "failed", "failed()", true);
                //use ASU service to get image and string
                ImageVerifier.ServiceClient proxy = new ImageVerifier.ServiceClient();
                Session["imageString"] = proxy.GetVerifierString(imageLength);
                Image1.ImageUrl = Uri + Session["imageString"].ToString();
            }
        }
    }
}