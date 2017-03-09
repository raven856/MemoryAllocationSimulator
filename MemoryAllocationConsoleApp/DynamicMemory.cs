using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    public class DynamicMemory : Memory
    {
        public List<DynamicPartition> partitions = new List<DynamicPartition>();
        int openBlock;

        public DynamicMemory(int aCapacity)
        {
            isDynamic = true;
            capacity = aCapacity;
            openBlock = aCapacity;
        }

        public bool offer(Job aJob)
        { 
            if (openBlock >= aJob.size)
            {
                openBlock -= aJob.size;
                partitions.Add(new DynamicPartition(aJob));
                return true;
            }

            return false;
        }

        public bool completeTaskWithJob(int jobNumber)
        {
            foreach (DynamicPartition part in partitions) {
               
                if (part.job.number == jobNumber)
                {
                    part.completeTask();
                    return true;
                }
                
            }
            return false;
        }

        public void compact()
        {
            int count = partitions.Count;
            for (int i = 0; i< count; i++)
            { 
                if (partitions[i].isFree)
                {
                    int partitionSize = partitions[i].size;
                    partitions.Remove(partitions[i]);
                    i--;
                    count--;
                    openBlock += partitionSize;
                }
            }
        }

        public void printMemory()
        {
            foreach(DynamicPartition part in partitions)
            {
                part.print();
            }
            //show how much free space there is
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("    Free Space   Size: " + openBlock.ToString() + "K                        " +
                   "     " + "           " + "Free              ");
            for (int i = 0; i < openBlock; i+=10)
            {
                Console.WriteLine(); Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
        }

    }
}
