using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class AAATestClass
    {
        public void Execute()
        {
            int[] data = new int[] {3,3 };
            var result = FindSolution(data);
            Console.WriteLine(string.Join(",", result));
        }

        private int FindSolution(int[] arr)
        {
            return arr.Aggregate((x, y) => x + y);
        }
    }
}
