using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue queue = new PriorityQueue(10);
            queue.Add(2);
            queue.Add(3);
            queue.Add(1);
            queue.Add(6);

            //Console.WriteLine(queue);
            //Console.WriteLine("Dequeue: " + queue.Remove());
            //Console.WriteLine(queue);
            //Console.WriteLine("Dequeue: " + queue.Remove());
            //Console.WriteLine("Dequeue: " + queue.Remove());
            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Remove());
            }
            Console.ReadKey();
        }
    }
}
