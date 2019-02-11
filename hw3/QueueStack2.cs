using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Program
    {
        static void Main()
        {
            StackedQueue<int> s = new StackedQueue<int>();

            s.Enqueue(1);
            s.Enqueue(2);
            s.Enqueue(3);
            s.Print();
            s.Dequeue();
            s.Print();
            s.Dequeue();
            s.Print();
            s.Dequeue();
            s.Print();
        }
    }

    public class StackedQueue<T>
    {
        Stack<T> mainStack = new Stack<T>();
        Stack<T> tempStack = new Stack<T>();

        /// <summary>
        /// Gets the number of elements in the stack.
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Creates a new instance of the stack class that is empty.
        /// </summary>
        public StackedQueue()
        {
            Count = 0;
        }

        /// <summary>
        /// Enqueue the specified item by pushing onto primary stack.
        /// If stack is full, first empty stack, then push, then refill.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Enqueue(T item)
        {

            if (IsEmpty())
            {
                mainStack.Push(item);
                Count++;
            }
            else
            {
                EmptyMainFillTemp();

                mainStack.Push(item);
                Count++;

                EmptyTempFillMain();
            }
        }

        /// <summary>
        /// Dequeue is just Pop from primary stack.
        /// </summary>
        /// <returns>The value of item being popped.</returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T item = mainStack.Peek();
            mainStack.Pop();
            Count--;
            return item;
        }

        /// <summary>
        /// Peek this instance. Inherited from LinkedStack class.
        /// </summary>
        /// <returns>The top value on stack.</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            return mainStack.Peek();
        }

        /// <summary>
        /// Prints in queue format. More of a queue than a stack method.
        /// Inherits Node.Next functionality from Linked Stack class.
        /// </summary>
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The queue is empty.");
                return;
            }
            foreach (var i in mainStack)
            {
                Console.Write($"{i} <-");
            }
            Console.WriteLine("Last");
        }
        
        /// <summary>
        /// Determines if primary stack is Empty.
        /// </summary>
        /// <returns>Bool if list empty.</returns>
        public bool IsEmpty() 
        {
            return mainStack.Count == 0;
        }

        /// <summary>
        /// Empties the primary stack and fills the temp stack.
        /// </summary>
        private void EmptyMainFillTemp()
        {
            while (mainStack.Count > 0)
            {
                // Empty mainStack.
                var temp = mainStack.Peek();
                mainStack.Pop();
                // Fill mainStack.
                tempStack.Push(temp);
            }
        }

        /// <summary>
        /// Empties the temp stack and fills the primary stack.
        /// </summary>
        private void EmptyTempFillMain()
        {
            while (tempStack.Count > 0)
            {
                // Empty tempStack.
                var temp2 = tempStack.Peek();
                tempStack.Pop();
                // Fill mainStack.
                mainStack.Push(temp2);
            }
        }
    }
}