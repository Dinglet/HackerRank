/*
Tries: Contacts
https://www.hackerrank.com/challenges/ctci-contacts/problem
*/
using System;
using System.Collections;

namespace Trie
{
    class Program
    {
        private class TrieNode
        {
            private Hashtable hashtable;
            private int count = 0;
            public TrieNode(){hashtable = new Hashtable();}
            public int Count
            {
                get{return count;}
            }
            public object this[object key]
            {
                get{return hashtable[key];}
                set{hashtable[key]=value;}
            }
            public void Add(object key, object value)
            {
                hashtable.Add(key, value);
            }
            public bool ContainsKey(object key){return hashtable.ContainsKey(key);}
            public void PrintItems(string prefix="")
            {
                if(ContainsKey('\0'))
                    Console.WriteLine(prefix);
                foreach(var key in hashtable.Keys)
                {
                    if((char)key=='\0')
                        continue;
                    ((TrieNode)hashtable[key]).PrintItems(prefix + (char)key);
                }
            }
            public void IncreaseCount()
            {
                count += 1;
            }
        }
        class Trie
        {
            TrieNode root;
            
            public Trie(){root = new TrieNode();}
            public void Add(string str)
            {
                int index = 0;
                TrieNode node = root;
                while(index<str.Length && node.ContainsKey(str[index]))
                {
                    node = (TrieNode)node[str[index++]];
                }
                if(index < str.Length)
                {
                    do
                    {
                        node.Add(str[index], new TrieNode());
                        node = (TrieNode)node[str[index++]];
                    }while(index < str.Length);
                    node.Add('\0', null);
                    IncreaseCount(str);
                }
            }
            public int CountAllStartsWith(string prefix="")
            {
                int index = 0;
                TrieNode node = root;
                while(index<prefix.Length && node.ContainsKey(prefix[index]))
                {
                    node = (TrieNode)node[prefix[index++]];
                }
                if(index < prefix.Length)
                    return 0;
                return node.Count;
            }
            public void PrintItems(string prefix="")
            {
                root.PrintItems(prefix);
            }
            private void IncreaseCount(string str)
            {
                int index = 0;
                TrieNode node = root;
                while(index<str.Length)
                {
                    node.IncreaseCount();
                    node = (TrieNode)node[str[index]];
                    index += 1;
                }
                node.IncreaseCount();
            }
        }
        static void Main(string[] args)
        {
            int numberOfInstructions = Convert.ToInt32(Console.ReadLine());
            Trie trie = new Trie();
            for(int index_instruction = 0; index_instruction < numberOfInstructions; index_instruction++){
                string[] tokens_op = Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];
                switch(op)
                {
                    case "add":
                        trie.Add(contact);
                        break;
                    case "find":
                        Console.WriteLine(trie.CountAllStartsWith(contact));
                        break;
                }
            }
        }
    }
}
