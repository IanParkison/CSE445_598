using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class ImageVerifyTryIt : System.Web.UI.Page
    {
        private const string imageLength = "5";
        private const string Uri = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";
        protected void Page_Load(object sender, EventArgs e)
        {
            //generate new image string and image if the session doesnt have an active one already
            if (Session["imageStringTryIt"] == null)
            {
                //use ASU service to get image and string
                ImageVerifier.ServiceClient proxy = new ImageVerifier.ServiceClient();
                Session["imageStringTryIt"] = proxy.GetVerifierString(imageLength);
                Image1.ImageUrl = Uri + Session["imageStringTryIt"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string imageString = Session["imageStringTryIt"].ToString();
            if (imageString.Equals(TextBox1.Text))
            {
                //String matched
                //use ASU service to get image and string
                Label1.Text = "Correct!";
                TextBox1.Text = "";
                ImageVerifier.ServiceClient proxy = new ImageVerifier.ServiceClient();
                Session["imageStringTryIt"] = proxy.GetVerifierString(imageLength);
                Image1.ImageUrl = Uri + Session["imageStringTryIt"].ToString();
            }
            else
            {
                //label tells user attempt failed
                TextBox1.Text = "";
                Label1.Text = "Incorrect!";
                ImageVerifier.ServiceClient proxy = new ImageVerifier.ServiceClient();
                Session["imageStringTryIt"] = proxy.GetVerifierString(imageLength);
                Image1.ImageUrl = Uri + Session["imageStringTryIt"].ToString();
            }
        }
    }
}