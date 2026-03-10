using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Sorting
{
    public class Bubblesort
    {
        public static void Sort(int[] array)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            //this is in every sorting algorithms class, I didnt even know this was a thing
            int n = array.Length;
            bool IsSwapped;
            for (int i = 0; i < n - 1; i++)
            {
                 IsSwapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        IsSwapped = true;
                    }
                }

                //if there is no swaps, then the array is already sorted
                //even though this is 100% not happening with this data set it is still important to have
                //just as coverage for other data sets that MIGHT be 
                if (!IsSwapped)
                    break;
            }
            stopwatch.Stop();

            Console.WriteLine($"Bubble Sort took place in {stopwatch.Elapsed.TotalMilliseconds}ms!");


        }



    }
}
