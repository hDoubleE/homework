using System;
using System.IO;
// In Main read the entries given in the file input.txt (one line per entry) and store them into an array. 
// Make four copies of it. Then, on each copy call bubbleReverseSort, selectionReverseSort, mergeReverseSort, quickReverseSort. 
// For each of these measure the execution time (how long it took to run the reverse sorting) and display this time. Hint for measuring execution (see the class notes!)

// Class notes on timer are wrong and won't compile. Wrong namespace, it's System.Diagnostics, not System.Diagnosis. Just FYI to update slides.

namespace Sorting
{
    public class Program
    {
        public static void Main()
        {
            string path = "/your_path/here/input.txt";

            if (!File.Exists(path))
            {
                throw new ArgumentException("Not found.");
            }

            string[] LineArray = File.ReadAllLines(path);

            // Allocate memory for 4 array copies.
            string[] Copy1 = new string[LineArray.Length];
            string[] Copy2 = new string[LineArray.Length];
            string[] Copy3 = new string[LineArray.Length];
            string[] Copy4 = new string[LineArray.Length];

            // Copy file contents by line to Copy 1 Array.
            Array.Copy(LineArray, Copy1, LineArray.Length);

            // Create new timer object.
            var timer = System.Diagnostics.Stopwatch.StartNew();
            // Start and stop timer around sort.
            timer.Start();
            BubbleReverseSort(Copy1);
            timer.Stop();
            // Record time and disply.
            var elapsedMS1 = timer.ElapsedMilliseconds;
            Console.WriteLine($"Time for reverse bubble sort: {elapsedMS1}");
            // Reset timer.
            timer.Reset();

            // Copy file contents by line to Copy 2 Array.
            Array.Copy(LineArray, Copy2, LineArray.Length);

            // Start and stop timer around sort.
            timer.Start();
            SelectionReverseSort(Copy2);
            timer.Stop();
            // Record time and disply.
            var elapsedMS2 = timer.ElapsedMilliseconds;
            Console.WriteLine($"Time for reverse selection sort: {elapsedMS2}");
            // Reset timer.
            timer.Reset();

            // Copy file contents by line to Copy 3 Array.
            Array.Copy(LineArray, Copy3, LineArray.Length);

            // Start and stop timer around sort.
            timer.Start();
            MergeReverseSort(Copy2);
            timer.Stop();
            // Record time and disply.
            var elapsedMS3 = timer.ElapsedMilliseconds;
            Console.WriteLine($"Time for reverse Merge sort: {elapsedMS3}");
            // Reset timer.
            timer.Reset();

            // Copy file contents by line to Copy 4 Array.
            Array.Copy(LineArray, Copy3, LineArray.Length);

            // Start and stop timer around sort.
            timer.Start();
            QuickReverseSort(Copy2);
            timer.Stop();
            // Record time and disply.
            var elapsedMS4 = timer.ElapsedMilliseconds;
            Console.WriteLine($"Time for reverse Merge sort: {elapsedMS4}");

            // The Upshot: Bubble Sort is significantly slower than other sorting algorithms.
            // Runtimes for each sorting algorithm are the same as previously mentioned.
            // I removed the comparison counter from each sort.


        }

        public static void BubbleReverseSort(string[] arr)
        {
            for (int i = arr.Length; i > 0; i--)
            {

                bool swap = false;
                for (int j = 0; j < i - 1; j++)
                {
                    // In loop use Array.CompareTo to sort j and j+1
                    int compareStrings = arr[j].CompareTo(arr[j + 1]);
                    // If result of string comparison is -1, than j is < j+1, Swap!
                    if (compareStrings < 0)
                    {
                        swap = true;
                        string temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                // Else...nothing, just continue loop.
                if (!swap)
                {
                    break;
                }
            }
        }

        public static void SelectionReverseSort(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    // In loop use Array.CompareTo to sort j and j+1
                    int compareStrings = arr[minIndex].CompareTo(arr[j]);
                    // If result of string comparison is -1, mark index as min.
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
        }

        static void MergeReverseSort(string[] arr)
        {
            //temp buffer
            string[] tmp = new string[arr.Length];
            MergeReverse(arr, 0, arr.Length - 1, tmp);

        }
        static void MergeReverse(string[] arr, int start, int end, string[] tmp)
        {
            if (start < end)//we have at least two elements in the arr
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
            }
            while (i <= mid) // copy left overs
            {
                tmp[k] = arr[i];
                i++;
                k++;
            }
            while (j <= end)// copy left overs
            {
                tmp[k] = arr[j];
                j++;
                k++;
            }

            //move values back into arr (from tmp)
            for (k = start; k <= end; k++)
            {
                arr[k] = tmp[k];
            }
        }

        static void QuickReverseSort(string[] arr)
        {
            QuickReverseSort(arr, 0, arr.Length - 1);
        }
        static void QuickReverseSort(string[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex) // At least two elements
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
                int compareStrings = arr[i].CompareTo(pivotString);
                if (compareStrings >= 0)
                {
                    swapIndex++;
                    string temp1 = arr[swapIndex];
                    arr[swapIndex] = arr[i];
                    arr[i] = temp1;
                }
            }
            // swap arr[swapIndex + 1] with pivotValue(ie. arr[rightIndex])
            string temp2 = arr[swapIndex + 1];
            arr[swapIndex + 1] = arr[rightIndex];
            arr[rightIndex] = temp2;

            // return new index position for the pivot
            return swapIndex + 1;
        }
    }
}