using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class LongestConsecutiveSequence
    {
        List<int[]> data = new List<int[]>();
        public LongestConsecutiveSequence()
        {
            data.Add(new int[] { 100, 4, 200, 1, 3, 2 });
            data.Add(new int[] { 0, -1, 2, -2, -3, 1, 2, 3 });
            data.Add(new int[] { 9, 1, -3, 2, 4, 8, 3, -1, 6, -2, -4, 7 });
            data.Add(new int[] { 10 });
            data.Add(new int[] { 5, 2, 99, 100, 3, 4, 7, 8 });
            data.Add(new int[] { -5, 0, 5 });
        }


        public void Execute()
        {
            data.ForEach(k =>
            {
                Console.WriteLine($"Longest consecutive sequence for fata:{string.Join(",", k)} is {LongestConsecutive(k)}");
            });
        }

        private int LongestConsecutive(int[] nums)
        {

            HashSet<int> hash = new HashSet<int>();
            foreach (int item in nums)
            {
                hash.Add(item);
            }

            HashSet<int> visited = new HashSet<int>();
            int maxLength = 0;
            int length = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!visited.Contains(nums[i]))
                {
                    //Add current item in visited
                    visited.Add(nums[i]);
                    length++;

                    var next = nums[i] + 1;
                    while (hash.Contains(next))
                    {
                        //Add next item in visited
                        visited.Add(next);
                        next++;
                        length++;
                    }

                    var pre = nums[i] - 1;
                    while (hash.Contains(pre))
                    {
                        //Add previous item in visited
                        visited.Add(pre);
                        pre--;
                        length++;
                    }

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
                length = 0;
            }

            return maxLength;
        }
    }
}
