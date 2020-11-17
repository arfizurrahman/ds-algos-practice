using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.Add("123124-A", "Arfiz");
            //Console.WriteLine(Hash("123243-A"));

            string str = "orange";
            Console.WriteLine(str.GetHashCode());
            Console.ReadKey();
        }

        public static int Hash(string key)
        {
            //int hash = key % 100;// for int key
            int hash = 0;
            foreach (var ch in key.ToCharArray())
            {
                hash += ch;
            }
            return hash % 100;
        }
    }
}
