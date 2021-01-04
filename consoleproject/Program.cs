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

            new AAATestClass().Execute();

            //new TwoSum().Execute();
            //new AddSinglyLinkedLists().Execute();
            //new MedianOfTwoArray().Execute();

            //new LongestSubstring().Execute();
            //new MedianOfTwoArray().Execute();

            //new MoveZerosToEnd().Execute();
            //new MinimumWindowSubstring().Execute();

            //new MinManhattanDistance().Execute();

            //new LongestConsecutiveSequence().Execute();

            //new RotateStringInplaceByOffset().Execute();
            //new RotateStringToMatchOther().Execute();
            //new PalindromeString().Execute();

            //new FirstRecurringCharacterInString().Execute();
            //new FirstUniqueCharacter().Execute();

            //new ArrayFormationThroughConcatenation().Execute();
            new RotateArray().Execute();

            Console.ReadLine();
        }
    }
}
