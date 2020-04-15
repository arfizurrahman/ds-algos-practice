using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 8, 2, 4, 1, 3, 8 };
            var sorter = new BucketSort();
            sorter.Sort(numbers, 3);

            Console.WriteLine(string.Join(", ", numbers));
            Console.ReadKey();
        }
    }
}
