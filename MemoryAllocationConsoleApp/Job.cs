using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocationConsoleApp
{
    public class Job
    {
        public int size;
        public int number;
        public string name;
        public bool waiting = true;

        public Job(int aNumber, int aSize)
        {
            size = aSize;
            number = aNumber;
            name = "job" + aNumber.ToString();
        }
    }
}
