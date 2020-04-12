using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        private class Node
        {
            public string label;

            public Node(string label)
            {
                this.label = label;
            }

            public override string ToString()
            {
                return label;
            }
        }

        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);

            if (!nodes.ContainsKey(label))
                nodes.Add(label, node);

            if (!adjacencyList.ContainsKey(node))
                adjacencyList.Add(node, new List<Node>());
        }

        public void AddEdge(string from, string to)
        {
            var fromNode = nodes[from];
            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = nodes[to];
            if (toNode == null)
                throw new InvalidOperationException();

            adjacencyList[fromNode].Add(toNode);
        }

        public void Print()
        {
            foreach (var source in adjacencyList.Keys)
            {
                var targets = adjacencyList[source];
                if (targets.Count != 0)
                {
                    Console.WriteLine(source + " is connected to [" + string.Join(", ", targets) + "]");
                }
            }
        }

        public void RemoveNode(string label)
        {
            var node = nodes[label];
            if (node == null)
                return;

            foreach (var n in adjacencyList.Keys)
                adjacencyList[n].Remove(node);

            adjacencyList.Remove(node);
            nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];

            if (fromNode == null || toNode == null)
                return;

            adjacencyList[fromNode].Remove(toNode);
        }
    }
}
