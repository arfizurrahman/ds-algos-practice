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
            graph.AddNode("X");
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("P");
            graph.AddEdge("X", "A");
            graph.AddEdge("X", "B");
            graph.AddEdge("A", "P");
            graph.AddEdge("B", "P");
            var list = graph.TopologicalSort();

            Console.WriteLine(string.Join(", ", list));

            Console.ReadKey();
        }
    }
}
