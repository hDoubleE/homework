using System;

// Problem 1: (Not Extra) Reverse Queue using Stack. Use implemented Queue data structure, based on implemented Linked List.

namespace DataStructures
{
    public class Program
    {
        static void Main()
        {
            LinkedQueue<int> Q = new LinkedQueue<int>();

            // Loop to enqueue nums...
            for (int i = 1; i < 7; i++)
            {
                Q.Enqueue(i);
            }

            Console.WriteLine("Print Original Queue:");
            Q.Print();

            Console.WriteLine(); // Newline.


            // This method below is the where the magic happens...go to definition below.
            // Reverses Queue using stack...
            Q.ReverseQueue();

            Console.WriteLine("Print Reversed Queue:");

            Q.Print();

            // The Upshot: The ReverseQueue() method runs in O(n) time with O(n) space required.
            // Really it's O(2n) time -> O(n), so still linear time.
            // I modularized the Reverse() method into two separate functions using generics.
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

            if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");

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
                throw new InvalidOperationException("Queue is empty.");

            return First.Value;
        }

        /// <summary>
        /// Reverses the queue. Calls Helper method.
        /// Pops item from returned stack and Enqueus them in reverse order.
        /// </summary>
        /// <returns>Reversed queue.</returns>
        public LinkedQueue<T> ReverseQueue()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");

            LinkedQueue<T> Q = this;

            var tempStack = QueueToStack(Q);

            while (!tempStack.IsEmpty())
            {
                T popped = tempStack.Peek();
                tempStack.Pop();
                Q.Enqueue(popped);
            }
            return Q;
        }

        /// <summary>
        /// Takes input queue and pushes items onto stack.
        /// </summary>
        /// <returns> The stack containing queue items.</returns>
        /// <param name="Q">Original queue.</param>
        public LinkedStack<T> QueueToStack(LinkedQueue<T> Q)
        {
            LinkedStack<T> S = new LinkedStack<T>();
            Node current = Q.First;
            while (current.Next != null)
            {
                Node removed = current;
                S.Push(removed.Value);
                Q.Dequeue();
                current = current.Next;
            }
            return S;
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
        /// Determines if Queue is Empty.
        /// </summary>
        /// <returns>Bool if list empty.</returns>
        public bool IsEmpty() => First == null;

        /// <summary>
        /// Repesents a node in the queue.
        /// </summary>
        internal class Node
        {
            /// <summary>
            /// The data stored in the node.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// The next node.
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

    /// <summary>
    /// Represents a linked list based stack data structure.
    /// </summary>
    /// <typeparam name="T">The stored data type.</typeparam>
    public class LinkedStack<T>
    {
        /// <summary>
        /// The head node of the linked stack.
        /// </summary>
        internal Node Top { get; set; }

        /// <summary>
        /// Gets the number of elements in the stack.
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Creates a new instance of the stack class that is empty.
        /// </summary>
        public LinkedStack()
        {
            Count = 0;
            Top = null;
        }

        /// <summary>
        /// Inserts an item at the top of the stack.
        /// </summary>
        /// <param name="item">The item to push onto the stack. The value can be null for reference types.</param>
        public void Push(T item)
        {
            Top = new Node(item, Top);
            Count++;
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>The item removed from the top of the stack.</returns>
        public void Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            T item = Top.Value;

            Top = Top.Next;
            Count--;
        }

        /// <summary>
        /// Returns the item at the top of the stack without removing it.
        /// </summary>
        /// <returns>The item at the top of the stack.</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            return Top.Value;
        }

        /// <summary>
        /// Print this instance.
        /// </summary>
        public void Print()
        {
            Node current = Top;
            while (current != null)
            {
                Console.WriteLine($"| {current.Value} |");
                current = current.Next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Determines if stack is Empty.
        /// </summary>
        /// <returns>Bool if list empty.</returns>
        public bool IsEmpty() => Top == null;

        /// <summary>
        /// Repesents a node in the stack.
        /// </summary>
        internal class Node
        {
            /// <summary>
            /// The data stored in the node.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// The next node.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Creates a new node with the specified value,
            /// pointing to the next specified node.
            /// </summary>
            /// <param name="data">The data stored in the node.</param>
            /// <param name="next">The next node.</param>
            public Node(T data, Node next)
            {
                Value = data;
                Next = next;
            }
        }
    }
}