﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            //queue.Enqueue(12);
            //queue.Enqueue(20);
            //queue.Enqueue(40);
            //queue.Enqueue(50);
            Reverse(queue);
            Console.ReadKey();
        }

        public static void Reverse(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

            while (queue.Count != 0){
                stack.Push(queue.Dequeue());
            }

            while (stack.Count != 0){
                queue.Enqueue(stack.Pop());
            }
            
        }
    }
}
