/*
Sorting: Bubble Sort
https://www.hackerrank.com/challenges/ctci-bubble-sort/problem
*/
using System;

namespace BubbleSort
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp,Int32.Parse);
            int countSwap = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        Swap(ref a[j], ref a[j + 1]);
                        countSwap+=1;
                    }
                }
            }
            Console.WriteLine(@"Array is sorted in {0} swaps.
First Element: {1}
Last Element: {2}", countSwap, a[0], a[a.Length-1]);
        }
    }
}
