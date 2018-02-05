/*
Time Complexity: Primality
https://www.hackerrank.com/challenges/ctci-big-o/problem
*/
using System;

namespace Primality
{
    class Program
    {
        static class Prime
        {
            public static bool IsPrime(int n)
            {
                if(n<2)
                    return false;
                for(int divider = 2; divider <= (int)Math.Sqrt(n); ++divider)
                    if(n%divider == 0)
                        return false;
                return true;
            }
        }
        static void Main(string[] args)
        {
            int numberOfData = Convert.ToInt32(Console.ReadLine());
            for(int indexOfData = 0; indexOfData < numberOfData; ++indexOfData)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                if(Prime.IsPrime(n))
                    Console.WriteLine("Prime");
                else
                    Console.WriteLine("Not prime");
            }
        }
    }
}
