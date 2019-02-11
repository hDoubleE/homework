using System;
// Modify the bubble sort algorithm seen in class so it works with an array of strings AND the array will have the values sorted in reverse. 
// Also add a local variable count (use long count) of the number of comparisons that were performed. Display it before exiting this method.   
// Call it:  static void bubbleReverseSort(string[] arr)
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
            BubbleReverseSort(data);

            // Print sorted data.
            Console.Write("\nReverse Sorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }
        }

        public static void BubbleReverseSort(string[] arr)
        {
            long numCompare = 0;
            for (int i = arr.Length; i > 0; i--)
            {

                bool swap = false;
                for (int j = 0; j < i - 1; j++)
                {
                    // In loop use Array.CompareTo to sort j and j+1
                    int compareStrings = arr[j].CompareTo(arr[j + 1]);
                    numCompare++;
                    // If result of string comparison is -1, than j[word] is < j+1, Swap!
                    if (compareStrings < 0)
                    {
                        swap = true;
                        string temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                // Else...nothing, just continue loop.
                // Swap checking still optimizes loop.
                if (!swap)
                {
                    Console.WriteLine($"\nNumber of Comparisons: {numCompare}");
                    break;
                }
            }
        }
    }
}

// The Upshot: Bubble sort is the easiest to implement on a whim.
// Runtime is: O(n^2) in worse and average case and O(n) in the best case.