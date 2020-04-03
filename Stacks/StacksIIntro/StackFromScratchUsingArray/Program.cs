
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFromScratchUsingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack stack = new Stack();
            //stack.Push(5);
            //stack.Push(10);
            //stack.Push(15);
            //stack.Push(20);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine("----");
            //Console.WriteLine(stack.Peek());
            //Console.WriteLine("----");
            //stack.Print();
            //Console.WriteLine(stack);

            TwoStacks stacks = new TwoStacks(10);
            stacks.Push1(10);
            stacks.Push1(20);
            stacks.Push1(30);
            stacks.Push1(40);
            stacks.Push1(50);
            //stacks.Push1(50);

            stacks.Push2(60);
            stacks.Push2(70);
            stacks.Push2(80);
            stacks.Push2(90);
            Console.WriteLine("---Stack 01---");
            stacks.Print1();
            Console.WriteLine("");
            Console.WriteLine("Pop: " + stacks.Pop1());
            Console.WriteLine("Pop: " + stacks.Pop1());
            Console.WriteLine("Pop: " + stacks.Pop1());
            Console.WriteLine("Pop: " + stacks.Pop1());
            Console.WriteLine("Pop: " + stacks.Pop1());
            Console.WriteLine("---Stack 02---");
            stacks.Print2();
            Console.WriteLine("");
            Console.WriteLine("IsFull 1: " + stacks.IsEmpty1());
            Console.WriteLine("IsFull 2: " + stacks.IsEmpty2());

            Console.ReadKey();
        }
    }
}
