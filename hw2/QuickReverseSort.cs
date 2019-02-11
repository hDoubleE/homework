// Runtime of my algo
// Merge is stable
using System;

namespace Sorting
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter some words, separated by spaces:");

            // Process input string into string array.
            string strInput = Console.ReadLine().Trim();
            string[] data = strInput.Split(' ');

            // Print unsorted data.
            Console.Write("\nUnsorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }

            // Sort data.
            QuickReverseSort(data);

            // Print sorted data.
            Console.Write("\nReverse Sorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine($"\nNumber of Comparisons: {NumComp}");
        }

        public static int NumComp { get; set; }

        static void QuickReverseSort(string[] arr)
        {
            QuickReverseSort(arr, 0, arr.Length - 1);
        }
        static void QuickReverseSort(string[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex) // At least two elements.
            {
                int storeIndex = Partition(arr, leftIndex, rightIndex);
                QuickReverseSort(arr, leftIndex, storeIndex - 1);
                QuickReverseSort(arr, storeIndex, rightIndex);
            }
        }
        
        static int Partition(string[] arr, int leftIndex, int rightIndex) // Return new index of pivot.
        {
            string pivotString = arr[rightIndex];
            int swapIndex = leftIndex - 1;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                NumComp++;
                int compareStrings = arr[i].CompareTo(pivotString);
                if (compareStrings >= 0)
                {
                    swapIndex++;
                    string temp1 = arr[swapIndex];
                    arr[swapIndex] = arr[i];
                    arr[i] = temp1;
                }
            }
            // Swap arr[swapIndex + 1] with pivotValue(ie. arr[rightIndex]).
            string temp2 = arr[swapIndex + 1];
            arr[swapIndex + 1] = arr[rightIndex];
            arr[rightIndex] = temp2;

            // Return new index position for the pivot.
            return swapIndex + 1;
        }
    }
}

// The Upshot: O(n log n) in the best and average case and O(n^2) in the worst case.
// Space complexity is O(log n) in the worst case. 

