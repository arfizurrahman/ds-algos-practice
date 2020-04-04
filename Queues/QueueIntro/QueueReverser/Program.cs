using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueReverser
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            //queue.Enqueue(10);
            //queue.Enqueue(20);
            //queue.Enqueue(30);
            //queue.Enqueue(40);
            queue.Enqueue(50);
            Reverse(queue, 2);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.ReadKey();
        }

        public static void Reverse(Queue<int> queue, int k)
        {
            if (!(k >= 0 && k <= queue.Count))
                throw new InvalidOperationException();
            int length = queue.Count;

            Stack<int> stack = new Stack<int>();

            while (stack.Count < k)
            {
                stack.Push(queue.Dequeue());
            }

            int i = 0;
            while (i < length)
            {
                queue.Enqueue(i < k ? stack.Pop() : queue.Dequeue());
                i++;
            }

            //for (int j = 0; j < queue.Count - k; j++)
            //{
            //    queue.Enqueue(queue.Dequeue());
            //}

        }
    }
}
