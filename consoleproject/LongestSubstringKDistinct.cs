using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class LongestSubstringKDistinct
    {

        public void Execute()
        {
            List<(string, int)> data = new List<(string, int)>();
            data.Add(("a", 0));//0
            data.Add(("a", 2));//1
            data.Add(("abaccc", 2));//4
            data.Add(("abee", 1));//2
            data.Add(("eceba", 2));//3
            data.Add(("aa", 1));//2
            data.Add(("loveleetcode", 4));//7
            data.ForEach(d =>
            {
                Console.WriteLine(LengthOfLongestSubstringKDistinct(d.Item1, d.Item2));
            });

            Console.ReadLine();
        }

        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {

            if (s.Length == 0 || k == 0)
            {
                return 0;
            }
            int maxLength = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int head = 0;
            int tail = 0;

            //This loop moves the header/right window forward
            while (head < s.Length)
            {
                //if item exists, replace the item, else just add it
                if (dict.ContainsKey(s[head]))
                {
                    dict[s[head]] = head;
                }
                else
                {
                    dict.Add(s[head], head);
                }
                head++;

                // Delete the item from dictionary to keep only 'k' unique chars
                // This loop moves the tail/left window forward
                if (dict.Count > k)
                {
                    var item = dict.Min(x => x.Value);
                    dict.Remove(s[item]);
                    tail = item + 1;
                }
                // Update the max length
                if (head - tail > maxLength)
                {
                    maxLength = head - tail;
                }
            }
            return maxLength;
        }

        public int LengthOfLongestSubstringKDistinct1(string s, int k)
        {
            int result = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int head = 0, tail = 0; head < s.Length && tail < s.Length;)
            {
                // forward head until your counter of dictionary reaches your limit of K
                while (dict.Count < k || dict.ContainsKey(s[head]))
                {
                    //if item exists, replace the item, else just add it
                    if (dict.ContainsKey(s[head]))
                    {
                        dict[s[head]] = head;
                    }
                    else
                    {
                        dict.Add(s[head], head);
                    }
                    head++;
                    if (head == s.Length)
                    {
                        break;
                    }
                }

                if (head - tail > result)
                {
                    result = head - tail;
                }

                // delete item pointed by tail, if its the last item and then forward the tail
                if (dict.TryGetValue(s[tail], out int val))
                {
                    if (val == tail)
                    {
                        dict.Remove(s[tail]);
                    }
                }
                tail++;
            }
            return result;
        }
    }
}
