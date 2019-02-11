using System;

//Problem 2 [30 points]: Modify the code from class (make sure to use it!!!) 
//so it works with integers(as we saw in class) but so it uses two links for each node, 
//one for the next and one for the previous node. This is called doubly linked list.
//In addition to the methods in class also add a method void printReverse() that prints in reverse the list
//(it displays the last element, then the one next to last, …, and lastly it will display the first element)

namespace DataStructures
{
    public class Program
    {
        public static void Main()
        {
            // Declare new doubly linked list of type int, using Generics<T>. 
            // Big Oh notated below in Main.
            DoublyLinkedList<int> ll = new DoublyLinkedList<int>();
            Console.WriteLine("Populate new doubly linked list of type int.");

            // AddFirst: O(1)
            ll.AddFirst(3);

            // Create new node to insert.
            var n = new Node<int>(7);
            // AddLast by node, O(1).
            ll.AddLast(n);

            // Insert 5 before the 7 node, O(n).
            ll.AddBefore(n, 5);
            // AddLast by value, O(1).
            ll.AddLast(9);
            Console.WriteLine("Print:");
            ll.Print(); // O(n)
            Console.WriteLine("Print Reverse:");
            // Print Reverse: O(n)
            ll.PrintReverse(); 
            Console.WriteLine("Remove nodes using RemoveFirst, RemoveLast, Remove(value) methods.");
            ll.Remove(7); // Remove by value (search): O(n)
            ll.Print();
            ll.RemoveFirst(); // O(1)
            ll.Print();
            ll.RemoveLast(); // O(1)
            ll.Print();
            ll.Clear(); // O(1)
            Console.WriteLine("Clear linked list.");
            Console.WriteLine($"Linked list is Empty: {ll.IsEmpty()}"); // O(1)

            // The Upshot: Doubly Linked Lists improve all operations at Tail from O(n) to O(1).
            // Still O(n) to search or print, methods requiring complete or partial iteration.
            // I used a Count variable, unlike the single list, because they improve the code.

        }
    }

    /// <summary>
    /// Represents a node in the linked list. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T">The stored data type.</typeparam>
    public sealed class Node<T>
    {
        /// <summary>
        /// Gets the value contained in the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets the next node in the linked list.
        /// </summary>
        public Node<T> Next { get; internal set; }

        /// <summary>
        /// Gets the previous node in the linked list.
        /// </summary>
        public Node<T> Previous { get; internal set; }

        /// <summary>
        /// Constructor creates a new Node instance with the specified value.
        /// </summary>
        /// <param name="value">The value contained in the Node.</param>
        public Node(T value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Represents a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The stored data type.</typeparam>
    public class DoublyLinkedList<T>
    {
        /// <summary>
        /// Gets the first node of the doubly linked list.
        /// </summary>
        public Node<T> Head { get; internal set; }

        /// <summary>
        /// Gets the last node of the doubly linked list.
        /// </summary>
        public Node<T> Tail { get; internal set; }

        /// <summary>
        /// Gets the number of elements in the doubly linked list.
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Creates a new instance of the doubly linked list class that is empty.
        /// </summary>
        public DoublyLinkedList()
        {
            Count = 0;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the start of the doubly linked list.
        /// </summary>
        /// <param name="value">The value to add at the start of the doubly linked list.</param>
        /// <returns>The new Node containing the value.</returns>
        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);

            AddFirst(newNode);
        }

        /// <summary>
        /// Adds the specified new node at the start of the doubly linked list.
        /// </summary>
        /// <param name="node">The new Node to add at the start of the doubly linked list.</param>
        public void AddFirst(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            node.Previous = null;
            node.Next = Head;
            if (Head != null) Head.Previous = node;
            Head = node;
            Count++;

            if (Head.Next == null) Tail = Head;
        }

        /// <summary>
        /// Adds a new node containing the specified value after the specified existing node in the doubly linked list.
        /// </summary>
        /// <param name="node">The Node after which to insert a new Node containing the value.</param>
        /// <param name="value">The value to add to the doubly linked list.</param>
        /// <returns>The new Node containing the value.</returns>
        public void AddAfter(Node<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (node == Tail)
            {
                AddLast(value);
            }

            var newNode = new Node<T>(value);

            AddAfter(node, newNode);
        }

        /// <summary>
        /// Adds the specified new node after the specified existing node in the doubly linked list.
        /// </summary>
        /// <param name="node">The Node after which to insert newNode.</param>
        /// <param name="newNode">The new Node to add to the doubly linked list.</param>
        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (newNode == null) throw new ArgumentNullException(nameof(newNode));

            if (node == Tail)
            {
                AddLast(newNode);
                return;
            }

            node.Next.Previous = newNode;
            newNode.Next = node.Next;

            newNode.Previous = node;
            node.Next = newNode;

            Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value before the specified existing node in the doubly linked list.
        /// </summary>
        /// <param name="node">The Node before which to insert a new Node containing the value.</param>
        /// <param name="value">The value to add to the doubly linked list.</param>
        /// <returns>The new Node containing the value.</returns>
        public void AddBefore(Node<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (node == Head)
            {
                AddFirst(value);
            }

            var newNode = new Node<T>(value);

            AddBefore(node, newNode);
        }

        /// <summary>
        /// Adds the specified new node before the specified existing node in the doubly linked list.
        /// </summary>
        /// <param name="node">The Node before which to insert newNode.</param>
        /// <param name="newNode">The new Node to add to the doubly linked list.</param>
        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (newNode == null) throw new ArgumentNullException(nameof(newNode));

            if (node == Head)
            {
                AddFirst(newNode);
                return;
            }

            node.Previous.Next = newNode;
            newNode.Previous = node.Previous;

            newNode.Next = node;
            node.Previous = newNode;

            Count++;
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the doubly linked list.
        /// </summary>
        /// <param name="value">The value to add at the end of the doubly linked list.</param>
        public void AddLast(T value)
        {
            if (Count == 0)
            {
                AddFirst(value);
            }

            var newNode = new Node<T>(value);

            AddLast(newNode);
        }

        /// <summary>
        /// Adds the specified new node at the end of the doubly linked list.
        /// </summary>
        /// <param name="node">The new Node to add at the end of the doubly linked list.</param>
        public void AddLast(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (Count == 0)
            {
                AddFirst(node);
                return;
            }

            node.Next = null;
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
            Count++;
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the doubly linked list.
        /// </summary>
        /// <param name="value">The value to remove from the doubly linked list.</param>
        /// <returns>true if the value is successfully removed; otherwise false. It also returns false if the value was not found in the doubly linked list.</returns>
        public bool Remove(T value)
        {
            if (Count == 0)
            {
                return false;
            }

            if (Equals(Head.Value, value))
            {
                RemoveFirst();
                return true;
            }

            var curNode = Head.Next;

            while (curNode != null)
            {
                if (Equals(curNode.Value, value))
                {
                    curNode.Previous.Next = curNode.Next;

                    if (curNode.Next != null)
                    {
                        curNode.Next.Previous = curNode.Previous;
                    }
                    else
                    {
                        Tail = curNode.Previous;
                    }

                    curNode.Next = null;
                    curNode.Previous = null;
                    Count--;
                    return true;
                }

                curNode = curNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes the specified node from the doubly linked list.
        /// </summary>
        /// <param name="node">The Node to remove from the doubly linked list.</param>
        public void Remove(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (node == Head)
            {
                RemoveFirst();
                return;
            }

            if (node == Tail)
            {
                RemoveLast();
                return;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Next = null;
            node.Previous = null;
            Count--;
        }

        /// <summary>
        /// Removes the node at the start of the doubly linked list.
        /// </summary>
        public void RemoveFirst()
        {
            if (Count == 0) throw new InvalidOperationException("The DoublyLinkedList is empty.");

            var oldFirst = Head;
            Head = Head.Next;
            oldFirst.Next = null;
            oldFirst.Previous = null;

            if (Head != null)
                Head.Previous = null;
            else
                Tail = null;

            Count--;
        }

        /// <summary>
        /// Removes the node at the end of the doubly linked list.
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 0) throw new InvalidOperationException("The DoublyLinkedList is empty.");

            var oldLast = Tail;
            Tail = Tail.Previous;
            oldLast.Next = null;
            oldLast.Previous = null;

            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }

            Count--;

        }

        /// <summary>
        /// Determines whether an value is in the doubly linked list.
        /// </summary>
        /// <param name="value">The value to search in the doubly linked list.</param>
        /// <returns>returns true if the value is found; otherwise false.</returns>
        public bool Contains(T value)
        {
            if (Count == 0) return false;

            var curNode = Head;

            while (curNode != null)
            {
                if (Equals(curNode.Value, value))
                {
                    return true;
                }

                curNode = curNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes all nodes from the doubly linked list.
        /// </summary>
        public void Clear()
        {
            if (Count == 0) return;

            var curNode = Head;
            var lastNode = curNode;
            while (curNode != null)
            {
                curNode = curNode.Next;
                lastNode.Next = null;
                lastNode.Previous = null;
                lastNode = curNode;
            }

            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Prints the doubly linked list to console.
        /// </summary>
        public void Print()
        {
            var curNode = Head;

            while (curNode != null)
            {
                Console.Write($"{curNode.Value} -> ");
                curNode = curNode.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
        /// <summary>
        /// Prints the doubly linked list in reverse to console.
        /// Prints Tail first and Head last.
        /// </summary>
        public void PrintReverse()
        {
            var curNode = Tail;

            while (curNode != null)
            {
                Console.Write($"{curNode.Value} -> ");
                curNode = curNode.Previous;
            }
            Console.Write("null");
            Console.WriteLine();
        }

        /// <summary>
        /// Determines if list is Empty.
        /// </summary>
        /// <returns>Bool if list empty.</returns>
        public bool IsEmpty() => Head == null;
    }
}