using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class FirstUniqueCharacter
    {
        List<string> data = new List<string>();
        public FirstUniqueCharacter()
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
                Console.WriteLine($"First occurence of Unique character in string {k} is at Index: {FirstUniqChar(k)}");
            });
        }

        private int FirstUniqChar(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach(char ch in s)
            {
                if(dict.ContainsKey(ch))
                {
                    dict.TryGetValue(ch, out int val);
                    dict[ch] = val + 1;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }

            foreach(KeyValuePair<char,int> item in dict)
            {
                if(item.Value ==1)
                {
                    return s.IndexOf(item.Key);
                }
            }

            return -1;
        }

    }
}
