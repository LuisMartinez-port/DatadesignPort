using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Sorting
{
    public class HeapSort
    {
        public static void Sort(int[] array)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            void HeapModeActivate(int[] arr, int size, int root)
            {
                int largest = root;
                int left = 2 * root + 1;
                int right = 2 * root + 2;

                if (left < size && arr[left] > arr[largest]) largest = left;
                if (right < size && arr[right] > arr[largest]) largest = right;

                if (largest != root)
                {
                    (arr[root], arr[largest]) = (arr[largest], arr[root]);
                    HeapModeActivate(arr, size, largest);
                }

               

            }

            for (int i = array.Length / 2 - 1; i >= 0; i--)
                HeapModeActivate(array, array.Length, i);

            for (int i = array.Length - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                HeapModeActivate(array, i, 0);
            }

            stopwatch.Stop();
            Console.WriteLine($"Heap Sort ran in {stopwatch.Elapsed.TotalMilliseconds}ms!");

        }

    }
}
