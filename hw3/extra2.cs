using System;
using System.IO;
using System.Collections.Generic;

//Problem 2 [extra points] Write a program that opens a text file(“input.txt”) and reads its contents.
//Then using a stack it reverses the lines of the file and saves them into another file(“output.txt”). 
//Hint: use System.IO.File.WriteAllLines and System.IO.File.ReadAllLines,

namespace DataStructures
{
    public class Program
    {
        static void Main()
        {

            // Use C# class library Stack<T>

            Stack<string> S = new Stack<string>();

            string readPath = "/Your/File/Path/Here/input.txt";
            string writePath = "/Your/Write/Path/Here/";

            // Throw exception if no file found, still compiles.
            if (!System.IO.File.Exists(readPath))
            {
                throw new ArgumentException("File not found.");
            }

            // Input text to string array where each element is one line.
            string[] linesOfText = File.ReadAllLines(readPath);

            // Iterate through string array and push lines onto stack.
            foreach (string line in linesOfText)
            {
                S.Push(line);
            }

            // Uncomment to test original string input.

            //foreach (string i in S)
            //{
            //    Console.WriteLine(i);
            //}

            // Write to same string array by popping off stack, reversing the array text.
            for (int i = 0; i < linesOfText.Length; i++)
            {
                string newLine = S.Peek();
                linesOfText[i] = newLine;
                S.Pop();
            }

            // Uncomment to test reversed array...

            //foreach (var line in linesOfText)
            //{
            //    Console.WriteLine(line);
            //}

            File.WriteAllLines(writePath, linesOfText);

            //The Upshot: O(n) time and O(n) space (array, stack). I could place a lot of this in a method.
        }
    }
}