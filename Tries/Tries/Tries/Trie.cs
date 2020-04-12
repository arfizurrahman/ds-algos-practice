using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    class Trie
    {
        public static int ALPHABET_SIZE = 26;
        private class Node
        {
            public char value;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
            public bool isEndOfWord;

            public Node(char value)
            {
                this.value = value;
            }

            public override string ToString()
            {
                return "Value: " + value;
            }

            public bool HasChild(char ch)
            {
                return children.ContainsKey(ch);
            }

            public void AddChild(char ch)
            {
                children.Add(ch, new Node(ch));
            }

            public Node GetChild(char ch)
            {
                return children[ch];
            }

            public Node[] GetChildren()
            {
                return children.Values.ToArray();
            }

            public bool HasChildren()
            {
                return children.Count != 0;
            }

            public void RemoveChild(char ch)
            {
                children.Remove(ch);
            }
        }

        private Node root = new Node(' ');
        public void Insert(string word)
        {
            var current = root;

            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);

                current = current.GetChild(ch);
            }

            current.isEndOfWord = true;
        }

        public void Remove(string word)
        {
            if (word == null)
                return;

            Remove(root, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.isEndOfWord = false;
                return;
            }

            var ch = word.ToCharArray()[index];
            var child = root.GetChild(ch);
            if (child == null)
                return;

            Remove(child, word, index + 1);

            if (!child.HasChildren() && !child.isEndOfWord)
                root.RemoveChild(ch);
        }

        public bool Contains(string word)
        {
            if (word == null)
                return false;

            var current = root;
            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    return false;

                current = current.GetChild(ch);
            }

            return current.isEndOfWord;
        }

        public bool ContainsRecursive(string word)
        {
            if (word == null)
                return false;

            return ContainsRecursive(root, word, 0);
        }

        private bool ContainsRecursive(Node root, string word, int index)
        {
            if (index == word.Length)
                return root.isEndOfWord;

            if (root == null)
                return false;

            var ch = word.ToCharArray()[index];
            if (!root.HasChild(ch))
                return false;

            var child = root.GetChild(ch);

            return ContainsRecursive(child, word, index + 1);
        }

        public void Traverse()
        {
            Traverse(root);
        }

        private void Traverse(Node root)
        {
            foreach (var child in root.GetChildren())
                Traverse(child);

            // Post-order: visit child first
            Console.WriteLine(root.value);

        }

        public List<string> FindWords(string prefix)
        {
            var lastNode = FindLastNodeOf(prefix);
            var words = new List<string>();

            FindWords(lastNode, prefix, words);

            return words;
        }

        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root == null)
                return;

            if (root.isEndOfWord)
                words.Add(prefix);

            foreach (var child in root.GetChildren())
                FindWords(child, prefix + child.value, words);
        }

        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
                return null;

            var current = root;
            foreach (var ch in prefix.ToCharArray())
            {
                var child = current.GetChild(ch);
                if (child == null)
                    return null;
                current = child;
            }

            return current;
        }

        public int CountWords()
        {
            return CountWords(root);
        }

        private int CountWords(Node root)
        {
            var count = 0;

            if (root.isEndOfWord)
                count++;

            foreach (var child in root.GetChildren())
                count += CountWords(child);

            return count;
        }

        public void PrintWords()
        {
            PrintWords(root, "");
        }

        private void PrintWords(Node root, string word)
        {
            if (root.isEndOfWord)
                Console.WriteLine(word);

            foreach (var child in root.GetChildren())
            {
                PrintWords(child, word + child.value);
            }
        }

        public static string LongestCommonPrefix(string[] words)
        {
            if (words == null)
                return "";

            var trie = new Trie();
            foreach (var word in words)
                trie.Insert(word);

            var maxChars = GetShortest(words).Length;
            var prefix = new StringBuilder();
            var current = trie.root;

            while (prefix.Length < maxChars)
            {
                var children = current.GetChildren();
                if (children.Length != 1)
                    break;

                current = children[0];
                prefix.Append(current.value);
            }

            return prefix.ToString();
        }

        private static string GetShortest(string[] words)
        {
            if (words == null || words.Length == 0)
                return "";

            var shortest = words[0];
            for (int i = 0; i < words.Length; i++) {
                if (words[i].Length < shortest.Length)
                    shortest = words[i];
            }

            return shortest;
        }
    }
}
