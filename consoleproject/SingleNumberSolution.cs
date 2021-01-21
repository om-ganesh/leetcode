using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /// <summary>
    /// Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
    /// Follow up: Could you implement a solution with a linear runtime complexity and without using extra memory?
    /// https://leetcode.com/problems/single-number/
    /// </summary>
    class SingleNumberSolution
    {
        List<int[]> dataset;
        public SingleNumberSolution()
        {
            dataset = new List<int[]>();
            dataset.Add(new int[] {1});
            dataset.Add(new int[] {3,3,2,2,4 });
            dataset.Add(new int[] {2,2,1});
            //dataset.Add(new int[] {});
        }

        public void Execute()
        {
            dataset.ForEach(data =>
            {
                Console.WriteLine($"The single number in {string.Join(",", data)} is {SingleNumber_Math(data)}");
            });
        }


        // Most elegant
        public int SingleNumber(int[] nums)
        {
            int result=0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }
            return result;
        }

        // Using mathematics
        public int SingleNumber_Math(int[] nums)
        {
            int numberSum=0;
            int arraySum =0;
            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(!hash.Contains(nums[i]))
                {
                    numberSum += 2*nums[i];
                    hash.Add(nums[i]);
                }
                arraySum += nums[i];
            }

            return numberSum-arraySum;
        }
        // Using hashtable to keep track 
        public int SingleNumber_Hash(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = 2;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }

            foreach (var kvp in dict)
            {
                if (kvp.Value == 1)
                    return kvp.Key;
            }
            return -1;
        }

        //Using array sorting
        public int SingleNumber_Sorting(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                if (nums[i] != nums[i + 1])
                    return nums[i];
            }
            return nums[nums.Length - 1];
        }
    }
}
