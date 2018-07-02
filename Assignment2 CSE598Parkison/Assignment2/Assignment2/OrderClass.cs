using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class OrderClass
    {
        private string senderId;
        private int cardNo;
        private int amount;
        //constructor
        //no synchronization used because the object is instantiated from within
        //a locked section of code
        public OrderClass(string senderId, int cardNo, int amount)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.amount = amount;
        }
        //three getter methods
        public string getSenderId()
        {
            return senderId;
        } 

        public int getCardNo()
        {
            return cardNo;
        }

        public int getAmount()
        {
            return amount;
        }
        //overridden ToString method to generate order string data
        //use comma separated string for easy splitting
        //cannot have commas in thread names
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(senderId + "," + cardNo + "," + amount);
            return builder.ToString();
        }
    }
}
