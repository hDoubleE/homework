using System;

namespace Sorting
{
     public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter some numbers, separated by spaces:");

            // Process input string into string array.
            string strInput = Console.ReadLine().Trim();
            string[] strArray = strInput.Split(' ');

            // Parse out string array into integer array.
            int[] data = new int[strArray.Length];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = int.Parse(strArray[i]);
            }

            // Print unsorted data.
            Console.Write("\nUnsorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }

            // Sort data.
            BubbleSort(data);

            // Print sorted data.
            Console.Write("\nSorted: ");
            foreach (var i in data)
            {
                Console.Write($"{i} ");
            }
        }

        public static void BubbleSort(int[] arr)
        {
            for (int i = arr.Length; i > 0; i--)
            {
                bool swap = false;
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap = true;
                        int highValue = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = highValue;
                    }
                }
                if (!swap)
                {
                    break;
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int lowest = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[lowest])
                    {
                        lowest = j;
                    }
                }
                if (i != lowest)
                {
                    int temp = arr[lowest];
                    arr[lowest] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && arr[j] < arr[j - 1]; j--)
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                }
            }
        }

    }
}