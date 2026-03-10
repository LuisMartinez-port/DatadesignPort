using System;
using System.IO;

namespace Assignment5Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Data.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: Data.txt not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            int[] scores = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out int value))
                    scores[i] = value;
                else
                    Console.WriteLine($"Warning: Invalid number on line {i + 1}");
            }

            //had to find another example of how to get my data to read, had to change the properties
            //to "Copy if newer" to fix the issue of it not being read


            Console.WriteLine("Press Enter to view Bubble Sort");
            Console.ReadLine();
            Bubblesort.Sort((int[])scores.Clone()); //just learned this, allows each sort to use the same data, by cloning it
                                                    //probably really bad for huge data sets, but for this it should be fine


            Console.WriteLine("\nPress Enter to run Insertion Sort...");
            Console.ReadLine();
            InsertionSort.Sort((int[])scores.Clone());

            Console.WriteLine("\nPress Enter to run Selection Sort...");
            Console.ReadLine();
            SelectionSort.Sort((int[])scores.Clone());


            Console.WriteLine("\nPress Enter to run Heap Sort...");
            Console.ReadLine();
            HeapSort.Sort((int[])scores.Clone());


            Console.WriteLine("\nPress Enter to run Quick Sort...");
            Console.ReadLine();
            QuickSort.Sort((int[])scores.Clone());


            Console.WriteLine("\nPress Enter to run Merge Sort...");
            Console.ReadLine();
            MergeSort.Sort((int[])scores.Clone());

        }
    }
}
