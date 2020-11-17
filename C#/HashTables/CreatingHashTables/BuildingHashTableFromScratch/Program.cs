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
            //    HashTable hashTable = new HashTable();
            //    hashTable.Add(6, "Arfiz");
            //    hashTable.Add(8, "Fahmida");
            //    hashTable.Add(11, "Ashfaq");
            //    hashTable.Add(11, "Farez");
            //    hashTable.Remove(9);

            HashMap map = new HashMap();
            map.Add(6,"A");
            map.Add(8,"B");
            map.Add(11,"C");
            map.Add(12,"D");
            map.Add(13,"E");
            map.Add(13,"F");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
