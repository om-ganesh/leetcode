using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Leetcode World");

            // new TwoSum().Execute();
            // new AddSinglyLinkedLists().Execute();
            // new LongestSubstring().Execute();
            //new MedianOfTwoArray().Execute();

            new MoveZerosToEnd().Execute();
            Console.ReadLine();
        }
    }
}
