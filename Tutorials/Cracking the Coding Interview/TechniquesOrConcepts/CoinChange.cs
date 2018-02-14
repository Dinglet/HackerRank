/*
DP: Coin Change
https://www.hackerrank.com/challenges/ctci-coin-change/problem
*/
using System;

namespace CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int target = Convert.ToInt32(tokens_n[0]);
            int numberOfTypes = Convert.ToInt32(tokens_n[1]);
            string[] coins_temp = Console.ReadLine().Split(' ');
            int[] valuesOfCoins = Array.ConvertAll(coins_temp,Int32.Parse);

            var countsOfWays = new UInt64[target + 1];
            countsOfWays[0] = 1;
            foreach(int coinValue in valuesOfCoins)
            {
                for(int tempTarget = coinValue; tempTarget <= target; ++tempTarget)
                {
                    countsOfWays[tempTarget] = checked(countsOfWays[tempTarget] + countsOfWays[tempTarget - coinValue]);
                }
            }
            Console.WriteLine(countsOfWays[target]);
        }
    }
}
