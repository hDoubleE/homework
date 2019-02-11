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
            MergeReverse(data);
         
            // Print sorted data.
            Console.Write("\nReverse Sorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }
            // Print number of comparisons.
            Console.WriteLine($"\nNumber of Comparisons: {numComp}");

        }

        // Declare global property to store number of comparisons.
        public static long numComp { get; set; }
        // I used the algorithm from class notes for continuity, but have been experimenting with other versions.
        static void MergeReverse(string[] arr)
        {
            // Temporary array.
            string[] tmp = new string[arr.Length];
            MergeReverse(arr, 0, arr.Length - 1, tmp);

        }
        static void MergeReverse(string[] arr, int start, int end, string[] tmp)
        {
            if (start < end) // If at least two elements in array.
            {
                //split into two halves and sort each half
                int mid = (start + end) / 2;
                MergeReverse(arr, start, mid, tmp);
                MergeReverse(arr, mid + 1, end, tmp);
                //merge the two halves
                Merge(arr, start, mid, end, tmp);

            }
        }

        public static void Merge(string[] arr, int start, int mid, int end, string[] tmp)
        {
            int i = start;
            int j = mid + 1;
            int k = start;

            //merge the subarrays
            while (i <= mid && j <= end)
            {
                int CompareStrings = arr[i].CompareTo(arr[j]);
                if (CompareStrings >= 0)
                {
                    tmp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    tmp[k] = arr[j];
                    j++;
                    k++;
                }
                numComp++;
            }
            while (i <= mid) // Merge remaining items.
            {
                tmp[k] = arr[i];
                i++;
                k++;
                numComp++;
            }
            while (j <= end) // Merge remaining items.
            {
                tmp[k] = arr[j];
                j++;
                k++;
                numComp++;
            }

            // Copy items back into original array.
            for (k = start; k <= end; k++)
            {
                arr[k] = tmp[k];
            }
        }
    }
}

// The Upshot: Merge sort is O(n log n) in all scenarios. 
// It's space complexity is not in-place require O(n) space.