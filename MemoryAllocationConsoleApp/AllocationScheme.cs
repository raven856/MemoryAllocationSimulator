using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    class AllocationScheme
    {
        public Partition[] partitions;
        public int capacity;
        
        /// <summary>
        /// Used for constructing new Scheme
        /// </summary>
        /// <param name="isDynamicScheme">false=fixed</param>
        public AllocationScheme(bool isDynamicScheme, int partitionCount, int eachSize)
        {
            //isDynamic = isDynamicScheme;
            capacity = partitionCount * eachSize;

            if (!isDynamicScheme) //fixxed
            {
                partitions = new Partition[partitionCount];
                //make partition objects in partition array
                for (int i = 0; i < partitionCount; i++)
                {
                    partitions[i] = new Partition(((i+1)*50), eachSize); //address and size
                }

            }

        }

    }
}
