using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHashTableFromScratch
{
    class HashMap
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

        private Entry[] items = new Entry[5];
        private int count;

        public void Add(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.value = value;
                return;
            }

            if (IsFull())
                throw new InvalidOperationException();

            items[GetIndex(key)] = new Entry(key, value);
            count++;
        }

        public string GetValue(int key)
        {
            var entry = GetEntry(key);
            return entry != null ? entry.value : null;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);
            if (index == -1 || items[index] == null)
                return;

            items[index] = null;
            count--;
        }

        private int GetIndex(int key)
        {
            int steps = 0;

            while (steps < items.Length)
            {
                int index = Index(key, steps++);
                var entry = items[index];
                if (entry == null || entry.key == key)
                    return index;
            }

            return -1;
        }

        public bool IsFull()
        {
            return count == items.Length;
        }

        private Entry GetEntry(int key)
        {
            int index = GetIndex(key);
            return index >= 0 ? items[index] : null;
        }

        private int Hash(int key)
        {
            return key % items.Length;
        }

        private int Index(int key, int i)
        {
            return (Hash(key) + i) % items.Length;
        }
    }
}
