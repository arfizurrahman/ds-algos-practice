using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueFromScratchUsingLinkedList
{
    class LinkedListQueue
    {
        private class Node
        {
            public int value;
            public Node next;
            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public void Enqueue(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
                head = tail = node;
            else {
                tail.next = node;
                tail = node;
            }
            
            count++;
        }
        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            int value;
            if (head == tail)
            {
                value = head.value;
                head = tail = null;
            }
            else
            {
                value = head.value;
                var next = head.next;
                head.next = null;
                head = next;
            }
            count--;
            return value;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return head.value;
        }

        public int Size()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return head == null;
        }


    }
}
