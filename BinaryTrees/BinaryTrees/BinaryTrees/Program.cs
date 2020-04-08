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

            Tree tree2 = new Tree();
            tree2.Insert(7);
            tree2.Insert(4);
            tree2.Insert(9);
            tree2.Insert(1);
            tree2.Insert(10);
            tree2.Insert(6);
            //tree2.Insert(8);

            //tree.SwapRoot();
            foreach (var i in tree.GetAncestors(1))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            //tree.TraversePreOrder();
            //Console.WriteLine("In-Order");
            //tree.TraverseInOrder();
            //Console.WriteLine("Post-Order");
            //tree.TraversePostOrder();
            //Console.WriteLine(tree.Find(7));
            Console.ReadLine();
        }
    }
}
