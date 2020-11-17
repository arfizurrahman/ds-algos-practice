using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFromScratchUsingArray
{
    class MinStack
    {
        private int[] items = new int[10];
        private int min;
        private int length;

        public void Push(int item)
        {
            if (length == items.Length)
                throw new StackOverflowException();

            if (min > item)
                min = item;

            items[length++] = item;
        }

        public int Pop()
        {
            if (length == 0)
                throw new InvalidOperationException();
            return items[--length];
        }

        public int Peek()
        {
            if (length == 0)
                throw new InvalidOperationException();
            return items[length - 1];
        }
        public int Min()
        {
            return min;
        }
    }
}
