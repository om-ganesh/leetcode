using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    public class MoveZerosToEnd
    {
        List<int[]> data = new List<int[]>();
        public MoveZerosToEnd()
        {
            data.Add(new int[] { 0,1,0,3,12});
            data.Add(new int[] { 0,0,0,3,12});
            data.Add(new int[] { 10,-1,3,12,0});
            data.Add(new int[] { 0, 0, 0, 0, -10 });

        }


        public void Execute()
        {
            data.ForEach(k =>
            {
                //var result = MoveZeroesWithCopy(k);
                //Console.WriteLine($"Original Data:{string.Join(",", k)}. Moved Data:{string.Join(",", result)}");
                MoveZeroesInPlace(k);
                Console.WriteLine($"Result Data:{string.Join(",", k)}");
            });
        }

        private void MoveZeroesInPlace(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length;i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }
            for(int i=index;i<nums.Length;i++)
            {
                nums[i] = 0;
            }
        }

        private int[] MoveZeroesWithCopy(int[] nums)
        {

            int[] result = new int[nums.Length];
            for (int i = 0, j = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    result[j++] = nums[i];
                }
            }

            return result;
        }
    }
}
