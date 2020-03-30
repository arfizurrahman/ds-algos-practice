using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigONotaionO_n_2_
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void log(int[] numbers)
        {
            //--O(n + n^3)=O(n^3)--//Quadratic
            foreach (int number in numbers)// O(n)
                Console.WriteLine(number);

            foreach (int number in numbers)// O(n)
                foreach (int number2 in numbers)// O(n)
                    foreach (int number3 in numbers)// O(n)
                        Console.WriteLine(number + " - " + number2);
        }
    }
}
