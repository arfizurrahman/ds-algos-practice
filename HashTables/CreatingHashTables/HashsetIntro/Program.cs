using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashsetIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            //HashSet<int> set = new HashSet<int>();
            //set.Add(1);
            //set.Add(1);
            //int[] numbers = {1, 2, 3, 3, 2, 1, 4};
            //foreach (var number in numbers)
            //{
            //    set.Add(number);
            //}

            //Console.WriteLine(string.Join(", ", set.ToArray()));

            CharFinder finder = new CharFinder();
            Console.WriteLine(finder.FindTheFirstRepeatedCharacter("green apple"));
            Console.ReadKey();
        }
    }
}
