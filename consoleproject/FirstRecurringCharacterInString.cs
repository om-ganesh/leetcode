using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class FirstRecurringCharacterInString
    {
        List<string> data = new List<string>();
        public FirstRecurringCharacterInString()
        {
            data.Add("leetcode");
            data.Add("loveleetcode");
            data.Add("abcdef");
            data.Add("abcab");
            data.Add("baab");
            data.Add("a");
            data.Add("dbcaba");
        }


        public void Execute()
        {
            data.ForEach(k =>
            {
                Console.WriteLine($"First recurring character in string {k} is {FirstRecurringCharacter(k)}");
            });
        }

        private char FirstRecurringCharacter(string s)
        {
            if(s.Length<2)
            {
                return '\0';
            }
            HashSet<char> visited = new HashSet<char>();
            foreach(char c in s)
            {
                if(visited.Contains(c))
                {
                    return c;
                }
                visited.Add(c);
            }

            return '\0';
        }
    }
}
