using System;

using NUnit.Framework;

using Top50FacebookQuestions;

namespace leetcodesolution.tests
{
    [TestFixture]
    public class MergeSortedArrayTests
    {
        [Test]
        public void MergeExclusiveArrays()
        {
            int[] nums1 = new int[] { 5, 12, 99, 100, 300, 0, 0, 0 };
            int m = 5;
            int[] nums2 = new int[] { 1, 2, 3 };
            int n = 3;

            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 1, 2, 3, 5, 12, 99, 100, 300 }, nums1);
        }

        [Test]
        public void MergeEvenCountExclusiveArrays()
        {
            int[] nums1 = new int[] { 15, 22, 30, 40, 0, 0 };
            int m = 4;
            int[] nums2 = new int[] { 20, 70 };
            int n = 2;

            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 15, 20, 22, 30, 40, 70 }, nums1);
        }

        [Test]
        public void MergeOverlapArrays()
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = new int[] { 2, 5, 6 };
            int n = 3;

            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 1, 2, 2, 3, 5, 6 }, nums1);
        }

        [Test]
        public void MergeSingleArrays()
        {
            int[] nums1 = new int[] { 1, 0 };
            int m = 1;
            int[] nums2 = new int[] { 2 };
            int n = 1;

            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 1, 2 }, nums1);

            nums1 = new int[] { 1, 0 };
            nums2 = new int[] { 1 };
            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 1, 1 }, nums1);
        }

        [Test]
        public void MergeOneEmptyArrays()
        {
            int[] nums1 = new int[] { 100 };
            int m = 1;
            int[] nums2 = new int[] { };
            int n = 0;

            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 100 }, nums1);

            m = 0;
            nums1 = new int[] { 0 };
            n = 1;
            nums2 = new int[] { 100 };
            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { 100 }, nums1);
        }

        [Test]
        public void MergeBothEmptyArrays()
        {
            int[] nums1 = new int[] { };
            int m = 0;
            int[] nums2 = new int[] { };
            int n = 0;

            new MergeSortedArray().Merge(nums1, m, nums2, n);
            Assert.AreEqual(new int[] { }, nums1);
        }

    }
}
