using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1, 5, 6, 7, 8, 11, 14, 17, 34, 45, 47};
            Search search = new Search();
            //Console.WriteLine(search.JumpSearch(numbers, 8));
            Console.WriteLine(search.ExponentialSearch(numbers, 47));

            Console.ReadKey();
        }
    }
}
