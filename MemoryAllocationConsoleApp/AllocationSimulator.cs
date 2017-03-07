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
        //public static void FirstFit(Job[] jobs, Partition[] partitions)
        public static void FirstFit(Queue<Job> jobs, Partition[] partitions)
        {
           // Queue<Job> queue = new Queue<Job>();
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            restart:
            foreach (Partition part in partitions)
            {
                if (part.isBusy == false)
                {      
                    if (jobs.First().waiting && (part.size >= jobs.First().size))
                    {
                        part.setJob(jobs.Dequeue());
                        totalFragmentation += (part.fragmentation);                            
                        goto restart;
                    }
                }               
            }
            foreach (Partition part in partitions)
            {
                part.print();
            }
            printQueue(jobs.ToArray());
        }

        public static void offerBestFit(Queue<Job> jobs, Partition[] partitions)
        {
            int minDifference = 999999;
            foreach (Partition part in partitions) //get min difference    
            {
                if (part.isBusy == false)
                {
                    int dif = (part.size - jobs.First().size);
                    if (((dif) < minDifference) && (dif >= 0))
                    {
                        minDifference = dif;
                    }
                }
            }
            foreach (Partition part in partitions) //assign job to best fit part
            {
                if (part.isBusy == false)
                {
                    int dif = (part.size - jobs.First().size);
                    if ((dif) == minDifference)
                    {
                        part.setJob(jobs.Dequeue());
                        totalFragmentation += (part.fragmentation);
                        break;
                    }
                }
            }
        }

        public static void BestFit(Queue<Job> jobs, Partition[] partitions)
        {
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            for(int i = 0; i < partitions.Count(); i++)
            {
                offerBestFit(jobs, partitions);
                partitions[i].print();
            }
            printQueue(jobs.ToArray());
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
            Console.WriteLine();
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
