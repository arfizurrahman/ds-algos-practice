using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueFromScratchUsingArray
{
    class ArrayQueue
    {
        private int[] items;
        private int front;
        private int rear;
        private int length;

        public ArrayQueue(int capacity)
        {
            items = new int[capacity];
        }

        public void Enqueue(int item)
        {
            if (length == items.Length)
                throw new InvalidOperationException();

            items[rear] = item;
            rear = (rear + 1) % items.Length;
            length++;
        }

        public int Dequeue()
        {
            var item = items[front];
            items[front++] = 0;
            front = (front + 1) % items.Length;
            length--;
            return item;
        }

        public int Peek()
        {
            if (length == 0)
                throw new InvalidOperationException();
            return items[front];
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
