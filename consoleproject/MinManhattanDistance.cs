using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    class MinManhattanDistance
    {
        List<int[,]> data = new List<int[,]>();
        public MinManhattanDistance()
        {
            data.Add(new int[5, 2] { { 0, 0 }, { 2, 2 }, { 3, 10 }, { 5, 2}, { 7,0} });
            data.Add(new int[3, 2] { { 3, 12 }, { -2, 5 }, { -4, 1 } });
            data.Add(new int[4, 2] { { 0,0 }, { 1,1 }, {1,0 }, { -1, 1} });
            data.Add(new int[2, 2] { { -1000000, -1000000 }, { 1000000, 1000000 } });
        }

        public void Execute()
        {
            data.ForEach(t => {

                var result = MinCostConnectPoints(t);
                Console.WriteLine($"Min Manhattan Distance : {result}");

            });
        }

        private int MinCostConnectPoints(int[,] points)
        {

            return -1;
        }
    }
}
