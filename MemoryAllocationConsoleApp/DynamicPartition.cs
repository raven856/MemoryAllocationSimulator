﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class DynamicPartition
    {
      
        public int address;
        public int size;
        public Job job;
        public bool isBusy = false; //free
        public int fragmentation = 0;

        /// <summary>
        /// Constructor for Memory Partition
        /// </summary>
        /// <param name="aAddress">Memory Address</param>
        /// <param name="aSize">Size of the Partition</param>
        public DynamicPartition(int aAddress, int aSize)
        {
            address = aAddress;
            size = aSize;
        }

        /// <summary>
        /// Gives a job to the Memory Partition
        /// </summary>
        /// <param name="aJob"></param>
        public void completeTask()
        {
            job = null;
            isBusy = false;
            fragmentation = 0;
        }
        public string fragmentationToString()
        {
            if (fragmentation == 0)
            {
                return "None";
            }
            else { return fragmentation.ToString(); }
        }

        public void print()
        {
            if (this.isBusy && address < 100)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       " + size.ToString() + "K            " + address.ToString() + "K             "
                    + job.name + "           " + "Busy                " + this.fragmentationToString() + "  ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
            else if (this.isBusy)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       " + size.ToString() + "K            " + address.ToString() + "K            "
                    + job.name + "           " + "Busy                " + this.fragmentationToString() + "  ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       " + size.ToString() + "K             " + address.ToString() + "K            " +
                    "    " + "           " + "Free                ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }

    }
}