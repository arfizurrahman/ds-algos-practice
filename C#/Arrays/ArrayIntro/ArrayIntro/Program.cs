using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            
            //int[] numbers = new int[3];
            //Console.WriteLine(string.Join(",", numbers));

            Array numbers = new Array(3);
            numbers.Insert(10);
            numbers.Insert(20);
            numbers.Insert(30);
            numbers.Insert(50);
            numbers.Insert(60);
            //numbers.InsertAt(40, 2);
            //numbers.RemoveAt(0);
            //numbers.Insert(50);
            //numbers.Reverse();
            numbers.Print();
            //Console.WriteLine(numbers.IndexOf(40));
            //Console.WriteLine(numbers.Max());
            Console.WriteLine("-------");
            int[] newNumbers = {60, 40, 30, 20, 60};
            numbers.Intersect(newNumbers);

            Console.ReadKey();
        }
    }
}
