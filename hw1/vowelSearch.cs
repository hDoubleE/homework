using System;
using System.Collections.Generic;

// Problem:
// Ask the user to enter a string(e.g. “Welcome to Saint Martin’s U!”).
// Your program should count and display the total number of vowels (A, E, I, O, U)
// Count both uppercase and lowercase vowels – in that given input. In the example above, the output should 9.

// I wrote three methods experimenting with efficiency and achieved O(n), the best possible runtime for this problem.

namespace CompileTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for input.
            Console.Write("Enter a sentence: ");

            // Invoke ToLower on ReadLine and store user's string input in the "input" variable.
            string input = Console.ReadLine().ToLower();

            // Call each of three methods with user input string.  
            Console.WriteLine($"Method 1 returned: {countVowelsArray(input)} vowels");
            Console.WriteLine($"Method 2 returned: {countVowelsList(input)} vowels");
            Console.WriteLine($"Method 3 returned: {countVowelsDict(input)} vowels");

            int countVowelsArray(string s)
            {
                // Declare counter variable and char array containing all vowels, not y.
                int count = 0;
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

                // Loop through string (n).
                for (int i = 0; i < s.Length; i++)
                {
                    // Loop through vowels array (m).
                    for (int j = 0; j < vowels.Length; j++)
                    {
                        // Compare each string character to each vowel.
                        if (s[i] == vowels[j])
                        {
                            // Increment counter if match found. 
                            count++;
                        }
                    }
                }
                return count;
            }

            // The Upshot: This brute force approach works, but is O(n*m) with a nested loop. Yuck. 

            int countVowelsList(string s)
            {
                // Declare counter variable and a generic List<T> of type char containing all vowels, not y.
                int count = 0;
                List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

                // Loop through string (n).
                for (int i = 0; i < s.Length; i++)
                {
                    // I wanted to work with a built in List method here instead of a nested loop. 
                    if (vowels.Contains(s[i]))
                    {
                        count++;
                    }
                }
                return count;
            }

            // The Upshot: Unfortunately the List.Contains method is still O(n), where n is List size. So we're still at O(n*m).
            // Runtime Ref: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=netframework-4.7.2#remarks

            int countVowelsDict(string s)
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

            // The Upshot: Using a Dictionary and the O(1) ContainsKey method. I'm at a runtime of O(n).
            // Runtime Ref: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2#remarks
            // From Ref: Retrieving a value by using its key is very fast, close to O(1), because 
            // the Dictionary<TKey,TValue> class is implemented as a hash table.
        }
    }
}