using System;

//Problem 1 [30 points]: What we saw in class was a singly linked list, 
//because there was a link from one node to the next node.Modify the code in class 
//(make sure to use it!!!) so it works with strings instead of integers.

namespace DataStructures
{
    public class Program
    {
        public static void Main()
        {
            // Declare new linked list of type string, using Generics<T>. 
            // Big Oh notated below in Main.
            SinglyLinkedList<string> ll = new SinglyLinkedList<string>();
            Console.WriteLine("Populate new linked list using AddFirst, AddLast and Insert methods.");
            // O(1)
            ll.AddFirst("Three");
            ll.Print();

            // Create new node to insert before, O(1).
            Node<string> n = new Node<string>("Seven");
            // AddLast by node, O(n).
            ll.AddLast(n);
            ll.Print();

            // Insert 5 before the 7 node, O(n).
            ll.InsertBefore(n, "Five");
            ll.Print();
            // AddLast by value, O(n).
            ll.AddLast("Nine");
            ll.Print();

            Console.WriteLine("Remove nodes using RemoveFirst, RemoveLast, Remove(value) methods.");
            ll.Remove("Seven"); // O(n)
            ll.Print(); // O(n)
            ll.RemoveFirst(); // O(1)
            ll.Print();
            ll.RemoveLast(); // O(n)
            ll.Print();
            ll.Clear(); // O(1)
            Console.WriteLine("Clear linked list.");
            Console.WriteLine($"Linked list is Empty: {ll.IsEmpty()}"); // O(1)
        }
    }

    /// <summary>
    /// Node class represents a node in the linked list. 
    /// This class cannot be inherited: sealed.
    /// </summary>
    /// <typeparam name="T">The stored data type.</typeparam>
    public sealed class Node<T>
    {
        /// <summary>
        /// Value property gets the value contained in Node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Next property gets the next node in the linked list.
        /// </summary>
        public Node<T> Next { get; internal set; }

        /// <summary>
        /// Constructor initializes Node values.
        /// </summary>
        /// <param name="value">The value contained in Node.</param>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }

    }

    /// <summary>
    /// Class represents a singly linked list.
    /// </summary>
    /// <typeparam name="T">The data type stored in list.</typeparam>
    public class SinglyLinkedList<T>
    {
        /// <summary>
        /// Gets the first node of the linked list.
        /// </summary>
        public Node<T> Head { get; internal set; }

        /// <summary>
        /// Constructor creates new instance of empty linked list.
        /// </summary>
        public SinglyLinkedList()
        {
            Head = null;
        }

        /// <summary>
        /// Creates a new node containing specified value. 
        /// Calls method overload and passes new node.
        /// </summary>
        /// <param name="value">The value to add at the start of the linked list.</param>
        /// <returns>The new node containing the value.</returns>
        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);

            AddFirst(newNode);
        }

        /// <summary>
        /// Adds the new node passed in, at the head of linked list.
        /// </summary>
        /// <param name="node">The new node to add at the start of the linked list.</param>
        public void AddFirst(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            node.Next = Head;
            Head = node;
        }

        /// <summary>
        /// Adds a new node containing the specified value before the specified node in linked list.
        /// </summary>
        /// <param name="node">The node before which to insert a new node containing the value.</param>
        /// <param name="value">The value to add to the linked list.</param>
        public void InsertBefore(Node<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (node == Head)
            {
                AddFirst(value);
            }
            var newNode = new Node<T>(value);

            InsertBefore(node, newNode);
        }

        /// <summary>
        /// Adds the specified new node before the specified existing node in the linked list.
        /// </summary>
        /// <param name="node">The node before which to insert newNode.</param>
        /// <param name="newNode">The new node to add to the linked list.</param>
        public void InsertBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (newNode == null) throw new ArgumentNullException(nameof(newNode));

            if (node == Head)
            {
                AddFirst(newNode);
                return;
            }

            var current = Head;

            while (current.Next != node)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Next = node;
        }

        /// <summary>
        /// Creates a new node of specified value and passes to helper.
        /// </summary>
        /// <param name="value">The value to add to the linked list.</param>
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            AddLast(newNode);
        }

        /// <summary>
        /// Adds the specified new node at the end of the linked list.
        /// If the list is empty, add new node as head.
        /// Else, iterate to end of list and add node last.
        /// </summary>
        /// <param name="node">The new node to add at the end of the linked list.</param>
        public void AddLast(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            // List is empty.
            if (IsEmpty())
            {
                AddFirst(node);
            }
            else
            {
                Node<T> current = Head;
                // Iterate to end of list.
                while (current.Next != null)
                {
                    current = current.Next;
                }
                // When current is last node, link last node to new node.
                current.Next = node;
            }
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the linked list.
        /// </summary>
        /// <param name="value">The value to remove from the linked list.</param>
        /// <returns>true if the value is successfully removed; otherwise false. It also returns false if the value was not found in the linked list.</returns>
        public bool Remove(T value)
        {
            if (IsEmpty()) return false;

            if (Equals(Head.Value, value))
            {
                RemoveFirst();
                return true;
            }

            var current = Head.Next;
            var lastNode = Head;

            while (current.Next != null)
            {
                if (Equals(current.Value, value))
                {
                    lastNode.Next = current.Next;
                    return true;
                }
                lastNode = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Removes the node at the start of the linked list.
        /// </summary>
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The SinglyLinkedList doesn't contain any elements.");
            }
            Head = Head.Next;
        }

        /// <summary>
        /// Removes the node at the end of the linked list.
        /// </summary>
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The SinglyLinkedList doesn't contain any elements.");
            }

            if (Head.Next == null)
            {
                Head = null;
                return;
            }

            var current = Head.Next;
            var lastNode = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }
            current = null;
            lastNode.Next = current;
        }

        /// <summary>
        /// Determines whether value is contained in linked list.
        /// </summary>
        /// <param name="value">The value to search in the linked list.</param>
        /// <returns>returns true if the value is found; otherwise false.</returns>
        public bool Contains(T value)
        {
            if (IsEmpty())
            {
                return false;
            }

            var current = Head;

            while (current != null)
            {
                if (Equals(current.Value, value)) return true;

                current = current.Next;
            }

            return false;
        }
        /// <summary>
        /// Count this instance.
        /// </summary>
        /// <returns>The count of node in linked list.</returns>
        public int Count()
        {
            int count = 0;
            var current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        /// <summary>
        /// Print this instance with pointers: ->.
        /// </summary>
        public void Print()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The linked list is empty.");
            }
            var current = Head;
            while (current != null)
            {
                Console.Write($"{current.Value} -> ");
                current = current.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }

        /// <summary>
        /// Set head to null, list will garbage collected.
        /// </summary>
        public void Clear()
        {
            Head = null;
        }

        /// <summary>
        /// Determines if list is Empty.
        /// </summary>
        /// <returns>Bool if list empty.</returns>
        public bool IsEmpty() => Head == null;
    }
}
