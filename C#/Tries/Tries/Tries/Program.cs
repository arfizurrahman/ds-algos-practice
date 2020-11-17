using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("car");
            trie.Insert("care");
            //trie.Insert("card");
            //trie.Insert("careful");
            //trie.Insert("egg");
            var words = new []{"car", "ware"};
            //Console.WriteLine(string.Join(", " , words));
            Console.WriteLine(Trie.LongestCommonPrefix(words));
            Console.ReadKey();
        }
    }
}
