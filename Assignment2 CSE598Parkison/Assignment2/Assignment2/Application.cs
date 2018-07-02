using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    class Application
    {       
        static void Main(string[] args)
        {
            ChickenFarm chicken = new ChickenFarm();
            MultiCellBuffer buffer = new MultiCellBuffer();
            OrderProcessing processor = new OrderProcessing();
            //Names of threads that represent retailers
            string[] retailerNames = { "Bob's Chickens", "Chickens R Us", "Turkey Jerky",  
                "JamJam inc", "Enterprise Chickens"};
            Thread farmer = new Thread(new ThreadStart(chicken.runFarmer));
            farmer.Start();
            Retailer chickenstore = new Retailer();
            //retailers subscribe to price cut event
            ChickenFarm.priceCut += new priceCutEvent(chickenstore.chickenOnSale);
            //retailer threads subscribe to farmer thread termination event to stop retailer threads
            ChickenFarm.destroyThreads += new destroyThreadsEvent(chickenstore.destroyThreads); 
            //retailer subscribes to order confirmation event
            OrderProcessing.OrderConfirmation += new OrderConfirmationEvent(chickenstore.confirmation);
            //start retailer threads and assign names
            Thread[] retailers = new Thread[5]; 
            for (int i = 0; i < 5; i++)
            {
                retailers[i] = new Thread(new ThreadStart(chickenstore.runRetailer));
                retailers[i].Name = retailerNames[i];
                retailers[i].Start();
            }
            //release semaphore to allow threads access to the buffer
            buffer.releaseSemaphore();
            //hold console open after completion
            Console.Read();
        }
    }
}
