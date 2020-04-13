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

        public void TraverseDepthFirst(string root)
        {
            var node = nodes[root];
            if (node == null)
                return;

            TraverseDepthFirst(node, new HashSet<Node>());
        }

        private void TraverseDepthFirst(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root);
            visited.Add(root);

            foreach (var node in adjacencyList[root])
                if (!visited.Contains(node))
                    TraverseDepthFirst(node, visited);
        }

        public void TraverseDepthFirstIterative(string root)
        {
            var node = nodes[root];
            if (node == null)
                return;

            Stack<Node> callStack = new Stack<Node>();

            HashSet<Node> visited = new HashSet<Node>();
            callStack.Push(node);

            while (callStack.Count != 0)
            {
                var current = callStack.Pop();

                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var n in adjacencyList[current])
                    if (!visited.Contains(n))
                        callStack.Push(n);
            }
        }

        public void TraverseBreadthFirstIterative(string root)
        {
            var node = nodes[root];
            if (node == null)
                return;

            HashSet<Node> visited = new HashSet<Node>();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);
                Console.WriteLine(current);

                foreach (var n in adjacencyList[current])
                    if (!visited.Contains(n))
                        queue.Enqueue(n);
            }
        }

        public List<string> TopologicalSort()
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            foreach (var node in nodes.Values)
                TopologicalSort(node, stack, visited);

            var sorted = new List<string>();
            while (stack.Count != 0)
                sorted.Add(stack.Pop().label);

            return sorted;
        }

        private void TopologicalSort(Node node, Stack<Node> stack, HashSet<Node> visited)
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);
            foreach (var neighbor in adjacencyList[node])
                TopologicalSort(neighbor, stack, visited);

            stack.Push(node);
        }

        public bool HasCycle()
        {
            HashSet<Node> all = new HashSet<Node>(nodes.Values);
            HashSet<Node> visiting = new HashSet<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            while (all.Count != 0)
            {
                var current = all.First();
                if (HasCycle(current, all, visiting, visited))
                    return true;
            }

            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);

            foreach (var neighbor in adjacencyList[node])
            {
                if (visited.Contains(neighbor))
                    continue;

                if (visiting.Contains(neighbor))
                    return true;

                if (HasCycle(neighbor, all, visiting, visited))
                    return true;
            }

            visiting.Remove(node);
            visited.Add(node);

            return false;
        }
    }
}
