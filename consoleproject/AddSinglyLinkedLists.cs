using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers. 
    /// The digits are stored in reverse order, and each of their nodes contains a single digit. 
    /// Add the two numbers and return the sum as a linked list.
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    class AddSinglyLinkedLists
    {
        List<Tuple<int[], int[]>> data = new List<Tuple<int[], int[]>>();
        public AddSinglyLinkedLists()
        {
            //data.Add(new Tuple<int[], int[]>(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }));
            data.Add(new Tuple<int[], int[]>(new int[] { 0 }, new int[] { 0 }));
            //data.Add(new Tuple<int[], int[]>(new int[] { 9 }, new int[] { 1, 9, 9 }));
            //data.Add(new Tuple<int[], int[]>(new int[] { 9 }, new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9 }));
        }
        public void Execute()
        {
            data.ForEach(t => {

                Console.WriteLine($"Input1: {string.Join(",",t.Item1)}, Input2: {string.Join(",",t.Item2)}");
                ListNode l1 = CreateLinkedList(t.Item1);
                ListNode l2 = CreateLinkedList(t.Item2);
                var result = AddTwoNumbers(l1, l2);
                DisplayLinkedList(result);
            });
            
        }

        private ListNode CreateLinkedList(int[] data)
        {
            ListNode first = new ListNode(data[0], null);
            ListNode current = first;

            for(int i = 1; i < data.Length; i++)
            {
                ListNode temp = new ListNode(data[i]);
                current.next = temp;
                current = current.next;
            }
            return first;
        }

        private void DisplayLinkedList(ListNode node)
        {
            string output = "[";
            while(node != null)
            {
                output += node.val;
                
                node = node.next;
                if(node != null)
                {
                    output += ", ";
                }
            }
            output += "]";
            Console.WriteLine(output);
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode current = result;

            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int sum = carry;

                if (l1 != null)
                {
                    sum = sum + l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum = sum + l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;

                ListNode node = new ListNode(sum%10);

                if (result == null)
                {
                    result = node;
                    current = result;
                }
                else
                {
                    current.next = node;
                    current = current.next;
                }
            }

            if(carry == 1)
            {
                current.next = new ListNode(1);
            }

            return result;
        }

    //private ListNode AddTwoNumbersLegacy(ListNode l1, ListNode l2)
    //    {
    //        int index = 0;
    //        uint sum1 = 0;
    //        uint sum2 = 0;

    //        // Create number1
    //        while(l1 != null)
    //        {
    //            sum1 += (uint)( l1.val * Convert.ToInt64(Math.Pow(10, index++)));
    //            l1 = l1.next;
    //        }

    //        // Create number2
    //        index = 0;
    //        while (l2 != null)
    //        {
    //            sum2 += (uint)(l2.val * Convert.ToInt64(Math.Pow(10, index++)));
    //            l2 = l2.next;
    //        }

    //        //Create output list
    //        // Add numbers
    //        uint sum = sum1 + sum2;
    //        if(sum == 0 )
    //        {
    //            return new ListNode(0);
    //        }
    //        ListNode result = null;
    //        ListNode current = result;


    //        uint number = sum;
    //        while (number > 0)
    //        {
    //            int val = (int) (number % 10);
    //            number = number / 10;
    //            ListNode node = new ListNode(val, null);

    //            if(result == null)
    //            {
    //                result = node;
    //                current = result;
    //            } 
    //            else
    //            {
    //                current.next = node;
    //                current = current.next;
    //            }
    //        }

    //        Console.WriteLine($"Sum= {sum1+sum2}");
    //        return result;
    //    }
    }
 
    // Definition for singly-linked list.
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
