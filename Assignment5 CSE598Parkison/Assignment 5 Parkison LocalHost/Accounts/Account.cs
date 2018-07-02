using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using System.Collections.Generic;

namespace Accounts
{
    public class Account
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string creditCardNumber { get; set; }
        public string subscriptionKey { get; set; }

        public Account()
        {

        }

        public Account(string name, string email, string password, string creditCardNumber)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.creditCardNumber = creditCardNumber;
        }

        public void saveAccount()
        {
            DataWriter.saveAccount(name, email, password, creditCardNumber, generateSubKey());
        }

        private string generateSubKey()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(email + Guid.NewGuid());
            return Convert.ToBase64String(bytes);
        }

        public string getSubKey(string email)
        {
            string subscriptionKey = null;
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                foreach (var child in element.Descendants("Email"))
                {
                    if (child.Value == email)
                    {
                        foreach (var child2 in element.Descendants("SubscriptionKey"))
                        {
                            subscriptionKey = child2.Value;
                        }
                    }
                }
            }
            return subscriptionKey;
        }

        public bool find()
        {
            return DataWriter.search(email);
        }

        public bool validate(string email, string password)
        {
            bool result = false;
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            List<string> list = new List<string>();
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                foreach (var child in element.Descendants("Email"))
                {
                    if (child.Value == email)
                    {
                        foreach (var child2 in element.Descendants("Password"))
                        {
                            if (child2.Value == password)
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public string getGroup(string email)
        {
            string result = null;
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            List<string> list = new List<string>();
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                foreach (var child in element.Descendants("Email"))
                {
                    if (child.Value == email)
                    {
                        foreach (var child2 in element.Descendants("Role"))
                        {
                            result = child2.Value;
                        }
                    }
                }
            }
            return result;
        }

        public string[] getallEmails()
        {
            List<string> list = new List<string>();
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                foreach (var child in element.Descendants("Email"))
                {
                    list.Add(child.Value);
                }
            }
            string[] result = list.ToArray();
            return result;
        }

        public string[] getStaff1Data(string email)
        {
            List<string> list = new List<string>();
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                if (element.Element("Email").Value == email)
                {
                    list.Add(element.Element("Name").Value);
                    list.Add(element.Element("SubscriptionKey").Value);
                }
            }
            string[] result = list.ToArray();
            return result;
        }

        public string[] getStaff2Data(string email)
        {
            List<string> list = new List<string>();
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                if (element.Element("Email").Value == email)
                {
                    list.Add(element.Element("Name").Value);
                    list.Add(element.Element("Email").Value);
                    list.Add(element.Element("Password").Value);
                    list.Add(element.Element("CreditCard").Value);
                    list.Add(element.Element("SubscriptionKey").Value);
                    list.Add(element.Element("Role").Value);
                }
            }
            string[] result = list.ToArray();
            return result;
        }
    }

    public static class DataWriter
    {
        private static object obj = new object();

        public static bool saveAccount(string name, string email, string password, string creditCardNumber, string key)
        {
            bool result = false;
            lock (obj)
            {
                XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
                XElement root = xmlDoc.Root;
                var accountList = xmlDoc.Descendants("Account").ToList();

                if (!(search(email)))
                {
                    XElement newAccount = new XElement("Account");
                    newAccount.Add(new XElement("Name", name));
                    newAccount.Add(new XElement("Email", email));
                    newAccount.Add(new XElement("Password", password));
                    newAccount.Add(new XElement("CreditCard", creditCardNumber));
                    newAccount.Add(new XElement("SubscriptionKey", key));
                    newAccount.Add(new XElement("Role", "Customer"));
                    root.Add(newAccount);
                    xmlDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
                    result = true;
                }
            }
            return result;
        }

        public static bool search(string email)
        {
            bool result = false;
            XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml"));
            List<string> list = new List<string>();
            foreach (var element in xmlDoc.Descendants("Account"))
            {
                foreach (var child in element.Descendants("Email"))
                {
                    if (child.Value == email)
                    {
                        list.Add(element.ToString());
                    }
                }
            }
            if (list.Count > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
