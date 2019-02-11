using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Program
    {
        static void Main()
        {
            LinkedQueue<int> que = new LinkedQueue<int>();
            que.Enqueue(14);
            que.Enqueue(32);
            que.Enqueue(16);
            que.Enqueue(12);
            que.Print();
            Console.WriteLine(que.Peek());
            que.Dequeue();
            que.Print();
            que.Dequeue();
            que.Print();


        }
    }

    /// <summary>
    /// Represents a linked list based queue structure.
    /// </summary>
    /// <typeparam name="T">The stored data type.</typeparam>
    public class LinkedQueue<T>
    {
        /// <summary>
        /// The head (first) node of the linked queue.
        /// </summary>
        internal Node First { get; set; }

        /// <summary>
        /// The tail (last) node of the linked queue.
        /// </summary>
        internal Node Last { get; set; }

        /// <summary>
        /// Gets the number of elements in the queue.
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Creates a new instance of the queue class that is empty and has default capacity.
        /// Default constructor is not required as it's implicit.
        /// </summary>
        public LinkedQueue() { }

        /// <summary>
        /// Adds an item at the end of the queue.
        /// </summary>
        /// <param name="item">The item to add at the end of the queue. The value can be null for reference types.</param>
        public void Enqueue(T item)
        {
            Count++;

            if (Last == null)
            {
                First = new Node(item, null);
                Last = First;
            }
            else
            {
                var newNode = new Node(item, null);
                Last.Next = newNode;
                Last = newNode;
            }
        }

        /// <summary>
        /// Removes and returns the item at the beginning of the queue.
        /// </summary>
        /// <returns>The item removed from the beginning of the queue.</returns>
        public T Dequeue()
        {

            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");
            Count--;

            T temp = First.Value;
            First = First.Next;
            if (First == null) Last = null;

            return temp;
        }


        /// <summary>
        /// Returns the item at the beginning of the queue without removing it.
        /// </summary>
        /// <returns>The item at the beginning of the queue.</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty!");

            return First.Value;
        }

        /// <summary>
        /// Print this instance.
        /// </summary>
        public void Print()
        {
            Node current = First;
            while (current != null)
            {
                Console.Write($"{current.Value} <- ");
                current = current.Next;
            }
            Console.Write("Last");
            Console.WriteLine();
        }

        /// <summary>
        /// Repesents a node in the queue.
        /// </summary>
        internal class Node
        {
            /// <summary>
            /// The data stored in the <see cref="Node"/>.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// The next <see cref="Node"/>.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Creates a new node with the given data and pointing to the given next node.
            /// </summary>
            /// <param name="value">The data stored in the node.</param>
            /// <param name="next">The next node.</param>
            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}