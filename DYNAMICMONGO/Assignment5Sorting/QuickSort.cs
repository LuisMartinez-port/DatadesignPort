using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            void QuickSort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int pivot = Partition(arr, low, high);
                    QuickSort(arr, low, pivot - 1);
                    QuickSort(arr, pivot + 1, high);
                }
            }

            int Partition(int[] arr, int low, int high)
            {
                int pivot = arr[high];
                int i = low - 1;
                for (int j = low; j < high; j++)
                {
                    if (arr[j] < pivot)
                    {
                        i++;
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                }
                (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
                return i + 1;
            }

            QuickSort(array, 0, array.Length - 1);
            stopwatch.Stop();

            Console.WriteLine($"Quick Sort ran in {stopwatch.Elapsed.TotalMilliseconds}ms!");
        }

    }
}
