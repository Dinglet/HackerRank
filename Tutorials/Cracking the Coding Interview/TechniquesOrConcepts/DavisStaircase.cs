/*
Recursion: Davis' Staircase
https://www.hackerrank.com/challenges/ctci-recursive-staircase/problem
*/
using System;

namespace DavisStaircase
{
    class Program
    {
        static int[] recordArray = new int[]{1, 1};
        static int CountWays(int numberOfSteps)
        {
            if(numberOfSteps >= recordArray.Length)
                Array.Resize(ref recordArray, numberOfSteps+1);
            if(recordArray[numberOfSteps] != 0)
                return recordArray[numberOfSteps];
            int count=0;
            for(int i=(numberOfSteps<3 ? numberOfSteps : 3); i>=1; --i)
                count += CountWays(numberOfSteps - i);
            recordArray[numberOfSteps] = count;
            return count;
        }
        static void Main(string[] args)
        {
            int numberOfStaircases = Convert.ToInt32(Console.ReadLine());
            for(int i_staircase = 0; i_staircase < numberOfStaircases; i_staircase++){
                int numberOfSteps = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(CountWays(numberOfSteps));
            }
        }
    }
}
