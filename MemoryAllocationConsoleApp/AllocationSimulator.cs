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
             
            Console.WriteLine("  Partition Size    Memory Address    Access    Partition Status    Internal Fragmentation");
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
                            break;
                        }
                    }
                }   
                part.print();
            }
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

        void printQueue(Job[] list)
        {
            foreach(Job job in list)
            {
                Console.Write(job.name+":"+job.size+"K  ");
            }
        }

        static void Main(string[] args)
        {
            //make jobs a queue
            Job[] jobs = new Job[4];
            jobs[0] = new Job(1, 30);
            jobs[1] = new Job(2, 50);
            jobs[2] = new Job(3, 30);
            jobs[3] = new Job(4, 25);

            Partition[] partitions = new Partition[4];
            partitions[0] = new Partition(200, 100);
            partitions[1] = new Partition(300, 25);
            partitions[2] = new Partition(325, 25);
            partitions[3] = new Partition(350, 50);

            Console.WriteLine("   First-Fit Method");
            Console.WriteLine();
            FirstFit(jobs, partitions);
            Console.WriteLine();
            Console.WriteLine("   Best-Fit Method");
            Console.WriteLine();
            BestFit(jobs, partitions);
            Console.WriteLine();
        }

       

    }
}
