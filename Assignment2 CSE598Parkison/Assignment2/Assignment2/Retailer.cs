using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    class Retailer
    {
        private int currentPrice, newPrice;
        private bool priceCut, keepAlive = true;
        private DateTime orderTime;
        Random rand = new Random();
        ChickenFarm chicken = new ChickenFarm();
        MultiCellBuffer buffer = new MultiCellBuffer();
        Object processLock = new Object();
        //main retailer method
        public void runRetailer()
        {      
            //keeps retailer threads alive while farmer thread is alive
            while (keepAlive)
            {
                //check if price cut event
                if (priceCut)
                {
                    //get lock on working code
                    //lock (processLock)
                    //{
                        //calculate number of chickens to buy
                        int amount = chickensToBuy(newPrice);
                        //create new order
                        OrderClass order = new OrderClass(Thread.CurrentThread.Name, generateCardNumber(), amount);
                        //storge order timestamp
                        orderTime = DateTime.Now;
                        //send order to buffer
                        buffer.setOneCell(encoder(order));   
                        //print order placed message
                        Console.WriteLine(Thread.CurrentThread.Name + " placed order for " + amount +
                            " chickens @ $" + newPrice);
                        //give a little extra time for order confirmation event to occur
                        Thread.Sleep(50);
                        //turn off price cut event to stop continuos ordering
                        priceCut = false;                        
                    //}
                }
            }        
        }
        //price cut event method
        //set new chicken farm price
        //turn on price cut flag
        public void chickenOnSale(int newPrice)
        {          
            this.newPrice = newPrice;            
            currentPrice = newPrice;
            priceCut = true;
        }
        //encode order data
        private string encoder(OrderClass order)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(order.ToString()));
        }
        //calculate number of chickens to buy based on price difference
        private int chickensToBuy(int price)
        {
            int quantity;
            int priceDifference = price - currentPrice;

            if (priceDifference < 2)
            {
                quantity = rand.Next(1, 15);
            }
            else
            {
                quantity = rand.Next(16, 30);
            }
            return quantity;
        }
        //credit card generator
        //credit cards starting with zero will fail verification tests in order processing thread
        //this is by design
        private int generateCardNumber()
        {
            string cardNo = null;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                cardNo = builder.Append(rand.Next(0,9).ToString()).ToString();               
            }
            return Int32.Parse(cardNo);
        }
        //order confirmation event method
        //gets confirmation received time and calculates date diff.
        //prints formated order confirmation
        public void confirmation(string name, string confirmation)
        {
                DateTime receivedTime = DateTime.Now;
                TimeSpan diff = receivedTime - orderTime;
                Console.WriteLine("Order confirmation for " + name + " returned in " + diff);
                Console.WriteLine(confirmation);
        }
        //stops retailer threads when farmer fires 10 price cut event
        public void destroyThreads()
        {
            keepAlive = false;
        }
    }
}
