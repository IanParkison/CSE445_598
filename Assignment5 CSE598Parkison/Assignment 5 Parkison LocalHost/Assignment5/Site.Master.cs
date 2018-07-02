using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounts;

namespace Assignment5
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            //Manage session states after login
            //Assign session variables to specific roles after login
            //validate login
            Account account = new Account();
            EncryptionService.Service1Client proxy = new EncryptionService.Service1Client();
            if (account.validate(proxy.encrypt(TextBox1.Text), proxy.encrypt(TextBox2.Text)))
            {
                string role = account.getGroup(proxy.encrypt(TextBox1.Text));
                if (role == "Customer")
                {
                    Session["memberLoggedIn"] = true;
                    Session["email"] = proxy.encrypt(TextBox1.Text);
                    Response.Redirect("Member.aspx", false);
                }
                else if (role == "Staff1")
                {
                    Session["staff1LoggedIn"] = true;
                    Session["email"] = proxy.encrypt(TextBox1.Text);
                    Response.Redirect("Staff1.aspx", false);
                }
                else if (role == "Staff2")
                {
                    //Staff 2 has access to all groups
                    Session["staff1LoggedIn"] = true;
                    Session["staff2LoggedIn"] = true;
                    Session["memberLoggedIn"] = true;
                    Session["email"] = proxy.encrypt(TextBox1.Text);
                    Response.Redirect("Staff2.aspx", false);
                }                                                
            }
            else
            {
                Response.Write("<script>alert('Incorrect email or incorrect password. Have you registered yet?');</script>");
            }
        }
    }
}