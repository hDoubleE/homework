using System;




namespace Homework3_Problem3
{
    public class Program
    {
        static void Main()
        {
            // Create Q, based on two stacks.
            StackedQueue<int> Q = new StackedQueue<int>();

            // Loop to fill Q with odd nums.
            for (int i = 1; i < 10; i += 2)
            {
                Q.Enqueue(i);
            }

            // Print.
            Q.Print();
            // Dequeue.
            Q.Dequeue();
            Q.Dequeue();
            // Print.
            Q.Print();

            // The Upshot: Enquue is exspensive if stack is full. O(2n) or O(n).
            // Pop all into holding stack. Add one item to bottom. Pop all items back onto stack.
            // Dequeue is O(1), just Pop from main stack. 
            // Print inherits from Linked list using .next, so O(n).
        }
    }

    /// <summary>
    /// Represents a linked list based queue data structure.
    /// </summary>
    /// <typeparam name="T">The stored data type.</typeparam>
    public class StackedQueue<T>
    {
        LinkedStack<T> mainStack = new LinkedStack<T>();
        LinkedStack<T> tempStack = new LinkedStack<T>();

        /// <summary>
        /// Gets the number of elements in the queue.
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Creates a new instance of the queue class that is empty and has default capacity.
        /// Default constructor is not required as it's implicit.
        /// </summary>
        public StackedQueue()
        {
            Count = 0;
        }

        /// <summary>
        /// Adds an item at the end of the queue.
        /// </summary>
        /// <param name="item">The item to add at the end of the queue. The value can be null for reference types.</param>
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

            if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");

            Count--;

            T item = mainStack.Peek();
            mainStack.Pop();
            Count--;
            return item;
        }


        /// <summary>
        /// Returns the item at the beginning of the queue without removing it.
        /// </summary>
        /// <returns>The item at the beginning of the queue.</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            return mainStack.Peek();
        }

        /// <summary>
        /// Print this instance.
        /// </summary>
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The queue is empty.");
                return;
            }
            mainStack.Print();
        }

        /// <summary>
        /// Determines if mainStack is Empty.
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
                Console.Write($"{current.Value} ");
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