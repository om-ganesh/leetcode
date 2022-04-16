using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYorkCoders
{
    /// <summary>
    /// Source: https://leetcode.com/problems/two-sum/
    /// </summary>
    public class TwoSumProblem
    {
        // Just a driver method (not part of the solution)
        public void Execute()
        {
            // Creating test data
            List<KeyValuePair<int, int[]>> numsList = new List<KeyValuePair<int, int[]>>();
            numsList.Add(new KeyValuePair<int, int[]>(9, new int[] { 2, 7, 11, 15 }));
            numsList.Add(new KeyValuePair<int, int[]>(6, new int[] { 3, 2, 4 }));
            numsList.Add(new KeyValuePair<int, int[]>(6, new int[] { 3, 3 }));

            numsList.ForEach(k =>
            {
                var result = TwoSum(k.Value, k.Key);
                Console.WriteLine($"Input: {string.Join(",", k.Value)}, Output: {string.Join(",", result)}");
            });
        }

        private int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (dict.TryGetValue(complement, out int index))
                {
                    return new int[] { i, index };
                }

                dict.Add(nums[i], i);
            }
            return null;
        }
    }
}
