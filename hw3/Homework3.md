# Homework 3

## Part 1

Write separate C# programs for each problem below

Problem 1 [30 points]: What we saw in class was a singly linked list, because there was a link from one node to the next node. Modify the code in class (make sure to use it!!!) so it works with strings instead of integers.

Problem 2 [30 points]: What we saw in class was a singly linked list, because there was a link from one node to the next node. Modify the code in class (make sure to use it!!!) so it works with integers (as we saw in class) but so it uses two links for each node, one for the next and one for the previous node. This is called doubly linked list. In addition to the methods in class also add a method void printReverse() that prints in reverse the list (it displays the last element, then the one next to last, …, and lastly it will display the first element)

Problem 3 [20 points] To the code written for Problem 1 add a new method void RemoveDuplicates() that will remove all duplicates from the linked list. Do not use an extra array, use only O(1) extra memory for this operation. What is the running time?

Problem 4 [10 points] To the code written for Problem 1 add a new method bool IsPalindrome() that will check whether the singly linked list is a palindrome. If you don’t remember what palindrome is google the term or stop by my office. What is the running time?  E.g. “church” -> “monk” -> “monk” -> “church” is a palindrome.

Problem 5 [10 points] To the code written for Problem 2 add a new method bool IsPalindrome() that will check whether the doubly linked list is a palindrome. If you don’t remember what palindrome is google the term or stop by my office. What is the running time?  E.g. 21 <->  34  <-> 6  <-> 34 <->21 is a palindrome.

## Part 2

Write separate C# programs for each problem below

Problem 1 [25 points] Let Q be a non-empty queue, and let S be an empty stack.
Write a C# program that reverses the order of the elements in Q, using S.
For example, if initially the order of the objects in Q is 1,2,3,4,5,6, then after reversing the objects, the order of the objects in Q is 6,5,4,3,2,1.

Problem 2 [25 points] Write a program that opens a text file (“input.txt”) and reads its contents. 
Then using a stack it reverses the lines of the file and saves them into another file (“output.txt”). 
Hint: use System.IO.File.WriteAllLines and System.IO.File.ReadAllLines,

Problem 3 [50 points] Implement a Queue class using two stacks (use the side images as hints - see the class notes). What is the running time for enqueue() and dequeue()?
