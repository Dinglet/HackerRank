using System;
using System.Linq;

namespace LeftRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp,Int32.Parse);
            int[] aLeftRotated = LeftRotation(a, k);
            foreach(var value in aLeftRotated)
            {
                Console.Write(value + " ");
            }
        }
        static int[] LeftRotation(int[] input, int shiftNum)
        {
            int n = input.Length;
            return input.Select((value, key)=> input[(key+shiftNum)%n]).ToArray();
        }
    }
}
