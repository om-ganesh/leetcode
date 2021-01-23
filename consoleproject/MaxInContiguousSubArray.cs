using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class MaxInContiguousSubArray
    {
        List<int[]> data = new List<int[]>();
        public MaxInContiguousSubArray()
        {
            data.Add(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            data.Add(new int[] { 1});
            data.Add(new int[] { 0 });
            data.Add(new int[] { -100000 });
            data.Add(new int[] { 5, 2, 99, 100, 3, 4, 7, 8 });
            data.Add(new int[] { -2, -1 });
        }


        public void Execute()
        {
            data.ForEach(k =>
            {
                Console.WriteLine($"Max sum for Longest consecutive sequence in array {string.Join(",", k)} =  {MaxSubArray(k)}");
            });
        }

        public int MaxSubArray(int[] nums)
        {
            int[] bestMaxNums = new int[nums.Length]; 
            bestMaxNums[0] = nums[0];
            for(int i =1; i<nums.Length; i++)
            {
                bestMaxNums[i] = Math.Max(nums[i], bestMaxNums[i - 1]+nums[i]);
            }
            return bestMaxNums.Max();
        }
    }
}
