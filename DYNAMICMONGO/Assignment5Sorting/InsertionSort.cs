using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Sorting
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            for (int i =1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            stopwatch.Stop();
            Console.WriteLine($"Insertion Sort took {stopwatch.Elapsed.TotalMilliseconds}ms!");

        }
    }
}
