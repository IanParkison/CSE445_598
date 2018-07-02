using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ServiceProject
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Services.ServiceClient proxy = new Services.ServiceClient();
            string endPoint = proxy.Endpoint.Address.Uri.ToString();
            lblEndPoint.Text = endPoint;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string[] results;
            Services.ServiceClient proxy = new Services.ServiceClient();
            StringBuilder builder = new StringBuilder();
            txtResults.Text = String.Empty;
            string criteria = txtSearchBox.Text;
            //process array returned from service and print to UI
            if (!String.IsNullOrEmpty(criteria))
            {
                string displayText = null;
                results = proxy.WsdlDiscovery(criteria);
                foreach (string result in results)
                {
                    displayText = builder.Append(result + "\n").ToString();
                }
                txtResults.Text = displayText;

                if (String.IsNullOrEmpty(txtResults.Text))
                {
                    txtResults.Text = "No Results. Try adjusting your search.";
                }
            }
            else
            {
                txtResults.Text = "No Criteria...";
            }
        }

        protected void btnReturnWords_Click(object sender, EventArgs e)
        {
            string[] answer = null;
            string displayText = null;
            Services.ServiceClient proxy = new Services.ServiceClient();
            StringBuilder builder = new StringBuilder();
            txtWordResults.Text = String.Empty;
            string url = txtUrl.Text;
            //print array returned from service
            if (!String.IsNullOrEmpty(url))
            {
                try
                { 
                    answer = proxy.Top10Words(url);
                }
                catch (Exception)
                {
                    txtWordResults.Text = "There was an error with this url."; 
                }
            }
            else
            {
                txtWordResults.Text = "No URL...";
            }

            foreach (string result in answer)
            {
                displayText = builder.Append(result + "\n").ToString();
            }
            txtWordResults.Text = displayText;
        }        
    }
}