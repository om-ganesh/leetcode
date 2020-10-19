using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class MinDifferenceBetweenArrays
    {
        List<KeyValuePair<int[], int[]>> dataset = new List<KeyValuePair<int[], int[]>>();
        public MinDifferenceBetweenArrays()
        {
            dataset.Add(new KeyValuePair<int[], int[]>(
                new int[]{1,3,15,11,2 },
                new int[] {23,127,235,19,8 }
                ));
            dataset.Add(new KeyValuePair<int[], int[]>(
               new int[] { 10, 5, 40 },
               new int[] { 50,90,80 }
               ));
            dataset.Add(new KeyValuePair<int[], int[]>(
               new int[] { 3,4,6,7},
               new int[] { 2,3,8,9 }
               ));
        }

        public void Execute()
        {
            dataset.ForEach(data =>
            {
                var result = SmallDifferenceBetweenTwoArrays(data.Key, data.Value);
                Console.WriteLine($"Smallest difference between [{string.Join(",", data.Key)}] and [{string.Join(",", data.Value)}] is {result}");
            });
        }

        private int SmallDifferenceBetweenTwoArrays(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);

            int min = Math.Abs(a[0] - b[0]);
            for(int i=0, j=0; i<a.Length && j<b.Length;)
            {
                var temp = Math.Abs(a[i] - b[j]);
                if(temp < min)
                {
                    min = temp;
                }

                if(a[i]<b[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return min;
        }
    }
}
