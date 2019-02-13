using System;
using System.Collections.Generic;

// Problem 1 [25 points] Let Q be a non-empty queue, and let S be an empty stack.
// Write a C# program that reverses the order of the elements in Q, using S.

// C# Library implementation using Queue<T> and Stack<T>.
// Runtime of work O(n) with O(n) space for additional Stack. 

namespace hw3_extra1
{
    public class Program
    {
        static void Main()
        {
            Queue<int> Q = new Queue<int>();

            // Loop to enqueue nums...
            for (int i = 1; i < 7; i++)
            {
                Q.Enqueue(i);
            }

            Console.Write("Original Queue Contents: ");

            // Loop to print Q contents...
            foreach (int i in Q)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine(); // Newline.

            // Output:
            // Original Queue Contents: 1 2 3 4 5 6 


            // Call static method from Solution class...
            Q = Solution.ReverseQueue(Q);

            // Print the Reversed contents of Q...
            Console.Write("Reversed Queue Contents: ");
            foreach (int i in Q)
            {
                Console.Write($"{i} ");
            }

            // Output:
            // Reversed Queue Contents: 6 5 4 3 2 1
        }

        public class Solution
        {
            public static Queue<int> ReverseQueue(Queue<int> Q)
            {
                // Declare Stack 'S'...
                Stack<int> S = new Stack<int>();

                // Loop Q and Dequeue nums...
                for (int i = 1; i < 7; i++)
                {
                    int qNum = Q.Dequeue();
                    S.Push(qNum);
                }

                // Loop S and Pop each num, 
                // Enqueue popped num into Q...
                for (int i = 1; i < 7; i++)
                {
                    int poppedNum = S.Pop();
                    Q.Enqueue(poppedNum);
                }

                // Return reversed Q.
                return Q;
            }
        }
    }
}