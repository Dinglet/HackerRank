/*
Recursion: Fibonacci Numbers
https://www.hackerrank.com/challenges/ctci-fibonacci-numbers/problem
*/
using System;

class Solution {
    
    public static int Fibonacci(int n) {
        if(n<0)throw new ArgumentOutOfRangeException("n", "The argument should not be negative.");
        switch(n)
        {
            case 0:
                return 0;
            case 1:
                return 1;
            default:
                return Fibonacci(n-2) + Fibonacci(n-1);
        }
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}
