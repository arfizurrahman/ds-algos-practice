using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(8);
            Console.WriteLine(tree.Find(7));
            Console.ReadLine();
        }
    }
}
