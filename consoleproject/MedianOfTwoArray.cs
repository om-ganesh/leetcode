using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    /// Follow up: The overall run time complexity should be O(log (m+n)).
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// </summary>
    class MedianOfTwoArray
    {
        List<Tuple<int[], int[]>> data = new List<Tuple<int[], int[]>>();

        public MedianOfTwoArray()
        {
            data.Add(new Tuple<int[], int[]>(new int[] {}, new int[] {}));
            data.Add(new Tuple<int[], int[]>(new int[] {}, new int[] {4}));
            data.Add(new Tuple<int[], int[]>(new int[] {3}, new int[] {}));
            data.Add(new Tuple<int[], int[]>(new int[] {3}, new int[] {4}));
            data.Add(new Tuple<int[], int[]>(new int[] {3}, new int[] {2,4}));
            data.Add(new Tuple<int[], int[]>(new int[] { 0, 0 }, new int[] {}));
            data.Add(new Tuple<int[], int[]>(new int[] { 0, 0 }, new int[] { 0, 0 }));
            data.Add(new Tuple<int[], int[]>(new int[] { 1, 2 }, new int[] { 3, 4 }));
            data.Add(new Tuple<int[], int[]>(new int[] { 1, 3 }, new int[] { 2 }));
            data.Add(new Tuple<int[], int[]>(new int[] { 5, 6 }, new int[] { 1, 4 }));
            data.Add(new Tuple<int[], int[]>(new int[] { 9,11,12 }, new int[] { 9, 10, 13, 15 }));
            data.Add(new Tuple<int[], int[]>(new int[] { 8,11,12 }, new int[] { 9, 10 }));
            data.Add(new Tuple<int[], int[]>(new int[] { -8,-1,12 }, new int[] { 9, 10 }));
            data.Add(new Tuple<int[], int[]>(new int[] { -8,-1,0 }, new int[] { -19, -10 }));
            data.Add(new Tuple<int[], int[]>(new int[] { -2,-1 }, new int[] { -4, -3 }));
        }

        public void Execute()
        {
            data.ForEach(t => {

                Console.WriteLine($"Input1: {string.Join(",", t.Item1)}, Input2: {string.Join(",", t.Item2)}");
                var result = FindMedianSortedArrays(t.Item1, t.Item2);
                Console.WriteLine($"Median: {result}");

            });
        }
        private double? FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length = nums1.Length + nums2.Length;
            int[] result = new int[length];
            int i = 0;
            int j = 0;
            bool finishi = false;
            bool finishj = false;

            while(!(finishi && finishj))
            {
                //If one array is completed
                if(!finishi && i == nums1.Length)
                {
                    finishi = true;
                }
                if(!finishj && j == nums2.Length)
                {
                    finishj = true;
                }

                if(finishi && finishj)
                {
                    break;
                }
                else if(finishi && !finishj)
                {
                    result[i + j] = nums2[j++];
                }
                else if(finishj && !finishi)
                {
                    result[i + j] = nums1[i++];
                }
                else if(nums1[i] <= nums2[j])
                {
                    result[i + j] = nums1[i++];
                }
                else
                {
                    result[i + j] = nums2[j++];
                }
            }

            if(length == 0)
            {
                return null;
            }
            else if(length%2 == 1)
            {
                return result[length / 2];
            }
            else
            {
                return (result[-1 + length / 2] + result[length / 2]) * 1.0 /2;
            }
        }
    }
}
