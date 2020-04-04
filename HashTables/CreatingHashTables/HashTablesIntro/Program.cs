using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablesIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(); 
            dictionary.Add(1, "Arfiz");
            dictionary.Add(2, "Ashfaq");
            dictionary.Add(3, "Fahmida");
            //dictionary.Add(null, null);//Not Key Allowed
            dictionary.ContainsKey(3); // O(1)
            dictionary.ContainsValue("Arfiz"); // O(n)

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }

            Console.ReadLine();
        }
    }
}
