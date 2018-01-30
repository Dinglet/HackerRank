using System;
using System.Collections.Generic;

namespace TwoStacks
{
    class Program
    {
        class TwoStackQueue<T>
        {
            private Stack<T> stackIn, stackOut;
            public TwoStackQueue()
            {
                stackIn = new Stack<T>();
                stackOut = new Stack<T>();
            }
            public void Enqueue(T value)
            {
                stackIn.Push(value);
            }
            public T Dequeue()
            {
                if(stackOut.Count > 0)
                    return stackOut.Pop();
                else if(stackIn.Count > 0)
                {
                    PourInToOut();
                    return stackOut.Pop();
                }
                else
                    throw new InvalidOperationException();
            }
            public T Peek()
            {
                if(stackOut.Count > 0)
                    return stackOut.Peek();
                else if(stackIn.Count > 0)
                {
                    PourInToOut();
                    return stackOut.Peek();
                }
                else
                    throw new InvalidOperationException();
            }
            private void PourInToOut()
            {
                foreach(var value in stackIn.ToArray())
                    stackOut.Push(value);
                stackIn.Clear();
            }
        }
        static void Main(string[] args)
        {
            int numberOfQueries = Convert.ToInt32(Console.ReadLine());
            TwoStackQueue<int> queue = new TwoStackQueue<int>();
            for(int i_query = 0; i_query < numberOfQueries; i_query++){
                string[] queryParsed = Console.ReadLine().Split(' ');
                switch(Convert.ToInt32(queryParsed[0]))
                {
                    case 1:
                        queue.Enqueue(Convert.ToInt32(queryParsed[1]));
                        break;
                    case 2:
                        queue.Dequeue();
                        break;
                    case 3:
                        Console.WriteLine(queue.Peek());
                        break;
                }
            }
        }
    }
}
