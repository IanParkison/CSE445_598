using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    //delegates
    public delegate void priceCutEvent(int price);
    public delegate void destroyThreadsEvent();

    class ChickenFarm
    {
        //events
        public static event priceCutEvent priceCut;
        public static event destroyThreadsEvent destroyThreads;

        static Random rand = new Random();
        MultiCellBuffer buffer = new MultiCellBuffer();
        OrderProcessing processer = new OrderProcessing();

        private static int chickenPrice = 10;
        //counter to stop threads after 10 price cuts
        private static int saleCounter = 0;
        //determine if price cut has occured
        //announce price cut event
        //get and decode orders from all 5 retailers from buffer
        private void changePrice(int price)
        {
            if (price < chickenPrice)
            {
                if (priceCut != null)
                {
                    priceCut(price);
                    saleCounter++;
                    Console.WriteLine("\nChickens Are On Sale for $" + price + "!\n");
                } 
                for (int i = 0; i < 5; i++)
                {
                    string order = decoder(buffer.getOneCell());
                    //start order processors as separate threads
                    Thread process = new Thread(() => processer.runProcessing(order, price));
                    process.Start();
                }                
            }
            //store latest chicken price for comparison against next price change
            chickenPrice = price;
        }
        //main farmer method
        //generates new prices every 500 miliseconds
        //keeps track of progress towards 10 price cuts
        //announces destroy retailer thread event
        public void runFarmer()
        {
            while(true)
            {
                Thread.Sleep(500);
                int p = pricingModel();
                changePrice(p);
                if (saleCounter == 10)
                {
                    destroyThreads();
                    return;
                }
            }
        }
        //decoder method to decode order
        private string decoder(string order)
        {   
            return Encoding.UTF8.GetString(Convert.FromBase64String(order));
        }
        //pricing model to generate prices for chickens
        //uses random generation
        private int pricingModel()
        {
            return rand.Next(5, 20);
        }
    }
}
