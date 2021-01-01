using System;
using System.Collections.Generic;

namespace consoleproject
{
    class ArrayFormationThroughConcatenation
    {
        List<Tuple<int[], int[][]>> data = new List<Tuple<int[], int[][]>>();
        public ArrayFormationThroughConcatenation()
        {
            data.Add(new Tuple<int[], int[][]>(
                new int[] { 2, 9, 1, 3, 5, 11, 15, 8, 7, 10 },
                new int[][]{
                    new int[] { 1, 3, 5 },
                    new int[] { 2, 9 },
                    new int[] { 11, 15, 8, 7, 10 }
                }));
            data.Add(new Tuple<int[], int[][]>(
                new int[] { 49, 18, 16 },
                new int[][]{
                    new int[] { 16,18,49 }
                }));
            data.Add(new Tuple<int[], int[][]>(
                new int[] { 1, 3, 5, 7 },
                new int[][]{
                    new int[] { 2,4,6,8 }
                }));
            data.Add(new Tuple<int[], int[][]>(
                new int[] { 100, 2, 98, 28, 44, 55, 37 },
                new int[][]{
                    new int[] { 28, 46, 57 },
                    new int[] { 37, 19, 40, 38 }
                }));
        }


        public void Execute()
        {
            data.ForEach(k =>
            {
                var result = CanFormArray(k.Item1, k.Item2);
                Console.WriteLine($"Is array:{string.Join(",", k.Item1)} formed using concatenation? {result}");
            });
        }

        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            int j;
            int[] elements = new int[101];  //as end value can be 100 so to store them in element[100] index
            for (int i = 0; i < pieces.Length; i++)
            {
                for (j = 0; j < pieces[i].Length; j++)
                {
                    elements[pieces[i][j]] = i + 1;
                }
            }

            for (int i = 0; i < arr.Length; i = i + j)
            {
                int piece = elements[arr[i]] - 1;
                // piece will be -ve if the item contained in array is not present in the pieces
                if (piece < 0)
                {
                    return false;
                }
                for (j = 0; j < pieces[piece].Length; j++)
                {
                    if (arr[i + j] != pieces[piece][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
