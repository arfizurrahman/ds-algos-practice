using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHashTableFromScratch
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable();
            hashTable.Add(6, "Arfiz");
            hashTable.Add(8, "Fahmida");
            hashTable.Add(11, "Ashfaq");
            hashTable.Add(11, "Farez");
            hashTable.Remove(9);

            Console.WriteLine(hashTable.GetValue(3));
            Console.ReadKey();
        }
    }
}
