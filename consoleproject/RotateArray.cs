using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class RotateArray
    {
        List<Tuple<int[], int>> dataset;

        public RotateArray()
        {
            dataset = new List<Tuple<int[], int>>();
            dataset.Add(new Tuple<int[], int>(new int[]{ 1, 2, 3, 4, 5, 6, 7 }, 3));///5671234
            dataset.Add(new Tuple<int[], int>(new int[]{ 1, 2, 3, 4, 5, 6 }, 4)); //345612
            //Expected: 17,18,19,20,21,22,23,24,25,26,27,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
            dataset.Add(new Tuple<int[], int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27 }, 38));
        }
        public void Execute()
        {
            dataset.ForEach(data =>
            {
                Rotate(data.Item1, data.Item2);
                Console.WriteLine(string.Join(",", data.Item1));
            });
        }

        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            // Rotate entire array
            RotateMe(nums, 0, nums.Length);
            //Rotate first k elements
            RotateMe(nums, 0, k);
            //Rotate length-k elements
            RotateMe(nums, k, nums.Length);
        }

        private void RotateMe(int[] arr, int start, int end)
        {
            while(start<end)
            {
                int temp = arr[start];
                arr[start] = arr[end-1];
                arr[end-1] = temp;
                start++;
                end--;
            }
        }

        public void Rotate_WithOnSpace(int[] nums, int k)
        {
            k = k % nums.Length;
            int[] nums1 = new int[nums.Length];
            int oldIndex = nums.Length - k;
            for (int i = 0; i < nums.Length; i++)
            {
                if (oldIndex == nums.Length)
                {
                    oldIndex = 0;
                }
                nums1[i] = nums[oldIndex++];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums1[i];
            }
        }

        public void Rotate_Attempt1(int[] nums, int k)
        {
            k = k % nums.Length;
            int[] nums1 = new int[2 * nums.Length];
            int i;
            for (i = 0; i < nums.Length; i++)
            {
                nums1[i] = nums[i];
            }
            int j;
            for (j = i; j < nums1.Length; j++)
            {
                nums1[j] = nums[j - i];
            }
            i = 0;
            j = nums.Length - k;

            while (i < nums.Length)
            {
                nums[i++] = nums1[j++];
            }
        }

    }
}
