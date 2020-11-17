using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFirstNoRepeatedCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            CharFinder finder = new CharFinder();
            var ch = finder.GetFirstNonRepeatingChar("a green apple");
            Console.WriteLine(ch);
            Console.ReadKey();
        }
    }
}
