using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHashTableFromScratch
{
    class HashTable
    {
        private class Entry
        {
            public int key;
            public string value;

            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private LinkedList<Entry>[] items = new LinkedList<Entry>[5];

        public void Add(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null) {
                entry.value = value;
                return;
            }
            
            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }

        public string GetValue(int key)
        {
            var entry = GetEntry(key);
            return (entry == null) ? null : entry.value;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new InvalidOperationException();

            GetBucket(key).Remove(entry);
        }

        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);
            if (bucket != null)
            {
                foreach (var item in bucket)
                {
                    if (item.key == key)
                        return item;
                }
            }

            return null;
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            return items[Hash(key)];
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = Hash(key);
            var bucket = items[index];
            if (bucket == null)
            {
                items[index] = new LinkedList<Entry>();
                bucket = items[index];
            }

            return bucket;
        }

        private int Hash(int key)
        {
            return key % items.Length;
        }
    }
}
