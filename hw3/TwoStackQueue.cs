using System;
using System.IO;

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
        LinkedStack<T> mainStack = new LinkedStack<T>();
        LinkedStack<T> tempStack = new LinkedStack<T>();

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
        public StackedQueue()
        {
            Count = 0;
            Top = null;
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
                this.Count++;
                mainStack.Count++;
            }
            else
            {
                EmptyMainFillTemp();

                mainStack.Push(item);
                this.Count++;
                mainStack.Count++;

                EmptyTempFillMain();
            }
        }

        /// <summary>
        /// Empties the primary stack and fills the temp stack.
        /// </summary>
        public void EmptyMainFillTemp()
        {
            while (mainStack.Count > 0)
            {
                // Empty mainStack.
                var temp = mainStack.Peek();
                mainStack.Pop();
                mainStack.Count--;
                // Fill mainStack.
                tempStack.Push(temp);
                tempStack.Count++;
            }
        }


        /// <summary>
        /// Empties the temp stack and fills the primary stack.
        /// </summary>
        public void EmptyTempFillMain()
        {
            while (tempStack.Count > 0)
            {
                // Empty tempStack.
                var temp2 = tempStack.Peek();
                tempStack.Pop();
                tempStack.Count--;
                // Fill mainStack.
                mainStack.Push(temp2);
                mainStack.Count++;
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
                throw new InvalidOperationException("Queue is empty!");
            }

            T item = mainStack.Peek();
            mainStack.Pop();
            mainStack.Count--;
            this.Count--;
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
                throw new InvalidOperationException("Queue is empty!");
            }
            return mainStack.Peek();
        }


        /// <summary>
        /// Prints in queue format. More of a queue than a stack method.
        /// Inherits Node.Next functionality from Linked Stack class.
        /// </summary>
        public void Print()
        {
            var current = mainStack.Top;
            if (IsEmpty())
            {
                Console.WriteLine("The stacked queue is empty.");
                return;
            }

            while (current != null)
            {
                Console.Write($"{current.Value} <- ");
                current = current.Next;
            }
            Console.Write("Last");
            Console.WriteLine();
        }

        /// <summary>
        /// Determines if stack is Empty.
        /// </summary>
        /// <returns>Bool if list empty.</returns>
        public bool IsEmpty() 
        {
            return mainStack.IsEmpty();
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
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T item = Top.Value;

            Top = Top.Next;
            Count--;

            return item;
        }

        /// <summary>
        /// Returns the item at the top of the stack without removing it.
        /// </summary>
        /// <returns>The item at the top of the stack.</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

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