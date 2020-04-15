using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    class CountingSort
    {
        public void Sort(int[] array, int max)
        {
            int[] counts = new int[max + 1];
            foreach (var item in array)
                counts[item]++;

            var k = 0;
            for (int i = 0; i < counts.Length; i++)
                for (int j = 0; j < counts[i]; j++)
                    array[k++] = i;
        }
    }
}
