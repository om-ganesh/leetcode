using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class LongestSubstring
    {
        List<string> data = new List<string>();
        public LongestSubstring()
        {
            data.Add("abcabcbb");
            data.Add("ababc");
            data.Add("bbbbb");
            data.Add("pwwkew");
            data.Add("abcdbebfagcf");
            data.Add("");
            data.Add("au");
            data.Add(" ");
        }

        public void Execute()
        {
            data.ForEach(d =>
            {
                var result = LengthOfLongestSubstring(d);
                Console.WriteLine($"The longest length of substring in [{d}] is {result}");
            });
        }

        private int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            Dictionary<char, int> substring = new Dictionary<char, int>();

            for (int i = 0, j=0; j < s.Length; )
            {
                if (substring.ContainsKey(s[j]))
                {
                    substring.Remove(s[i]);
                    i=i+1;
                }
                else
                {
                    substring.Add(s[j], j);
                    maxLength = (j - i+1) > maxLength ? (j - i+1) : maxLength;
                    j++;
                }
            }
            return maxLength;
        }

        private int LengthOfLongestSubstringLegacy(string s)
        {
            int maxLength = 0;
            for(int i=0; i < s.Length; i++)
            {
                HashSet<char> visited = new HashSet<char>();
                int length = 0;
                for(int j =i; j < s.Length; j++)
                {
                    if (!visited.Contains(s[j]))
                    {
                        length++;
                        maxLength = maxLength < length ? length : maxLength;
                        if(maxLength == s.Length)
                        {
                            return maxLength;
                        }
                        visited.Add(s[j]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return maxLength;
        }
    }
}
