using System;
// Modify the selection sort algorithm seen in class so it works with an array of strings AND the array will have the values sorted in reverse. 
// Also add a local variable count (use long count) of the number of comparisons that were performed. Display it before exiting this method.   
// Call it:  static void selectionReverseSort(string[] arr)

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
            SelectionReverseSort(data);

            // Print sorted data.
            Console.Write("\nReverse Sorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }
        }

        public static void SelectionReverseSort(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int numComparisons = 0;
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    // In loop use Array.CompareTo to sort j[word] and j+1
                    int compareStrings = arr[minIndex].CompareTo(arr[j]);
                    numComparisons++;
                    // If result of string comparison is -1, mark j index as min.
                    if (compareStrings < 0)
                    {
                        minIndex = j;
                    }
                }
                // After one run of inner loop, swap!
                if (i != minIndex)
                {
                    string temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
            }
            Console.WriteLine($"\nNumber of Comparisons: {numCompare}");
        }
    }
}

// The Upshot: Selection Sort runs O(n^2) time in all cases. It's O(1) space complexity
// is it's only re-deaming factor. Even Bubble and insertion are good in certain cases.
// I honestly don't know why anyone would ever use it.  