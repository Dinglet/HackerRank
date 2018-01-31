/*
Heaps: Find the Running Median
https://www.hackerrank.com/challenges/ctci-find-the-running-median/problem
*/
using System;
using System.Collections.Generic;

namespace RunningMedian
{
    class Program
    {
        class RunningMedianList
        {
            Heap<int> bigger, smaller;
            private class myReverserClass : IComparer<int>  {
                public int Compare(int x, int y) => y.CompareTo(x);
            }
            public int Count{get{return bigger.Count+smaller.Count;}}
            public double Median
            {
                get
                {
                    int smallestOfbigger, biggestOfsmaller;
                    if(bigger.Count>0)
                        smallestOfbigger = bigger.Peek();
                    else
                        smallestOfbigger = 0;
                    if(smaller.Count>0)
                        biggestOfsmaller = smaller.Peek();
                    else
                        biggestOfsmaller = 0;
                    switch(Count%2)
                    {
                        case 0:
                            return Convert.ToDouble(smallestOfbigger+biggestOfsmaller)/2;
                        case 1:
                            return (bigger.Count > smaller.Count) ? smallestOfbigger : biggestOfsmaller;
                        default:
                            throw new Exception();
                    }
                }
            }
            public RunningMedianList()
            {
                bigger= new Heap<int>();
                smaller= new Heap<int>(new myReverserClass());
            }
            public void Add(int value)
            {
                if(value>Median)
                {
                    bigger.Add(value);
                    if(bigger.Count > smaller.Count+1)
                        smaller.Add(bigger.Poll());
                }
                else
                {
                    smaller.Add(value);
                    if(smaller.Count > bigger.Count+1)
                        bigger.Add(smaller.Poll());
                }
            }
        }
        class Heap<T> where T : IComparable<T>
        {
            List<T> items;
            IComparer<T> comparer;
            public int Count {get{return items.Count;}}
            private T this[int index]
            {
                get{return items[index];}
                set{items[index]=value;}
            }
            public Heap()
            {
                items = new List<T>();
                comparer = Comparer<T>.Default;
            }
            public Heap(IComparer<T> comp)
            {
                items = new List<T>();
                comparer = comp;
            }
            public void Add(T item)
            {
                items.Add(item);
                HeapifyUp();
            }
            private T GetParent(int index){return items[GetParentIndex(index)];}
            private T GetLeftChild(int index){return items[GetLeftChildIndex(index)];}
            private T GetRightChild(int index){return items[GetRightChildIndex(index)];}
            private int GetParentIndex(int index){return (index-1)/2;}
            private int GetLeftChildIndex(int index){return index*2 + 1;}
            private int GetRightChildIndex(int index){return index*2 + 2;}
            private bool HasParent(int index){return GetParentIndex(index) >= 0;}
            private bool HasLeftChild(int index){return GetLeftChildIndex(index) < Count;}
            private bool HasRightChile(int index){return GetRightChildIndex(index) < Count;}
            private void HeapifyUp()
            {
                int index = Count-1;
                while(HasParent(index) && comparer.Compare(GetParent(index), this[index])>0)
                {
                    SwapByIndex(GetParentIndex(index), index);
                    index = GetParentIndex(index);
                }
            }
            private void HeapifyDown()
            {
                int index = 0;
                while(HasLeftChild(index))
                {
                    int smallerChildIndex = GetLeftChildIndex(index);
                    if(HasRightChile(index) && comparer.Compare(GetRightChild(index), GetLeftChild(index))<0)
                    {
                        smallerChildIndex = GetRightChildIndex(index);
                    }
                    if(comparer.Compare(this[index], this[smallerChildIndex])<0)
                        break;
                    SwapByIndex(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
            }
            public T Peek()
            {
                if(Count==0)
                    throw new Exception();
                return this[0];
            }
            public T Poll()
            {
                if(Count==0)
                    throw new Exception();
                T returnValue = this[0];
                this[0] = this[Count-1];
                items.RemoveAt(Count-1);
                HeapifyDown();
                return returnValue;
            }
            private void SwapByIndex(int a, int b)
            {
                T temp=this[a];
                this[a] = this[b];
                this[b] = temp;
            }
        }
        static void Main(string[] args)
        {
            int numberOfData = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[numberOfData];
            RunningMedianList list = new RunningMedianList();
            for(int index_a = 0; index_a < numberOfData; index_a++)
            {
                list.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine(list.Median.ToString("F1"));
            }
        }
    }
}
