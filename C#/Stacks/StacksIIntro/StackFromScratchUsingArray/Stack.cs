using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFromScratchUsingArray
{
    class Stack
    {
        private int[] items = new int[10];
        private int length;

        public void Push(int item)
        {
            if (length == items.Length)
                throw new StackOverflowException();
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

        override
        public string ToString()
        {
            int[] array = new int[length];

            int j = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                array[j] = items[i];
                j++;
            }

            return string.Join(", ", array);
        }
        public bool IsEmpty()
        {
            return length == 0;
        }
    }
}
