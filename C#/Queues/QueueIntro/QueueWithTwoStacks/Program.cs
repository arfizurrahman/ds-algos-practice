using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueWithTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueWithTwoStacks queue = new QueueWithTwoStacks();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue);

            Console.ReadKey();
        }
    }
}
