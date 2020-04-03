using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIntro
{
    class Array
    {
        private int[] items;
        private int length;

        public Array(int length)
        {
            items = new int[length];
        }

        public void Insert(int item)
        {
            if (length == items.Length)
            {
                int[] newItems = new int[length + 1];
                for (int i = 0; i < length; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }
            items[length++] = item;
        }

        public void InsertAt(int item, int index)
        {
            if (index >= length)
                throw new IndexOutOfRangeException();
            int[] newItems = new int[length + 1];

            for (int i = 0; i < length; i++)
            {
                if (i == index)
                {
                    newItems[i + 1] = items[i];
                    newItems[i] = item;
                }
                else if (i > index)
                {
                    newItems[i + 1] = items[i];
                }
                else
                {
                    newItems[i] = items[i];
                }
            }

            items = newItems;
            length++;
        }

        public void Print()
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(items[i]);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            length--;
        }

        public int IndexOf(int item)
        {
            // O(n)
            for (int i = 0; i < length; i++)
            {
                if (items[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public int Max()
        {
            // O(n)
            int max = 0;
            for (int i = 0; i < length; i++)
            {
                if (items[i] > max)
                {
                    max = items[i];
                }
            }

            return max;
        }

        //public string Intersect(int[] items)
        //{
        //    var count = items.Length > length ? length : items.Length;
        //    if (length != items.Length)
        //    {
        //        throw new ArgumentOutOfRangeException();
        //    }
        //    int[] newItems = new int[length];
        //    int j = 0;
        //    for (int i = 0; i < length; i++)
        //    {

        //        if (this.items[i] == items[i])
        //        {
        //            newItems[j++] = items[i];
        //        }
        //    }
        //}


        public void Reverse()
        {
            for (int i = 0; i < length / 2; i++)
            {
                int x = items[i];
                items[i] = items[length - 1 - i];
                items[length - 1 - i] = x;
            }
        }

        public void Intersect(int[] items)
        {
            //var ss = items.Where(i => this.items.Contains(i)).Distinct();
            int count = length > items.Length ? items.Length : length;
            int count2 = length > items.Length ? length : items.Length;
            int[] newItems = new int[count];
            for (int i = 0; i < count; i++)
            {
                int temp = 0;
                for (int j = 0; j < count; j++)
                {
                    if (this.items.Length > items.Length)
                    {
                        if (items[i] == newItems[j])
                        {
                            temp = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (this.items[i] == newItems[j])
                        {
                            temp = 1;
                            break;
                        }
                    }
                }

                if (temp == 1)
                    continue;

                for (int j = 0; j < count2; j++)
                {
                    if (this.items.Length > items.Length)
                    {
                        if (items[i] == this.items[j])
                        {
                            newItems[i] = items[i];
                            Console.WriteLine(items[i]);
                            break;
                        }
                    }
                    else
                    {
                        if (items[j] == this.items[i])
                        {
                            newItems[i] = items[j];
                            Console.WriteLine(items[j]);
                            break;
                        }
                    }
                }
            }

            //return string.Join(",", newItems);
        }

    }
}
