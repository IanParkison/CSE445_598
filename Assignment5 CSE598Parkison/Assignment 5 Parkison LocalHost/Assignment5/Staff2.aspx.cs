using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounts;

namespace Assignment5
{
    public partial class Staff2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //State manaegment with Session object
            if (Session["staff2LoggedIn"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                //asp table to show customer/user data for level 2 staff
                Account account = new Account();
                EncryptionService.Service1Client proxy = new EncryptionService.Service1Client();
                string[] emails = account.getallEmails();

                int rowCt = emails.Length;
                int row;
                int colCt = 6;
                int col;
                for (row = 1; row <= rowCt; row++)
                {
                    TableRow tableRow = new TableRow();
                    Table1.Rows.Add(tableRow);
                    for (col = 1; col <= colCt; col++)
                    {
                        TableCell cell = new TableCell();
                        if (col <= 4)
                        {
                            cell.Text = proxy.decrypt(account.getStaff2Data(emails[row - 1])[col - 1]);
                        }
                        else
                        {
                            cell.Text = account.getStaff2Data(emails[row - 1])[col - 1];
                        }                        
                        tableRow.Cells.Add(cell);
                    }
                }
            }
        }
    }
}