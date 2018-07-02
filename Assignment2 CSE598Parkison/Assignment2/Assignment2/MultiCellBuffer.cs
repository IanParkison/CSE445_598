using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2
{
    class MultiCellBuffer
    {
        //cells are separte objects to allow independent read/write and locks
        private static BufferCell bufferCell1 = new BufferCell();
        private static BufferCell bufferCell2 = new BufferCell();
        //semaphore object in closed initial state
        private static Semaphore cellPool = new Semaphore(0,2);
        private Random rand = new Random();
        //write data to cells
        public void setOneCell(string encodedOrder)
        {
            bool waitingForWrite = true;
            //keep threads alive while waiting for a lock/semaphore
            while (waitingForWrite)
            {
                //enter semaphore
                cellPool.WaitOne();
                //try to get exclusive lock on first cell
                if (Monitor.TryEnter(bufferCell1))
                {
                    //check if cell is still waiting to be read
                    if (bufferCell1.readWriteCell == null)
                    {
                        //write to cell
                        bufferCell1.readWriteCell = encodedOrder;
                        waitingForWrite = false;                       
                    }
                    //remove lock
                    Monitor.Exit(bufferCell1);
                }
                //if cannot lock first cell, try second cell
                else if (Monitor.TryEnter(bufferCell2))
                {
                    //check if cell is is still waiting to be read
                    if (bufferCell2.readWriteCell == null)
                    {
                        //write to cell
                        bufferCell2.readWriteCell = encodedOrder;
                        waitingForWrite = false;                       
                    }
                    Monitor.Exit(bufferCell2);
                }
                //release semaphore
                cellPool.Release();
            }           
        }
        //read data from cells
        public string getOneCell()
        {
            bool waitingForRead = true;
            string encodedOrder = null;
            //keep thread alive while waiting for a lock/semaphore
            while (waitingForRead)
            {
                //enter semaphore
                cellPool.WaitOne();
                //try to get exclusive lock on first cell
                if (Monitor.TryEnter(bufferCell1))
                {
                    //check if cell has data
                    if (bufferCell1.readWriteCell != null)
                    {
                        //store cell data
                        encodedOrder = bufferCell1.readWriteCell;
                        //clear cell contents
                        bufferCell1.readWriteCell = null;
                        waitingForRead = false;
                    }
                    Monitor.Exit(bufferCell1);
                }
                //if cannot lock first cell, try second cell
                else if (Monitor.TryEnter(bufferCell2))
                {
                    //check if cell has data
                    if (bufferCell2.readWriteCell != null)
                    {
                        //store cell data 
                        encodedOrder = bufferCell2.readWriteCell;
                        //clear cell contents
                        bufferCell2.readWriteCell = null;
                        waitingForRead = false;                        
                    }
                    Monitor.Exit(bufferCell2);
                }
                //release semaphore
                cellPool.Release();
            }
            //return cell data to farmer
            return encodedOrder;
        }
        //release all semaphores on initial load
        public void releaseSemaphore()
        {
            cellPool.Release(2);
        }
        //private buffercell inner class 
        private class BufferCell
        {
            public string readWriteCell { get; set; }
        }
    }
}
