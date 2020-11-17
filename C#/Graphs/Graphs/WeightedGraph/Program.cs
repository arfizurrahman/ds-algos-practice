using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new WeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddEdge("A", "B", 3);
            graph.AddEdge("A", "C", 2);
            graph.Print();
            
            Console.ReadKey();
        }
    }
}
