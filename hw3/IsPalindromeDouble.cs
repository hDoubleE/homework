using System;

namespace DataStructures
{
    public class Program
    {
        public static void Main()
        {
            // Create a new doubly linked list of type int.
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            Console.WriteLine("Populate new doubly linked list that is NOT a palindrome...");
            dll.AddFirst(3);
            dll.AddLast(5);
            dll.AddLast(7);
            dll.AddLast(9);
            Console.WriteLine("Print:");
            dll.Print();
            Console.WriteLine("Print Reverse:");
            dll.PrintReverse();

            // The IsPalindrome contains 3 methods:
            // IsPalindrome: O(2n)
            // ReverseAndCopy: O(n), with O(n) space.
            // IsEqual: O(n)
            // Runtime for IsPalindrome method execution: O(2n) -> O(n)
            // with O(n) extra memory.
            // Still trying to work in generics, only accepts type int right now.

            Console.WriteLine($"Is linked list a palindrome: {dll.IsPalindrome(dll.Head)}");
            Console.WriteLine();
            Console.WriteLine("Clear linked list.");
            dll.Clear();
            Console.WriteLine($"Linked list is Empty: {dll.IsEmpty()}");
            Console.WriteLine();
            Console.WriteLine("Populate new doubly linked list that IS a palindrome...");
            dll.AddFirst(3);
            dll.AddLast(5);
            dll.AddLast(7);
            dll.AddLast(5);
            dll.AddLast(3);
            Console.WriteLine("Print:");
            dll.Print();
            Console.WriteLine("Print Reverse:");
            dll.PrintReverse();

            Console.WriteLine($"Is linked list a palindrome: {dll.IsPalindrome(dll.Head)}");
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
            if (Count == 0) throw new InvalidOperationException("The doubly linked list is empty.");

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
            if (Count == 0) throw new InvalidOperationException("The doubly linked list is empty.");

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

        /// <summary>
        /// Checks if linked list is palindrome.
        /// Calls two helper methods.
        /// </summary>
        /// <returns> True, if linked list is palindrome, false otherwise.</returns>
        /// <param name="head">Head node of linked list being evaluated.</param>
        public bool IsPalindrome(Node<T> head)
        {
            Node<T> reversed = ReverseAndCopy(head);
            return IsEqual(head, reversed);
        }

        /// <summary>
        /// Creates a reversed copy of the linked list.
        /// </summary>
        /// <returns>The head node to reversed linked list.</returns>
        /// <param name="node">Node.</param>
        public Node<T> ReverseAndCopy(Node<T> node)
        {
            Node<T> First = null;
            while (node != null)
            {
                Node<T> n = new Node<T>(node.Value);
                n.Next = First;
                First = n;
                node = node.Next;
            }
            return First;
        }

        /// <summary>
        /// Compares original and reversed linked list for equality.
        /// </summary>
        /// <returns> True, if linked list is palindrome, false otherwise.</returns>
        /// <param name="one"> Head node of original list.</param>
        /// <param name="two"> Head node of reversed list.</param>
        public bool IsEqual(Node<T> one, Node<T> two)
        {
            while (one != null && two != null)
            {
                // Must use object.Equals, cannot compare type T and T.
                // (one.Value != or == two.Value) will not compile.
                if (!Equals(one.Value, two.Value))
                {
                    return false;
                }
                one = one.Next;
                two = two.Next;
            }
            // Could also return true here.
            return one == null && two == null; 
        }
    }
}