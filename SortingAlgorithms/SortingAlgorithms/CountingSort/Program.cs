using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 8, 2, 4, 1, 3 , 8};
            var sorter = new CountingSort();
            sorter.Sort(numbers, 8);

            Console.WriteLine(string.Join(", ", numbers));
            Console.ReadKey();
        }
    }
}
