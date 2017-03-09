using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class FixedMemory : Memory
    {
        public FixedPartition[] partitions;
        public FixedMemory(int partitionCount, int eachSize)
        {
            isDynamic = false;
            capacity = partitionCount * eachSize;
            partitions = new FixedPartition[partitionCount]; //make partition objects in partition array
            for (int i = 0; i < partitionCount; i++)
            {
                partitions[i] = new FixedPartition(((i + 1) * 50), eachSize); //address and size
            }
        }
    }
}
