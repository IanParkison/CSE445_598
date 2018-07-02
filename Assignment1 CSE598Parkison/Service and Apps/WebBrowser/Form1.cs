using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e) //Browse top url
        {
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void btnEncrypt_Click(object sender, EventArgs e) //Encrypt onclick
        {            
            EncryptionService.ServiceClient proxy = new EncryptionService.ServiceClient();
            lblEncryptResult.Text = proxy.Encrypt(this.txtEncrypt.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e) //Decrypt onclick
        {
            EncryptionService.ServiceClient proxy = new EncryptionService.ServiceClient();
            lblDecrypt.Text = proxy.Decrypt(this.lblEncryptResult.Text);
        }

        private void btnClear_Click(object sender, EventArgs e) //Clear encryption fields
        {
            txtEncrypt.Clear();
            lblEncryptResult.Text = "";
            lblDecrypt.Text = "";
        }

        private void btnStockQuote_Click(object sender, EventArgs e) //Get stock quote
        {
            StockService.ServiceClient proxy = new StockService.ServiceClient();

            StringBuilder builder = new StringBuilder();
            string[] values = txtStockQuote.Text.Split(',');
            lblStockQuote.Text = ""; 
            foreach(var val in values)
            {
                builder.Append(val.Trim() + " $" + proxy.getStockquote(val.Trim()) + ", ");
            }
            lblStockQuote.Text = builder.Remove(builder.Length - 2, 2).ToString();
        }
    }
}
