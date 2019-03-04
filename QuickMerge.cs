using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Program
    {
        static void Main()
        {
            int[] sample = { 42, 16, 27, 35, 6, 19, 83, 26};
            foreach (int item in sample)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Solution.QuickSort(sample);
            foreach (int item in sample)
            {
                Console.Write(item + " ");
            }
        }
    }
    public class Solution
    {
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, new int[arr.Length], 0, arr.Length - 1);
        }

        public static void MergeSort(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
            {
                return;
            }
            int middle = (leftStart + rightEnd) / 2;
            MergeSort(arr, temp, leftStart, middle);
            MergeSort(arr, temp, middle + 1, rightEnd);
            MergeHalves(arr, temp, leftStart, rightEnd);
        }

        public static void MergeHalves(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            int leftEnd = (leftStart + rightEnd) / 2; // Same as middle.
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1; // total number of elements to copy over.

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (arr[left] <= arr[right])
                {
                    temp[index] = arr[left];
                    left++;
                }
                else
                {
                    temp[index] = arr[right];
                    right++;
                }
                index++;
            }

            // Only one of these will run, the other is out of bounds. 
            Array.Copy(arr, left, temp, index, leftEnd - left + 1);
            Array.Copy(arr, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, arr, leftStart, size);
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivot = arr[left];
            int index = Partition(arr, left, right, pivot);
            QuickSort(arr, left, index - 1);
            QuickSort(arr, index, right);
        }

        public static int Partition(int[] arr, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }
            return left;
        }

    }
}