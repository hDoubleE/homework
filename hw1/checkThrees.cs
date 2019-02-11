// Ask the user to enter a positive integer b. 
// Validate the input (to make sure it is positive). 
// Then output whether or not the number b is divisible by 3.

using System;

namespace HomeworkOne
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                // Prompt user for input.
                Console.WriteLine("Enter a positive number to check if divisible by three.");
                Console.WriteLine("Enter Q to Quit.\n");
                Console.Write("Your Number:");
        
                // Break loop if user quits.
                string strInput = Console.ReadLine();
                if (strInput == "q" || strInput == "Q")
                {
                    break;
                }

                // Use TryParse for Error Handling and conditional for value checking.
                else
                {
                    long.TryParse(strInput, out long input);
                    if (input > 0)
                    {
                        // Execute method and store result in bool.
                        bool result = DivisibleByThree(input);
                        // Process return using conditional. Display Result.
                        if (result)
                        {
                            Console.WriteLine($"{input} is divisible by 3.\n");
                        }
                        else
                        {
                            Console.WriteLine($"{input} is NOT divisible by 3.\n");
                        }
                    }
                }
            }
        }
        public static bool DivisibleByThree(long n)
        {
            // This is the modulus operator. I don't know what to say here. 
            // I put this in a method, because not coding methods is boring.
            if (n % 3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

// The Upshot: It's a pretty resilient program, try to break it.
// Coding user interfaces in console applications != Data Structures and Algorithms.
