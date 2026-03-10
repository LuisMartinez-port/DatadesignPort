using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Sorting
{
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minimumIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minimumIndex])
                        minimumIndex = j;
                }
                (array[i], array[minimumIndex]) = (array[minimumIndex], array[i]);
            }
            stopwatch.Stop();

            Console.WriteLine($"Selection Sort took {stopwatch.Elapsed.TotalMilliseconds}ms!");

        }

    }
}
