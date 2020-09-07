using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// Source: https://leetcode.com/problems/two-sum/
    /// </summary>
    class TwoSum
    {
        List<KeyValuePair<int, int[]>> numsList = new List<KeyValuePair<int, int[]>>();
        
        public TwoSum()
        {
            numsList.Add(new KeyValuePair<int, int[]>( 9, new int[] { 2, 7, 11, 15 }));
            numsList.Add(new KeyValuePair<int, int[]>( 6, new int[] { 3, 2, 4}));
            numsList.Add(new KeyValuePair<int, int[]>(6, new int[] { 3, 3 }));
        }

        public void Execute()
        {
            numsList.ForEach(k =>
            {
                var result = TwoSumOperation(k.Value, k.Key);
                Console.WriteLine($"Input: {string.Join(",",k.Value)}, Output: {string.Join(",", result)}");
            });
        }

        private int[] TwoSumOperationLegacy(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for(int j= i+1; j< nums.Length; j++)
                {
                    if(nums[i]+nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null; //Unexpected scenario, as per given condition
        }

        // Two pass using Hashtable
        private int[] TwoSumOperationTwoPass(int[] nums, int target)
        {
            Hashtable hash = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                hash.Add(nums[i], i);
            }


            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (hash.Contains(complement))
                {
                    var index = Convert.ToInt32(hash[complement]);
                    if(index != i)
                    {
                        return new int[] { i, index };
                    }  
                }
            }

            return null; //Unexpected scenario, as per given condition
        }

        // One pass using Dictionary
        private int[] TwoSumOperation(int[] nums, int target)
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
            return null; //Unexpected scenario, as per given condition
        }
    }
}
