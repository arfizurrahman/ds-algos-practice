using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListFromScratch
{
    class LinkedList
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

        private Node first;
        private Node last;
        private int length;

        //AddFirst
        public void AddFirst(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
                first = last = node;
            else {
                node.next = first;
                first = node;
            }

            length++;
        }
        //AddLast
        public void AddLast(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
                first = last = node;
            else {
                last.next = node;
                last = node;
            }
            length++;
        }

        //RemoveFirst
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (first == last)
                first = last = null;
            else {
                var second = first.next;
                first.next = null;
                first = second;
            }

            length--;
        }
        //RemoveLast
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            if (first == last)
                first = last = null;
            else {
                var current = GetPrevious(last);
                current.next = null;
                last = current;
            }
            length--;
        }

        private Node GetPrevious(Node node)
        {
            var current = first;
            while (current != null)
            {
                if (current.next == node) return current;
                current = current.next;
            }

            return null;
        }
        public int IndexOf(int value)
        {
            var current = first;
            var index = 0;
            while (current != null)
            {
                if (current.value == value) return index;
                current = current.next;
                index++;
            }

            return -1;
        }
        public int GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
                throw new ArgumentNullException();
            //if (k > Length())
            //    throw new ArgumentOutOfRangeException();
            //var previous = first;
            //var current = first;
            //int i = 0;
            //while (current.next != null){
            //    if (i >= k - 1)
            //        previous = previous.next;
            //    current = current.next;
            //    i++;
            //}
            //return previous.value;

            var a = first;
            var b = first;
            for (int j = 0; j < k - 1; j++)
            {
                b = b.next;
                if (b == null)
                    throw new ArgumentOutOfRangeException();
            }

            while (b != last)
            {
                a = a.next;
                b = b.next;
            }
            return a.value;
        }
        public int Length()
        {
            return length;
        }
        public void Reverse()
        {
            if (IsEmpty()) return;

            var previous = first;
            var current = first.next;

            while (current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            last = first;
            last.next = null;
            first = previous;

            //var current = first;
            //while (current.next != null)
            //{
            //    var temp = current.next;

            //    if (current == first)
            //    {
            //        current.next = null;
            //        last = first = current;
            //        current = temp;
            //    }
            //    else
            //    {
            //        current.next = first;
            //        first = current;
            //        current = temp;
            //    }

            //}
            //current.next = first;
            //first = current;

        }
        public int[] ToArray()
        {
            int[] items = new int[length];
            var current = first;
            int i = 0;
            while (current != null)
            {
                items[i++] = current.value;
                current = current.next;
            }
            return items;
        }
        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }
        private bool IsEmpty()
        {
            return first == null;
        }

        public void PrintMiddle()
        {
            if (IsEmpty()) return;

            var previous = first;
            var current = first;
            int i = 0;
            while (current != last && current.next != last)
            {
                previous = previous.next;
                current = current.next.next;
            }

            if (current == last)
                Console.WriteLine(previous.value);
            else
                Console.WriteLine(previous.value + ", " + previous.next.value);

        }

        public void CreatLoop()
        {
            first.next.next.next.next.next.next = first.next.next.next;
        }

        public bool HasLoop()
        {
            var slow = first;
            var fast = first;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
