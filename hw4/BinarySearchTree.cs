using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.BST
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create student object:
            Student Trevor = new Student("Travis", "Computer Science", "New York");
            Student Jean = new Student("Jean", "Mathematics", "West Virginia");
            Student Paul = new Student("Paul", "Data Science", "Georgia");
            Student David = new Student("David", "Undecided", "Massachusetts");
            Student Anne = new Student("Anne", "Mathematics", "Florida");
            Student Sally = new Student("Sally", "Computer Science", "California");
            Student Fred = new Student("Fred");
            Student Ramone = new Student("Ramone");
            Student Yara = new Student("Yara");
            Student Zalea = new Student("Zalea");

            // Populate BST:
            BinarySearchTree<Student> students = new BinarySearchTree<Student>()
            {
                Jean,
                David,
                Paul,
                Zalea,
                Fred,
                Anne,
                Trevor,
                Ramone,
                Yara
            };

            // Add method runs in average O(log n) to "find" correct insert position.
            // Worst case O(n) for unbalanced tree.
            students.Add(new Student("Sally", "Computer Science", "California"));


            // Height method runs in O(h), where h is the height of Binary Tree.
            int height = students.Height(students.Root);
            Console.WriteLine($"Height of BST: {height}");

            // Count leaves method runs in O(h), where h is the height of Binary Tree.
            int leaves = students.CountLeafNodes(students.Root);
            Console.WriteLine($"Number of leaves in BST: {leaves}");


            bool result = students.Contains(Fred);
            Console.WriteLine($"Result of Find in BST: {result}");

            // Remove method runs in average O(log n) to "find" correct insert position.
            // Worst case O(n) for unbalanced tree.
            students.Remove(Fred);
            Console.WriteLine();

            // All print methods, preorder, inorder, postorder, run in O(n) time, touch each node in tree.
            Console.WriteLine("Pre order:");
            students.PrintPreorder(students.Root);
            Console.WriteLine();

            Console.WriteLine("In order:");
            students.PrintInorder(students.Root);
            Console.WriteLine();

            Console.WriteLine("Post order:");
            students.PrintPostorder(students.Root);
        }
    }

    /// <summary>
    /// Represents a student
    /// </summary>
    public class Student : IComparable
    {
        // Properties of Student class.
        public string Name { get; set; }
        public string Major { get; set; }
        public string State { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="major">Major.</param>
        /// <param name="state">State.</param>
        public Student(string name, string major, string state)
        {
            Name = name;
            Major = major;
            State = state;
        }

        /// <summary>
        /// Initializes a new instance of the Student class with Name only.
        /// </summary>
        /// <param name="name">Name.</param>
        public Student(string name)
        {
            Name = name;
            //Major = null;
            //State = null;
        }
        /// <summary>
        /// Compares Names to order BST. Inherits from IComparable.
        /// </summary>
        /// <returns> -1, 0 or 1 for comparison/ordering operations.</returns>
        /// <param name="obj">Object.</param>
        public int CompareTo(object obj)
        {
            Student compareToObj = (Student)obj;

            // Comparison by name.
            return string.Compare(this.Name, compareToObj.Name, StringComparison.Ordinal);

            // And if you wanted to do the comparison by eg age:
            // return this.age.CompareTo(compareToObj.age);
        }
        /// <summary>
        /// Returns a String that represents the current Student.
        /// Must override ToString or only prints Data Type.
        /// </summary>
        /// <returns>A String(Name) that represents the current Student.</returns>
        public override string ToString()
        {
            return Name;
        }

    }

    /// <summary>
    /// Represents a node in the Binary Search Tree.
    /// </summary>
    public class BinarySearchTreeNode<T>
    {
        /// <summary>
        /// Gets the left child of the Binary Search Tree Node.
        /// </summary>
        public BinarySearchTreeNode<T> Left { get; internal set; }

        /// <summary>
        /// Gets the right child of the Binary Search Tree Node.
        /// </summary>
        public BinarySearchTreeNode<T> Right { get; internal set; }

        /// <summary>
        /// Gets the value contained in the Binary Search Tree Node.
        /// </summary>
        public virtual T Value { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the Binary Search Tree Node class, containing the specified value.
        /// </summary>
        /// <param name="value">The value to contain in the Binary Search Tree Node.</param>
        public BinarySearchTreeNode(T value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Represents a binary search tree.
    /// </summary>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// The comparer of the elements in the Binary Search Tree.
        /// </summary>
        internal IComparer<T> comparer;

        /// <summary>
        /// Gets the tree root of the Binary Search Tree.
        /// </summary>
        public BinarySearchTreeNode<T> Root { get; internal set; }

        /// <summary>
        /// Gets the number of elements in the Binary Search Tree.
        /// </summary>
        public virtual int Count { get; internal set; }

        /// <summary>
        /// Creates a new instance of the Binary Search Tree class and uses the default <see cref="IComparer{T}"/> implementation to compare elements.
        /// </summary>
        public BinarySearchTree() : this(null) { }

        /// <summary>
        ///  Creates a new instance of the Binary Search Tree class and uses the specified <see cref="IComparer{T}"/> implementation to compare elements.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer{T}"/> implementation to use when comparing elements, or null to use the default comparer <see cref="Comparer{T}.Default"/>.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Root = null;
            Count = 0;
        }

        /// <summary>
        /// Adds an element to the Binary Search Tree.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public virtual void Add(T value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(value);
                Count++;
                return;
            }

            BinarySearchTreeNode<T> curNode = Root;
            BinarySearchTreeNode<T> lastNode = Root;
            bool addedToLeftSide = true;

            while (curNode != null)
            {
                int cmp = comparer.Compare(value, curNode.Value);

                if (cmp < 0)
                {
                    lastNode = curNode;
                    curNode = curNode.Left;
                    addedToLeftSide = true;
                }
                else if (cmp > 0)
                {
                    lastNode = curNode;
                    curNode = curNode.Right;
                    addedToLeftSide = false;
                }
                else throw new ArgumentException("Tried to insert duplicate value!");
            }

            if (addedToLeftSide)
            {
                lastNode.Left = new BinarySearchTreeNode<T>(value);
                Count++;
            }

            else
            {
                lastNode.Right = new BinarySearchTreeNode<T>(value);
                Count++;
            }
        }

        /// <summary>
        /// Removes an element from the Binary Search Tree.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        /// <returns>true if the item is successfully removed; otherwise false. Also returns false if item is not found.</returns>
        public virtual bool Remove(T value)
        {
            if (Root == null) return false;

            BinarySearchTreeNode<T> curNode = Root;
            BinarySearchTreeNode<T> lastNode = Root;
            bool lastWasLeftSide = true;

            while (curNode != null)
            {
                int cmp = comparer.Compare(value, curNode.Value);

                if (cmp < 0)
                {
                    lastNode = curNode;
                    curNode = curNode.Left;
                    lastWasLeftSide = true;
                }
                else if (cmp > 0)
                {
                    lastNode = curNode;
                    curNode = curNode.Right;
                    lastWasLeftSide = false;
                }
                else
                {
                    if (curNode.Right == null)
                    {
                        if (lastWasLeftSide)
                        {
                            if (curNode == Root) Root = curNode.Left;
                            else lastNode.Left = curNode.Left;
                        }
                        else
                        {
                            lastNode.Right = curNode.Left;
                        }
                    }
                    else
                    {
                        BinarySearchTreeNode<T> min = null;
                        BinarySearchTreeNode<T> rightNode = FindAndRemoveMin(curNode.Right, ref min);
                        min.Right = rightNode;
                        min.Left = curNode.Left;

                        if (lastWasLeftSide)
                        {
                            if (curNode == Root) Root = min;
                            else lastNode.Left = min;
                        }
                        else
                        {
                            lastNode.Right = min;
                        }
                    }

                    curNode.Left = null;
                    curNode.Right = null;

                    Count--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Finds the min node in the subtree and returns the root of the new subtree.
        /// Helper function to Remove method.
        /// </summary>
        private BinarySearchTreeNode<T> FindAndRemoveMin(BinarySearchTreeNode<T> subtreeRoot, ref BinarySearchTreeNode<T> min)
        {
            if (subtreeRoot.Left == null)
            {
                if (subtreeRoot.Right == null)
                {
                    min = subtreeRoot;
                    return null;
                }
                else
                {
                    min = subtreeRoot;
                    return subtreeRoot.Right;
                }
            }

            BinarySearchTreeNode<T> curNode = subtreeRoot;
            BinarySearchTreeNode<T> lastNode = subtreeRoot;

            while (curNode.Left != null)
            {
                lastNode = curNode;
                curNode = curNode.Left;
            }

            lastNode.Left = curNode.Right;
            min = curNode;

            return subtreeRoot;
        }

        /// <summary>
        /// Determines whether a value is in the Binary Search Tree.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>true if item is found; otherwise false.</returns>
        public virtual bool Contains(T value)
        {
            if (Root == null) return false;
            BinarySearchTreeNode<T> curNode = Root;
            while (curNode != null)
            {
                int cmp = comparer.Compare(value, curNode.Value);
                if (cmp == 0) return true;
                if (cmp < 0) curNode = curNode.Left;
                if (cmp > 0) curNode = curNode.Right;
            }
            return false;
        }

        /// <summary>
        /// Recursively counts leaf nodes.
        /// </summary>
        /// <returns>The leaf nodes.</returns>
        /// <param name="root">Root.</param>
        public int CountLeafNodes(BinarySearchTreeNode<T> root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return 1;
            return CountLeafNodes(root.Left) + CountLeafNodes(root.Right);
        }

        /// <summary>
        /// Height (in nodes) the specified tree.
        /// </summary>
        /// <returns>The height.</returns>
        /// <param name="root">Root.</param>
        public int Height(BinarySearchTreeNode<T> root)
        {
            if (root == null) return 0;

            int leftHeight = Height(root.Left);
            int rightHeight = Height(root.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// Prints the preorder.
        /// </summary>
        /// <param name="root">Root.</param>
        public void PrintPreorder(BinarySearchTreeNode<T> root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Value);
                PrintPreorder(root.Left);
                PrintPreorder(root.Right);
            }
        }

        /// <summary>
        /// Prints the inorder.
        /// </summary>
        /// <param name="root">Root.</param>
        public virtual void PrintInorder(BinarySearchTreeNode<T> root)
        {
            if (root != null)
            {
                PrintInorder(root.Left);
                Console.WriteLine(root.Value);
                PrintInorder(root.Right);
            }
        }

        /// <summary>
        /// Prints the postorder.
        /// </summary>
        /// <param name="root">Root.</param>
        public virtual void PrintPostorder(BinarySearchTreeNode<T> root)
        {
            if (root != null)
            {
                PrintPostorder(root.Left);
                PrintPostorder(root.Right);
                Console.WriteLine(root.Value);
            }
        }

        /// <summary>
        /// Removes all elements from the Binary Search Tree.
        /// </summary>
        public virtual void Clear()
        {
            if (Root != null)
            {
                HashSet<BinarySearchTreeNode<T>> cleared = new HashSet<BinarySearchTreeNode<T>>();
                Stack<BinarySearchTreeNode<T>> stack = new Stack<BinarySearchTreeNode<T>>();
                stack.Push(Root);
                while (stack.Count > 0)
                {
                    BinarySearchTreeNode<T> curNode = stack.Peek();

                    if (curNode.Left == null || cleared.Contains(curNode.Left))
                    {
                        cleared.Add(curNode);
                        stack.Pop();

                        if (curNode.Right != null) stack.Push(curNode.Right);

                        curNode.Left = null;
                        curNode.Right = null;

                    }
                    else stack.Push(curNode.Left);
                }
            }

            Root = null;
            Count = 0;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Binary Search Tree.
        /// </summary>
        /// <returns>Returns the elements in ascending order.</returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            if (Root != null)
            {
                HashSet<BinarySearchTreeNode<T>> returned = new HashSet<BinarySearchTreeNode<T>>();
                Stack<BinarySearchTreeNode<T>> stack = new Stack<BinarySearchTreeNode<T>>();
                stack.Push(Root);
                while (stack.Count > 0)
                {
                    BinarySearchTreeNode<T> curNode = stack.Peek();

                    if (curNode.Left == null || returned.Contains(curNode.Left))
                    {
                        returned.Add(curNode);
                        stack.Pop();
                        yield return curNode.Value;

                        if (curNode.Right != null) stack.Push(curNode.Right);
                    }
                    else stack.Push(curNode.Left);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
