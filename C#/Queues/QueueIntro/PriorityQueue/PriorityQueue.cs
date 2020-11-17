using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class PriorityQueue
    {
        private int[] items;
        private int length;

        public PriorityQueue(int length)
        {
            items = new int[length];
        }

        public void Add(int item)
        {
            if (IsFull())
                throw new InvalidOperationException();

            var i = ShiftItemsToInsert(item);
            items[i + 1] = item;
            length++;
        }

        private int ShiftItemsToInsert(int item)
        {
            int i;
            for (i = length - 1; i >= 0; i--)
            {
                if (item < items[i])
                    items[i + 1] = items[i];
                else
                    break;
            }

            return i + 1;
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return items[--length];
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public bool IsFull()
        {
            return length == items.Length;
        }

        override
        public string ToString()
        {
            return string.Join(", ", items);
        }
    }
}
