using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class AllocationSimulator
    {
        static int totalFragmentation = 0;
        public static void FirstFit(Job[] jobs, Partition[] partitions)
        {
           // Queue<Job> queue = new Queue<Job>();
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            restart:
            foreach (Partition part in partitions)
            {
                if (part.isBusy == false)
                {
                    foreach (Job job in jobs)
                    {
                        if (job.waiting && (part.size >= job.size))
                        {
                            part.setJob(job);
                            totalFragmentation += (part.fragmentation);                            
                            goto restart;
                        }
                    }
                }               
            }
            foreach (Partition part in partitions)
            {
                part.print();
            }
            printQueue(jobs);
        }

        public static void BestFit(Job[] jobs, Partition[] partitions)
        {
            int minDifference = 999999;
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            foreach (Job job in jobs)
            {
                if (job.waiting)
                {
                    //get min difference      
                    foreach (Partition part in partitions)
                    {
                        if (part.isBusy == false)
                        {
                            int dif = (part.size - job.size);
                            if (((dif) < minDifference) && (dif >= 0))
                            {
                                minDifference = dif;
                            }
                        }
                    }
                    //assign job to best fit part
                    foreach (Partition part in partitions)
                    {
                        if (part.isBusy == false)
                        {
                            int dif = (part.size - job.size);
                            if ((dif) == minDifference)
                            {
                                part.setJob(job);
                                break;
                            }
                        }
                    }
                }
            }
            foreach (Partition part in partitions)
            {

                foreach (Job job in jobs)
                {
                    if (job.waiting && ((part.size - job.size) == minDifference))
                    {
                        part.setJob(job);
                        totalFragmentation += (part.fragmentation);
                        break;
                    }
                }
                part.print();
            }
        }

        static void printQueue(Job[] list)
        {
            Console.Write("  Waiting List:");
            foreach (Job job in list)
            {
                if (job.waiting)
                {
                    Console.Write("  "+job.name + ":" + job.size + "K");
                }
            }
        }
       public static void printJobTable(Job[] jobs)
        {
            Console.WriteLine("______________");
            
            foreach (Job job in jobs)
            {
            Console.WriteLine("|              |");
                Console.WriteLine("|  " + job.name + ":" + job.size + "K    |");
            }
            Console.WriteLine("|______________|");
        }
    }
}
