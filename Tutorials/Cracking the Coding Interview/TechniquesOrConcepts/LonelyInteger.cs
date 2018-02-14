/*
Bit Manipulation: Lonely Integer
https://www.hackerrank.com/challenges/ctci-lonely-integer/problem
*/
using System;

namespace LonelyInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInteger = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] array = Array.ConvertAll(a_temp,Int32.Parse);
            int result = 0;
            foreach(var value in array)
                result ^= value;
            Console.WriteLine(result);
        }
    }
}
