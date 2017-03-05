using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class Runner
    {
        static void Main(string[] args)
        {
            //make jobs a queue
            /*
            jobs.Enqueue(new Job(1, 30));
            jobs.Enqueue(new Job(2, 50));
            jobs.Enqueue(new Job(3, 30));
            jobs.Enqueue(new Job(4, 25));      */
            
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

            AllocationSimulator.printJobTable(jobs);
            Console.WriteLine();
            Console.WriteLine("   First-Fit Method");
            Console.WriteLine();
            AllocationSimulator.FirstFit(jobs, partitions);
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("   Best-Fit Method");
            Console.WriteLine();
            AllocationSimulator.BestFit(jobs, partitions);
            Console.WriteLine();
        }
    }
}
