using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class ReplaceAllQuestionMarks
    {
        List<string> dataset;

        public ReplaceAllQuestionMarks()
        {
            dataset = new List<string>();
            dataset.AddRange(new string[] { "?zs", "??yw?ipkj?", "ubv?w", "j?qg??b", "???a" });
        }
        public void Execute()
        {
            dataset.ForEach(data =>
            {
                String org = String.Copy(data);
                Console.WriteLine($"The original {org} is modified as {ModifyString(data)}");
            });
        }

        public string ModifyString(string s)
        {
            char lastChar = '\0';
            char nextChar = '\0';
            StringBuilder str = new StringBuilder(s);
            for (int i = 0; i < s.Length; i++)
            {
                // Get both last and next immediate chars
                if (i - 1 >= 0 && str[i - 1] != '?')
                {
                    lastChar = str[i - 1];
                }
                if (i + 1 < str.Length && str[i + 1] != '?')
                {
                    nextChar = s[i + 1];
                }
                if (str[i] == '?')
                {
                    str[i] = GetMeNewChar(lastChar, nextChar);
                }
            }
            return str.ToString();
        }

        private char GetMeNewChar(char ch1, char ch2)
        {
            if (ch1 != 'a' && ch2 != 'a')
            {
                return 'a';
            }
            else if (ch1 != 'b' && ch2 != 'b')
            {
                return 'b';
            }
            else
            {
                return 'c';
            }
        }
    }
}
