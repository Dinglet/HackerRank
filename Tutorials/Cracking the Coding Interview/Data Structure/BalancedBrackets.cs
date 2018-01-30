/*
Stacks: Balanced Brackets
https://www.hackerrank.com/challenges/ctci-balanced-brackets/problem
*/
using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    class Program
    {
        static HashSet<char> LeftBrackets = new HashSet<char>("([{"),
            RightBrackets = new HashSet<char>(")]}");
        static void Main(string[] args)
        {
            int numberOfLines = Convert.ToInt32(Console.ReadLine());
            for(int a0 = 0; a0 < numberOfLines; a0++){
                string expression = Console.ReadLine();
                if(IsBalancedBrackets(expression))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
        static bool IsBalancedBrackets(string brackets)
        {
            Stack<char> stackOfBrackets = new Stack<char>();
            foreach(char bracket in brackets)
            {
                if(LeftBrackets.Contains(bracket))
                    stackOfBrackets.Push(bracket);
                else if(RightBrackets.Contains(bracket))
                {
                    try
                    {
                        if(!IsMatch(stackOfBrackets.Pop(), bracket))
                            return false;
                    }
                    catch(InvalidOperationException e)
                    {
                        return false;
                    }
                }
                else
                    throw new Exception();
            }
            if(stackOfBrackets.Count>0)
                return false;
            return true;
        }
        static bool IsMatch(char left, char right)
        {
            return "([{".IndexOf(left) == ")]}".IndexOf(right);
        }
    }
}
