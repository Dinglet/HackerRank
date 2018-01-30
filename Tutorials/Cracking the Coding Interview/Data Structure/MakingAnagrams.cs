using System;
using System.Collections;
using System.Linq;
/*
Strings: Making Anagrams
https://www.hackerrank.com/challenges/ctci-making-anagrams/problem
*/
namespace MakingAnagrams
{
    class Program
    {
        class Bucket
        {
            private Hashtable keyCountPairs = new Hashtable();
            public char[] Keys{get{return keyCountPairs.Keys.Cast<char>().ToArray();}}
            public int this[char key]
            {
                get{return Convert.ToInt32(keyCountPairs[key]);}
                set{keyCountPairs[key] = value;}
            }
            public bool Contains(char key)
            {
                return keyCountPairs.ContainsKey(key);
            }
            public Bucket(string str)
            {
                var query = 
                    from letter in str
                    group letter by letter;
                foreach(IGrouping<char, char> charGroup in query)
                {
                    // Console.WriteLine(charGroup.Key + " " + charGroup.Count());
                    keyCountPairs.Add(charGroup.Key, charGroup.Count());
                }
            }
            public static int CountDifference(Bucket a, Bucket b)
            {
                int count = 0;
                var keys = a.Keys.Union(b.Keys);
                foreach(var key in keys)
                {
                    if(a.Contains(key))
                        if(b.Contains(key))
                            count += Math.Abs(a[key]-b[key]);
                        else
                            count += a[key];
                    else
                        count += b[key];
                }
                return count;
            }
        }
        static void Main(string[] args) {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Bucket bucketA = new Bucket(a), bucketB = new Bucket(b);
            int numOfDifference = Bucket.CountDifference(bucketA, bucketB);
            Console.WriteLine(numOfDifference);
        }
    }
}
