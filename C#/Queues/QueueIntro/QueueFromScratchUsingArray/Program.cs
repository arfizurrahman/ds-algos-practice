using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueFromScratchUsingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayQueue queue = new ArrayQueue(5);
            queue.Enqueue(10);
            queue.Enqueue(30);
            queue.Enqueue(40);

            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);
            Console.WriteLine(queue.Dequeue());
            //queue.Enqueue(70);


            Console.WriteLine(queue);
            Console.ReadKey();
        }
    }
}
