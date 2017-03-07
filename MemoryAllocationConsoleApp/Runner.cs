using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class Runner
    {
        static void PromptJobCompletion(ref Partition[] partitions)
        {
            Console.WriteLine("   Enter a job number to have completed");
            int num = int.Parse(Console.ReadLine());
            partitions[num - 1].completeTask();
        }
        static void Main(string[] args)
        {
            //make jobs a queue
            Queue<Job> jobs = new Queue<Job>();
            jobs.Enqueue(new Job(1, 10));
            jobs.Enqueue(new Job(2, 20));
            jobs.Enqueue(new Job(3, 30));
            jobs.Enqueue(new Job(4, 40));      

            AllocationScheme fixedScheme = new AllocationScheme(false, 3, 50);

            AllocationSimulator.printJobTable(jobs.ToArray());
            Console.WriteLine();
            Console.WriteLine("   First-Fit Method");
            Console.WriteLine();
            AllocationSimulator.FirstFit(jobs, fixedScheme.partitions);
            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("   Best-Fit Method");
            Console.WriteLine();
            AllocationSimulator.BestFit(jobs, fixedScheme.partitions);
            Console.WriteLine();
            PromptJobCompletion(ref fixedScheme.partitions);
            AllocationSimulator.BestFit(jobs, fixedScheme.partitions);
        }
    }
}
