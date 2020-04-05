using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableExercises exercises = new HashTableExercises();
            int[] numbers = { 2, 4, 1, 6, 5 };
            var indices = exercises.TwoSum(numbers, 6);
            Console.WriteLine(string.Join(", ", indices));

            Console.ReadKey();
        }
    }
}
