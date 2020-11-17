using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListFromScratch
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddFirst(10);
            list.AddFirst(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);
            list.AddLast(60);
            //list.Reverse();
            //list.RemoveFirst();
            //Console.WriteLine(list.IndexOf(50));
            //list.RemoveLast();
            //var array = list.ToArray();
            //Console.WriteLine(string.Join(",", array));
            ////Console.WriteLine(list.GetKthFromTheEnd(-1));
            //list.CreatLoop();
            Console.WriteLine(list.HasLoop());
            //list.PrintMiddle();
            Console.ReadKey();
        }
    }
}
