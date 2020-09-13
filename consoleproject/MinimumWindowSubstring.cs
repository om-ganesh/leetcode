using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class MinimumWindowSubstring
    {
        List<Tuple<string, string>> data = new List<Tuple<string, string>>();

        public MinimumWindowSubstring()
        {
            data.Add(new Tuple<string, string>("ADOBECODEBANC", "ABC"));
            data.Add(new Tuple<string, string>("ADOBECODEBANCX", "ABC"));
            data.Add(new Tuple<string, string>("ADOBECODEBANCXABC", "ABC"));
            data.Add(new Tuple<string, string>("AADOBECODEBANCXCB", "ABC"));
            data.Add(new Tuple<string, string>("AADOBBECCODEBANCXCB", "ABC"));
            data.Add(new Tuple<string, string>("ADOBECODEBAANC", "ABC"));
            data.Add(new Tuple<string, string>("ADOBECODEBAANC", "DOC"));
            data.Add(new Tuple<string, string>("A", "AA"));
            data.Add(new Tuple<string, string>("AA", "AA"));
            data.Add(new Tuple<string, string>("AADOBBECCODEBANCXCB", "AABC"));


        }

        public void Execute()
        {
            data.ForEach(t => {

                Console.WriteLine($"Given string: {t.Item1}, Required sub-string: {t.Item2}");
                var result = MinWindow(t.Item1, t.Item2);
                Console.WriteLine($"Result: {result}");

            });
        }

        private string MinWindow(string source, string target)
        {

            //this is hashset of target string [A, B, C]
            Dictionary<char, int> targetSet = new Dictionary<char, int>();
            Dictionary<char, int> counterSet = new Dictionary<char, int>();
            for (int i = 0; i < target.Length; i++)
            {
                char myChar = target[i];
                if (!counterSet.ContainsKey(myChar))
                {
                    counterSet.Add(myChar, 1 );
                    targetSet.Add(myChar, 1);
                }
                else
                {
                    int val = counterSet[myChar];
                    counterSet[myChar] = val+1;
                    targetSet[myChar] = val+1;
                }
            }

            //this is mapping of target chars and their count in current window [A=1, B=1, C=2 => my window has 1A,1B,2C]
            Dictionary<char, int> windowDict = new Dictionary<char, int>();
            int left = 0;
            int right = 0;

            //Move right side until we get our first valid window
            for (right = 0; right < source.Length && counterSet.Count > 0; right++)
            {
                char myChar = source[right];
                if (targetSet.ContainsKey(myChar))
                {
                    //Remove or decrease counter from currentSet
                    if (counterSet.ContainsKey(myChar))
                    {
                        int val = counterSet[myChar];
                        if (val == 1)
                        {
                            counterSet.Remove(myChar);
                        }
                        else
                        {
                            counterSet[myChar] = val - 1;
                        }
                    }
                    

                    //Maintain windowDictionary with counters so far
                    if (windowDict.ContainsKey(myChar))
                    {
                        int val1 = windowDict[myChar];
                        windowDict[myChar] = val1 + 1;
                    }
                    else
                    {
                        windowDict.Add(myChar, 1);
                    }
                }
            }

            //If the target string is not even part of given then the counter won't get to zero
            if(counterSet.Count >0)
            {
                return "";
            }
            //Here, we got valid left and right side of window satisfying our target string
            bool valid = true;
            int resultstart = left;
            int resultend = --right;    //we decrease right as when we come out of avove loop it is increamented at last
            char removedChar = ' ';

            //TODO find terminating condition
            while (true)
            {
                //Move left side of window until we are still getting valid, else move right
                if (valid)
                {
                    //For every valid window, record the min window indexes
                    if ((right - left) < (resultend - resultstart))
                    {
                        resultstart = left;
                        resultend = right;
                    }

                    //Determine if removing current character(if that exists in window/part of target string), will make window invalid
                    char myChar = source[left];
                    if (windowDict.ContainsKey(myChar))
                    {
                        var val = windowDict[myChar];
                        windowDict[myChar] = val - 1;

                        if (windowDict[myChar] < targetSet[myChar])
                        {
                            valid = false;
                            removedChar = myChar;
                        }
                    }
                    left++;
                }
                else
                {
                    //We come here whenever our window is invalid, and we will make it valid when we get that deleted character again in window
                    right++;

                    //Added to terminate the while loop (end of string reached)
                    if (right == source.Length)
                    {
                        break;
                    }
                    char myChar = source[right];
                    if (windowDict.ContainsKey(myChar))
                    {
                        var val = windowDict[myChar];
                        windowDict[myChar] = val + 1;
                        if (myChar == removedChar)
                        {
                            valid = true;
                        }
                    }
                }
            }

            return source.Substring(resultstart, resultend - resultstart + 1);
        }

        private string MinWindowConsideringDuplicte(string source, string target)
        {
            
            //this is hashset of target string [A, B, C]
            HashSet<char> targetSet = new HashSet<char>();
            HashSet<char> counterSet = new HashSet<char>();
            for (int i = 0; i < target.Length; i++)
            {
                if(!counterSet.Contains(target[i]))
                {
                    counterSet.Add(target[i]);
                    targetSet.Add(target[i]);
                }
            }

            //this is mapping of target chars and their count in current window [A=1, B=1, C=2 => my window has 1A,1B,2C]
            Dictionary<char, int> windowDict = new Dictionary<char, int>();
            int left = 0;
            int right = 0;

            //Move right side until we get our first valid window
            for (right = 0; right < source.Length && counterSet.Count > 0;right++)
            {
                char myChar = source[right];
                if (targetSet.Contains(myChar))
                {
                    //Remove from currentSet and increase counter in windowDictionary
                    counterSet.Remove(myChar);
                    if (windowDict.ContainsKey(myChar))
                    {
                        int val = windowDict[myChar];
                        windowDict[myChar] = val + 1;
                    }
                    else
                    {
                        windowDict.Add(myChar, 1);
                    }
                }
            }

            //Here, we got valid left and right side of window satisfying our target string
            bool valid = true;
            int resultstart = left;
            int resultend = --right;    //we decrease right as when we come out of avove loop it is increamented at last
            char removedChar=' ';
            
            //TODO find terminating condition
            while (true)
            {
                //Move left side of window until we are still getting valid, else move right
                if (valid)
                {
                    //For every valid window, record the min window indexes
                    if( (right - left) < (resultend-resultstart))
                    {
                        resultstart = left;
                        resultend = right;
                    }

                    //Determine if removing current character(if that exists in window/part of target string), will make window invalid
                    char myChar = source[left];
                    if (windowDict.ContainsKey(myChar))
                    {
                        var val = windowDict[myChar];
                        windowDict[myChar] = val - 1;

                        if (windowDict[myChar] == 0)
                        {
                            valid = false;
                            removedChar = myChar;
                        }
                    }
                    left++;
                }
                else
                {
                    //We come here whenever our window is invalid, and we will make it valid when we get that deleted character again in window
                    right++;

                    //Added to terminate the while loop (end of string reached)
                    if(right == source.Length)
                    {
                        break;
                    }
                    char myChar = source[right];
                    if (windowDict.ContainsKey(myChar))
                    {
                        var val = windowDict[myChar];
                        windowDict[myChar] = val + 1;
                        if (myChar == removedChar)
                        {
                            valid = true;
                        }
                    }
                }
            }

            return source.Substring(resultstart,resultend-resultstart+1);
        }
    }
}

