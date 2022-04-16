using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindMustDo75Leetcode
{
    class StockBuyProblem
    {
        public StockBuyProblem()
        {
            int[] arr = new int[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(arr));
        }
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int minSoFar = prices[0];
            for(int i=0;i<prices.Length;i++)
            {
                int profit = prices[i] - minSoFar;
                if(profit > maxProfit)
                {
                    maxProfit = profit;
                }
                if(minSoFar<prices[i])
                {
                    minSoFar = prices[i];
                }
            }
            return maxProfit;
        }
    }
}
