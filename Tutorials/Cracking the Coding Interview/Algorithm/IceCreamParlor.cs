/*
Hash Tables: Ice Cream Parlor
https://www.hackerrank.com/challenges/ctci-ice-cream-parlor/problem
*/
using System;
using System.Collections;
using System.Linq;

namespace IceCreamParlor
{
    class Program
    {
        static int[] TwoSum(int[] nums, int target) {
            int index = 0;
            Hashtable ht = new Hashtable();
            for(index = 0; index<nums.Length; index+=1)
            {
                int couple = target-nums[index];
                if(ht.ContainsKey(couple))
                {
                    return new int[]{(int)ht[couple], index};
                }
                if(!ht.ContainsKey(nums[index]))
                    ht.Add(nums[index], index);
            }
            return new int[]{-1, -1};
        }
        static void solve(int[] arr, int money) {
            // Complete this function
            var result = TwoSum(arr, money);
            Console.WriteLine("{0} {1}", result[0]+1, result[1]+1);
        }
        static void Main(string[] args)
        {
            int numberOfDatasets = Convert.ToInt32(Console.ReadLine());
            for(int indexOfDataset = 0; indexOfDataset < numberOfDatasets; indexOfDataset++){
                int money = Convert.ToInt32(Console.ReadLine());
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr_temp = Console.ReadLine().Split(' ').Where(str => !String.IsNullOrEmpty(str)).ToArray();
                int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
                solve(arr, money);
            }
        }
    }
}
