using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class SearchTryIt : System.Web.UI.Page
    {      
        string endPoint = "http://webstrar50.fulton.asu.edu/page3/Service1.svc/search?query=";
        protected void Button1_Click(object sender, EventArgs e)
        {
            //use RESTful service to do BING websearch
            //puts results into a asp table and parses serialized string
            endPoint += TextBox1.Text;
            WebRequest request = HttpWebRequest.Create(endPoint);
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            int index = json.IndexOf(']');
            json = json.Remove(index);
            index = json.IndexOf('[');
            json = json.Substring(index + 1, json.Length - index - 1);
            json = json.Replace("\"", "");
            string[] array = json.Split(',');
            int rowCt = array.Length;
            int row;
            int colCt = 1;
            int col;
            for (row = 1; row <= rowCt; row++)
            {
                TableRow tableRow = new TableRow();
                Table1.Rows.Add(tableRow);
                for (col = 1; col <= colCt; col++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = array[row - 1];
                    tableRow.Cells.Add(cell);
                }
            }
        }
    }
}