using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksIIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reverse a string using stack
            StringReverser reverser = new StringReverser();
            Expression expression = new Expression();
            
            Console.WriteLine(reverser.Reverse("abcd"));

            Console.WriteLine(expression.IsBalanced("(1+2){}"));
            Console.ReadKey();
        }
    }
}
