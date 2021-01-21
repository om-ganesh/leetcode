using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /// <summary>
    /// A shift on A consists of taking string A and moving the leftmost character to the rightmost position. 
    /// For example, if A = 'abcde', then it will be 'bcdea' after one shift on A. 
    /// Return True if and only if A can become B after some number of shifts on A.
    /// https://leetcode.com/problems/rotate-string/
    /// </summary>
    class RotateStringToMatchOther
    {
        List<Tuple<string, string>> data = new List<Tuple<string, string>>();

        public RotateStringToMatchOther()
        {
            data.Add(new Tuple<string, string>("ABC", "CAB"));
            data.Add(new Tuple<string, string>("ABCA", "ABC"));
            data.Add(new Tuple<string, string>("abcde", "cdeab"));
            data.Add(new Tuple<string, string>("abcde", "abced"));
        }

        public void Execute()
        {
            data.ForEach(t => {
                Console.WriteLine($"StringA: {t.Item1}, StringB: {t.Item2} can be same: {RotateString(t.Item1, t.Item2)}");
            });
        }

        private bool RotateString(string A, string B)
        {
            if(A.Length!=B.Length)
            {
                return false;
            }
            return (A + A).Contains(B);
        }
    }
}
