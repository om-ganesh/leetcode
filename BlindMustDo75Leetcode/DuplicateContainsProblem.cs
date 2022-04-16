using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindMustDo75Leetcode
{
    class DuplicateContainsProblem
    {
        public DuplicateContainsProblem()
        {
            int[] arr = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            Console.WriteLine(ContainsDuplicate(arr));
        }
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            foreach (int x in nums)
            {
                if (hash.Contains(x))
                {
                    return true;
                }
                hash.Add(x);
            }
            return false;
        }
    }
}
