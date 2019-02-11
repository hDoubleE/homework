using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC395_SinglyLinkedLists
{
    class Program
    {
        static void Main(string[] args) //O(n) because ...
        {
            Queue que = new Queue();
            que.enqueue(7);
            que.enqueue(9);
            que.enqueue(12);
            que.enqueue(18);
            que.print();
            que.peek();
            que.dequeue();
            que.print();


        }
    }

    class Node
    {
        // Fields.
        public int value;
        public Node next;
        
        // Constructor with value and next pointer init to null.
        public Node(int val)
        {
            value = val;
            next = null;
        }
    }

    class SinglyLinkedList
    {
        // Head field.
        public Node head;

        
        public bool isEmpty() //O(1)
        {
            //if (head == null)
            //    return true;
            //else
            //    return false;

            return head == null;
        }

        public void printList()//O(n)
        {
            if (isEmpty())
                Console.WriteLine("the list is emtpy!");
            else
            {
                Console.WriteLine("the list contains:");
                Node curr = head;
                while (curr != null)
                {
                    Console.Write(curr.value+ " ");//display value
                    curr = curr.next; //moves curr to the next in the list
                }
                Console.WriteLine();
            }
        }

        public int count() // O(n)
        {
            int c = 0;
            Node curr = head;

            while(curr!=null)
            {
                c++;
                curr = curr.next;
            }

            return c;
        }
        
        public void addFront(int val) //O(1)
        {
            addFront(new Node(val));
        }

        public void addFront(Node node)
        {
            //then link in the new node
            node.next = head;
            head = node;
        }

        public void deleteFront() //O(1)
        {
            if (isEmpty())
                Console.WriteLine("FATAL ERROR: you can't delete from an emtpy list!");
            else
                head = head.next;
        }

        public void addBack(int val)
        {
            if(isEmpty())
            {
                addFront(val);
            }
            else
            {
                Node curr = head;

                while (curr.next != null)
                    curr = curr.next;
                //here curr points to the last node in the list
                //create new node
                Node node = new Node(val);
                //link last node in the list to the node
                curr.next = node;
            }
        }

        public void deleteBack()
        {
            if(isEmpty()) // check if the list is empty
            {
                Console.WriteLine("FATAL ERROR: you can't delete last from an empty list!");
            }
            else if(head.next==null) // check if the list has exactly one element
            {
                head = null;
            }
            else
            {
                Node curr = head;
                while (curr.next.next != null)
                    curr = curr.next;//move forward
                curr.next = null;//unlink the last node
            }
        }

        public void insert(int val)//inserts a new value while maintaining the order - ASSUMES LINKED LIST VALUES ARE SORTED
        {
            if (isEmpty())
                addFront(val);
            else if(val <= head.value)
                addFront(val);
            else
            {
                //start at the head
                Node curr = head;

                while (curr.next != null &&  curr.next.value <= val) //search for the node that will point right before the newly added node
                    curr = curr.next;
                //create new node
                Node node = new Node(val);

                //the do the link
                node.next = curr.next;
                curr.next = node;
            }

        }
        public void delete(int oldValue)//deletes a value
        {
            if(isEmpty())
            {
                Console.WriteLine("FATAL ERROR: you can't delete from an empty list!");
            }
            else if (oldValue == head.value)//we need to delete the head
            {
                deleteFront();
            }
            else
            {
                //need to search for node containing the oldValue
                Node curr = head;
                while (curr.next!=null && curr.next.value != oldValue)
                    curr = curr.next;
                //if curr.next == null that means oldValue is not in the list
                if(curr.next!=null)//curr.next is the node to delete
                {
                    curr.next = curr.next.next;
                }
            }
        }
        //constructor - initialize data in here ...
        public SinglyLinkedList()
        {
            head = null;
        }
    }

    public class Stack
    {
        //data
        SinglyLinkedList stackData;

        //method
        public void push(int newVal)
        {
            stackData.addFront(newVal);
        }
        public void pop()
        {
            stackData.deleteFront();
        }

        public int peek()
        {
            return stackData.head.value;
        }
        public bool isEmpty()
        {
            return stackData.isEmpty();
        }

        public void print()
        {
            stackData.printList();
        }
        //constructor
        public Stack()
        {
            // This allocates memory.
            stackData = new SinglyLinkedList();
        }
    }

    public class Queue
    {
        //data
        SinglyLinkedList queueData;

        //methods + constructor(s)
        public void enqueue(int newVal)
        {
            queueData.addBack(newVal);
        }

        public void dequeue()
        {
            queueData.deleteFront();
        }

        public int peek()
        {
            return queueData.head.value;
        }

        public void print()
        {
            queueData.printList();
        }

        public bool isEmpty()
        {
            return queueData.isEmpty();
        }

        public Queue()
        {
            queueData = new SinglyLinkedList();//this actually allocates memory
        }
    }
}
