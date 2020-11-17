using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4! = 4 x 3!
            // n! = n x (n - 1)!
            Console.WriteLine(Factorial(4));
            Console.ReadKey();
        }

        public static int Factorial(int n)
        {
            // Base condition
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}
