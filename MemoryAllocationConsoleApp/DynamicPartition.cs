using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    public class DynamicPartition
    {
      
        public int address;
        public int size;
        public Job job;
        public bool isFree; //free

        /// <summary>
        /// Constructor for Dynamic Memory Partition
        /// </summary>
        /// <param name="aJobs">job going into memory</param>
        public DynamicPartition(Job aJob)
        {
            job = aJob;
            size = aJob.size;
            isFree = false;
        }

        public void completeTask()
        {
            isFree = true;
        }

        public void print()
        {
            if (!isFree)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       " + size.ToString() + "K            " + address.ToString() + "K             "
                    + job.name + "           " + "Busy                  ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }/*
            else if (!isFree)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       " + size.ToString() + "K            " + address.ToString() + "K            "
                    + job.name + "           " + "Busy                  ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }*/
            else //is free   show external fragmentation
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("       " + size.ToString() + "K     " + "Free               External Fragmentation!: "+size.ToString()+"K");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }

    }
}
