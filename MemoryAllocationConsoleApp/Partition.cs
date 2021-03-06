﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class Partition
    {
        public int address;
        public int size;
        Job job;
        public bool isBusy = false; //free
        public int fragmentation = 0;

        /// <summary>
        /// Constructor for Memory Partition
        /// </summary>
        /// <param name="aAddress">Memory Address</param>
        /// <param name="aSize">Size of the Partition</param>
        public Partition(int aAddress, int aSize)
        {
            address = aAddress;
            size = aSize;
        }
            
        /// <summary>
        /// Gives a job to the Memory Partition
        /// </summary>
        /// <param name="aJob"></param>
        public void setJob(Job aJob)
        {
            job = aJob;
            job.waiting = false;
            isBusy = true;
            fragmentation = size - job.size;
        }
        public string getFragmentation()
        {
            if (fragmentation == 0)
            {
                return "None";
            } else { return fragmentation.ToString(); }
        }

        public void print()
        {
            if (this.isBusy) {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       "+size.ToString() + "K             " + address.ToString() + "K            " + job.name + "           "+"Busy                "+this.getFragmentation()+"  ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            } else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       "+size.ToString() + "K             " + address.ToString() + "K            " + "    " + "           " + "Free                ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }

    }
}
