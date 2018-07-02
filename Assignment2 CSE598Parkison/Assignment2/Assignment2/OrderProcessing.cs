using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //delegate for order confirmation event
    public delegate void OrderConfirmationEvent(string name, string confirmation);

    class OrderProcessing
    {
        //order confirmation event
        public static event OrderConfirmationEvent OrderConfirmation;

        private string threadName;
        private int cardNo, amount, unitPrice;
        private double taxRate = .08;
        private Object lockProcess = new Object();
        //main method for threads
        //order processing
        public void runProcessing(string order, int unitPrice)
        {
            //lock order processing functionality
            lock (lockProcess)
            {
                //split comma separated data into strings and parse ints
                string[] splitter = order.Split(',');
                this.threadName = splitter[0].Trim();
                this.cardNo = Int32.Parse(splitter[1].Trim());
                this.amount = Int32.Parse(splitter[2].Trim());
                this.unitPrice = unitPrice;
                //verify credit card is the appropriate length of 8 numbers
                //print message if card fails verification.
                //card failure is built in with conversion between string and int
                if (!verifyCard(cardNo))
                {
                    Console.WriteLine("Credit Card -{0}- is invalid for {1}.", cardNo, threadName);
                    return;
                }
                //send order confirmation event
                OrderConfirmation(threadName, confirm());
            }
        }
        //verify credit card
        private bool verifyCard(int cardNo)
        {
            //check length
            bool result = false;
            if (cardNo.ToString().Length == 8)
            {
                result = true;
            }
            return result;
        }
        //calculate 8% tax on line total
        private double calcTaxAmt()
        {
            return (amount * unitPrice) * taxRate;
        }
        //calculate shipping
        private int calcShipping()
        {
            int shipping;
            if (amount <= 15)
            {
                shipping = 10;
            }
            else
            {
                shipping = 20;
            }
            return shipping;
        }
        //order conformation print out 
        private string confirm()
        {
            StringBuilder builder = new StringBuilder();
            string result;
            double lineTotal = (amount * unitPrice);
            double total = (amount * unitPrice) + calcTaxAmt() + calcShipping();
            builder.Append("\nConfirmation for: ");
            builder.Append(threadName + "\n");
            builder.Append("\t Line Item " + amount + " chickens @ $" + unitPrice + "\n");
            builder.Append("\t Line Total $" + lineTotal + "\n");
            builder.Append("\t Tax $" + calcTaxAmt() + "\n");
            builder.Append("\t Shipping $" + calcShipping() + "\n");
            builder.Append("\t Total $" + total + "\n");
            result = builder.ToString();
            return result;
        }       
    }
}
