using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            void MergeSort(int[] arr, int left, int right)
            {
                if (left < right)
                {
                    int mid = (left + right) / 2;
                    MergeSort(arr, left, mid);
                    MergeSort(arr, mid + 1, right);
                    Merge(arr, left, mid, right);
                }
            }

            void Merge(int[] arr, int left, int mid, int right)
            {
                int n1 = mid - left + 1;
                int n2 = right - mid;

                int[] L = new int[n1];
                int[] R = new int[n2];

                Array.Copy(arr, left, L, 0, n1);
                Array.Copy(arr, mid + 1, R, 0, n2);

                int i = 0, j = 0, k = left;
                while (i < n1 && j < n2)
                {
                    arr[k++] = (L[i] <= R[j]) ? L[i++] : R[j++];
                }
                while (i < n1) arr[k++] = L[i++];
                while (j < n2) arr[k++] = R[j++];
            }

            MergeSort(array, 0, array.Length - 1);

            stopwatch.Stop();
            Console.WriteLine($"Merge Sort ran in {stopwatch.Elapsed.TotalMilliseconds}ms!");
        }


        }
    }
