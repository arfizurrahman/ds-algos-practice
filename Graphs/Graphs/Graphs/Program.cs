using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.RemoveNode("B");

            graph.Print();

            Console.ReadKey();
        }
    }
}
