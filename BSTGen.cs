using System;
using System.Collections.Generic;




namespace DataStructures
{
    public class Program
    {
        static void Main()
        {

        }
    }
    public class BinarySearchTree<T>
    {

        /// <summary>
        /// The comparer of the elements in the Binary Search Tree>.
        /// </summary>
        internal IComparer<T> comparer;


        public Node<T> Root { get; internal set; }

        /// <summary>
        /// Creates a new instance of the <see cref="BinarySearchTree{T}"/> class and uses the default <see cref="IComparer{T}"/> implementation to compare elements.
        /// </summary>
        public BinarySearchTree() : this(null) { }

        /// <summary>
        ///  Creates a new instance of the <see cref="BinarySearchTree{T}"/> class and uses the specified <see cref="IComparer{T}"/> implementation to compare elements.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer{T}"/> implementation to use when comparing elements, or null to use the default comparer <see cref="Comparer{T}.Default"/>.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Root = null;
        }

        /// <summary>
        /// Adds an element to the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public virtual void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }

            var curNode = Root;
            var lastNode = Root;
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
                lastNode.Left = new Node<T>(value);
            }
            else
            {
                lastNode.Right = new Node<T>(value);
            }
        }


        public class Node<T>
        {
            public T Value { get; internal set; }

            public Node<T> Left { get; internal set; }

            public Node<T> Right { get; internal set; }

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
    }
}
