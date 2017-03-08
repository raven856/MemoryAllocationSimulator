using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    public class Memory
    {
        public FixedPartition[] partitions;
        public int capacity;
        public bool isDynamic;
        /// <summary>
        /// Used for constructing new fixed Scheme
        /// </summary>
        public Memory(int partitionCount, int eachSize)
        {
            isDynamic = false;
            capacity = partitionCount * eachSize;
            partitions = new FixedPartition[partitionCount]; //make partition objects in partition array
            for (int i = 0; i < partitionCount; i++)
            {
                partitions[i] = new FixedPartition(((i+1)*50), eachSize); //address and size
            }
            
        }
        /// <summary>
        /// used for Dynamic Scheme
        /// </summary>
        /// <param name="aCapacity"></param>
        public Memory(int aCapacity)
        {
            isDynamic = true;
            capacity = aCapacity;



        }
    }
}
