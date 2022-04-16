using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindMustDo75Leetcode
{
    class TwoSumProblem
    {
        public TwoSumProblem()
        {
            int[] arr = new int[] { -7, -7, 11, 15, 8, 11 };
            int target = -14;
            var result = TwoSum(arr, target);
            Console.WriteLine(string.Join(",", result));

        }
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i=0;i<nums.Length;i++)
            {
                int searchValue = target - nums[i];
                if(dict.ContainsKey(searchValue))
                {
                    return new int[] { dict[searchValue], i };
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }
            return null;
        }
    }
}
