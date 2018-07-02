using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounts;

namespace Assignment5
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //State management with Session object
            if (Session["memberLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                //show user their subscription key
                Account account = new Account();
                Label1.Text = "Subscription Key: " + account.getSubKey(Session["email"].ToString());
            }            
        }
    }
}