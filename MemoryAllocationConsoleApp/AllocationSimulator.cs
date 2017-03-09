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

        public static void offerJobs(ref Queue<Job> jobs, DynamicMemory scheme)
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                if (scheme.offer(jobs.First()) == true) //successfully loaded job to memory 
                {
                    jobs.Dequeue();
                }
            }
        }

        public static void FirstFit(Queue<Job> jobs, FixedPartition[] partitions)
        {
           // Queue<Job> queue = new Queue<Job>();
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            restart:
            foreach (FixedPartition part in partitions)
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
            foreach (FixedPartition part in partitions)
            {
                part.print();
            }
            printQueue(jobs.ToArray());
        }

        public static void offerBestFit(Queue<Job> jobs, FixedPartition[] partitions)
        {
            int minDifference = 999999;
            foreach (FixedPartition part in partitions) //get min difference    
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
            foreach (FixedPartition part in partitions) //assign job to best fit part
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
        private static void offerWorstFit(Queue<Job> jobs, FixedPartition[] partitions)
        {
            int maxDifference = 0;
            foreach (FixedPartition part in partitions) //get min difference    
            {
                if (part.isBusy == false)
                {
                    int dif = (part.size - jobs.First().size);
                    if (((dif) > maxDifference) && (dif >= 0))
                    {
                        maxDifference = dif;
                    }
                }
            }
            foreach (FixedPartition part in partitions) //assign job to best fit part
            {
                if (part.isBusy == false)
                {
                    int dif = (part.size - jobs.First().size);
                    if ((dif) == maxDifference)
                    {
                        part.setJob(jobs.Dequeue());
                        totalFragmentation += (part.fragmentation);
                        break;
                    }
                }
            }
        }

        public static void BestFit(Queue<Job> jobs, FixedPartition[] partitions)
        {
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            for(int i = 0; i < partitions.Count(); i++)
            {
                offerBestFit(jobs, partitions);
                partitions[i].print();
            }
            printQueue(jobs.ToArray());
        }
        public static void WorstFit(Queue<Job> jobs, FixedPartition[] partitions)
        {
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            for (int i = 0; i < partitions.Count(); i++)
            {
                offerWorstFit(jobs, partitions);
                partitions[i].print();
            }
            printQueue(jobs.ToArray());
        }

        public static void printQueue(Job[] list)
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

        public static void NextFit(Queue<Job> jobs, FixedPartition[] partitions)
        {
            // Queue<Job> queue = new Queue<Job>();
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
            foreach (FixedPartition part in partitions)
            {
                if (part.isBusy == false)
                {
                    if (jobs.First().waiting && (part.size >= jobs.First().size))
                    {
                        part.setJob(jobs.Dequeue());
                        totalFragmentation += (part.fragmentation);
                    }
                }
            }
            foreach (FixedPartition part in partitions)
            {
                part.print();
            }
            printQueue(jobs.ToArray());
        }

    }
}
