using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class Runner
    {
        static bool PromptJobCompletion(ref FixedPartition[] partitions)
        {
            Console.WriteLine("   Enter a job number to have completed, or write \"quit\"");
            string str = Console.ReadLine();
            if (str == "quit")
            {
                return false;
            }
            int num = int.Parse(str);
            partitions[num - 1].completeTask();
            return true;
        }
        static void PromptCommandsDynamic(ref Queue<Job> jobs, ref DynamicMemory scheme)
        {
            Console.WriteLine("   Enter a command: \"end\", \"compact\", \"load\", or \"quit\"");
            string str = Console.ReadLine();
            if (str == "end")
            {
                Console.WriteLine("  WhichJob?");
                int num = (int.Parse(Console.ReadLine()));
                scheme.completeTaskWithJob(num);
                scheme.printMemory();
            }
            else if (str == "load")
            {
                AllocationSimulator.offerJobs(ref jobs, scheme);
                scheme.printMemory();
            }
            else if (str == "compact")
            {
                scheme.compact();
                scheme.printMemory();
            }
            else if (str == "quit")
            {
                return;
            }
            else
            {
                Console.WriteLine("unrecongnized command. enter \"end\", \"compact\" or \"load\"");
            }
            Console.WriteLine();
            AllocationSimulator.printQueue(jobs.ToArray());
            PromptCommandsDynamic(ref jobs, ref scheme);
        }

        static void Main(string[] args)
        {         
            //Dynamic
            Queue<Job> jobs = new Queue<Job>();
            jobs.Enqueue(new Job(1, 10));
            jobs.Enqueue(new Job(2, 20));
            jobs.Enqueue(new Job(3, 30));
            jobs.Enqueue(new Job(4, 40));
            jobs.Enqueue(new Job(5, 50));
            DynamicMemory dynamicScheme = new DynamicMemory(70);
            AllocationSimulator.printJobTable(jobs.ToArray());

            //promt command
            dynamicScheme.printMemory();
            PromptCommandsDynamic(ref jobs, ref dynamicScheme);

            //Fixed
            FixedMemory fixedScheme = new FixedMemory(3, 50);
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

            bool go = true;
            while (go)
            {
                go = PromptJobCompletion(ref fixedScheme.partitions);
                AllocationSimulator.FirstFit(jobs, fixedScheme.partitions);
                AllocationSimulator.BestFit(jobs, fixedScheme.partitions);
            }
        }
    }
}
