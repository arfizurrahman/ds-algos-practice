using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class MinPriorityQueue
    {
        private MinHeap minHeap = new MinHeap();

        public void Enqueue(string value, int priority)
        {
            minHeap.Insert(priority, value);
        }

        public int Dequeue()
        {
            return minHeap.Remove();
        }

        public bool IsEmpty()
        {
            return minHeap.IsEmpty();
        }
    }
}
