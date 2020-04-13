using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraph
{
    class WeightedGraph
    {
        private class Node
        {

            public string lable;
            private List<Edge> edges = new List<Edge>();

            public Node(string label)
            {
                this.lable = label;
            }

            public override string ToString()
            {
                return lable;
            }

            public void AddEdge(Node to, int weight)
            {
                edges.Add(new Edge(this, to, weight));
            }

            public List<Edge> GetEdges()
            {
                return edges;
            }
        }

        private class Edge
        {
            public Node from;
            public Node to;
            public int weight;

            public Edge(Node from, Node to, int weight)
            {
                this.from = from;
                this.to = to;
                this.weight = weight;
            }

            public override string ToString()
            {
                return from + "->" + to;
            }
        }

        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();

        public void AddNode(string label)
        {
            if (!nodes.ContainsKey(label))
                nodes.Add(label, new Node(label));
        }

        public void AddEdge(string from, string to, int weight)
        {
            var fromNode = nodes[from];
            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = nodes[to];
            if (toNode == null)
                throw new InvalidOperationException();

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public void Print()
        {
            foreach (var node in nodes.Values)
            {
                var edges = node.GetEdges();
                if (edges.Count != 0)
                {
                    Console.WriteLine(node + " is connected to [" + string.Join(", ", edges) + "]");
                }
            }
        }

        private class NodeEntry
        {
            public Node node;
            public int priority;

            public NodeEntry(Node node, int priority)
            {
                this.node = node;
                this.priority = priority;
            }
        }


        //public int GetShortestDistance(string from, string to)
        //{

        //    Queue<NodeEntry> queue = new Queue<NodeEntry>();
        //}

        public bool HasCycle()
        {
            HashSet<Node> visited = new HashSet<Node>();

            foreach (var node in nodes.Values)
            if (!visited.Contains(node) && (HasCycle(node, null, visited)))
                return true;

            return false;
        }

        private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
        {

            visited.Add(node);

            foreach (var edge in node.GetEdges())
            {
                if (edge.to == parent)
                    continue;

                if (visited.Contains(edge.to) ||
                    HasCycle(edge.to, node, visited))
                    return true;
            }
            return false;
        }
    }
}
