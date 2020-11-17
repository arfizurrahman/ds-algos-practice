using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFromScratchUsingArray
{
    class TwoStacks
    {
        private int[] items;
        private int length;
        private int top1;
        private int top2;

        public TwoStacks(int n)
        {
            items = new int[n];
            top1 = -1;
            top2 = n;
        }
        public void Push1(int item)
        {
            if (IsFull1())
                throw new StackOverflowException();
            
            items[++top1] = item;
        }

        public void Push2(int item)
        {
            if (IsFull2())
                throw new StackOverflowException();

            items[--top2] = item;
        }

        public int Pop1()
        {
            if (IsEmpty1())
                throw new InvalidOperationException();

            return items[top1--];
        }

        public int Pop2()
        {
            if (top2 == 0)
                throw new InvalidOperationException();

            return items[top2++];
        }

        public bool IsFull1()
        {
            return top1 + 1 == top2;
        }

        public bool IsFull2()
        {
            return top2 - 1 == top1;

        }

        public bool IsEmpty1()
        {
            return top1 ==  -1;
        }

        public bool IsEmpty2()
        {
            return top2 == items.Length;
        }

        public void Print1()
        {
            for (int i = top1-1; i >= 0; i--)
            {
                Console.Write(items[i]);
                if (i != 0)
                    Console.Write(", ");
            }
        }

        public void Print2()
        {
            for (int i = items.Length - top2; i < items.Length; i++)
            {
                Console.Write(items[i]);
                if (i != items.Length-1)
                    Console.Write(", ");
            }
        }
    }
}
