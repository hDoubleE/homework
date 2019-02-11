using System;
using System.Collections.Generic;
using System.IO;

namespace HomeworkOne
{
    public class Program
    {
        static void Main()
        {
            // You really need a valid path here or it will throw an exception.
            string s = File.ReadAllText(@"C:\<Valid>\<Path>\<Here>\input.txt");
            // Execute function.
            Console.WriteLine(countVowelsDict(s));

        }
        public static int countVowelsDict(string s)
        {
            // Declare counter variable and Dictionary<K, T> of Key type char and value int, containing all vowels, not y.
            int count = 0;
            Dictionary<char, int> vowels = new Dictionary<char, int>()
                {
                    {'a', 0},
                    {'e', 0},
                    {'i', 0},
                    {'o', 0},
                    {'u', 0},
                };

            // Loop through string (n).
            for (int i = 0; i < s.Length; i++)
            {
                // Check if char in string is a key in Dictionary: O(1).
                if (vowels.ContainsKey(s[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}

// The Upshot: There are 2580 vowels in the Constitution of the United States of America.
// I recycled my fastest runtime vowel search algorithm seen previously, O(n).

