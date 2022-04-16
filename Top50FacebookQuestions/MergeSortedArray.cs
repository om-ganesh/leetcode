using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top50FacebookQuestions
{
    /// <summary>
    /// https://leetcode.com/problems/merge-sorted-array
    /// </summary>
    public class MergeSortedArray
    {
        public void Execute()
        {
            int[] nums1 = new int[] { 5, 12, 99, 100, 300, 0, 0, 0 };
            int m = 5;
            int[] nums2 = new int[] { 1, 2, 11 };
            int n = 3;

            Console.WriteLine($"Array1: {string.Join(",", nums1)}, \nArray2: {string.Join(",", nums2)}");
            Merge(nums1, m, nums2, n);
            Console.WriteLine($"Merged array result {string.Join(",", nums1)}");
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int endPtr = m + n - 1;
            m--;
            n--;
            for (int i = endPtr; i >= 0; i--)
            {
                //Console.WriteLine($"i={i},m={m},n={n}, nums1={string.Join(",", nums1)}");
                if (m < 0)
                {
                    nums1[i] = nums2[n--];
                }
                else if (n < 0)
                {
                    nums1[i] = nums1[m--];
                }
                else
                {
                    nums1[i] = (nums1[m] > nums2[n]) ? nums1[m--] : nums2[n--];
                }
            }
        }
    }
}
