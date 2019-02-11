using System;

namespace Sorting
{
    public class Program
    {
        public static void Main()
        {
            SinglyLinkedList list = new SinglyLinkedList();

            list.AddFront(17);
        }
    }
    public class Node
    {
        private int value;
        private Node next;

        public int Value { get; set; }
        public Node Next { get; set; }

        // constructor
        public Node(int val)
        {
            Value = val;
            Next = null;
        }
    }
    public class SinglyLinkedList
    {
        private Node head;
        public Node Head { get; set; }
        public SinglyLinkedList()
        {
            head = null;
        }

        public void AddFront(Node val)
        {
            Node newNode = new Node(val);
            
            newNode.next = head;

            head = newNode; 
        }
    }
}

