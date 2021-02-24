using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Analysis
{
    public class RingStack<T>
    {
        private int start;
        private int end;
        private int size;
        private T[] stack;

        public RingStack(int size)
        {
            stack = new T[size];
            this.size = size;
            start = end = 0;
        }

        public void push(T data)
        {
            stack[end] = data;
            end = (end + 1) % size;
            if (end == start) start = (start + 1) % size;
        }

        /*public void print()
        {
            int i = start;

            while (i != end)
            {
                Console.Write(stack[i].ToString() + ' ');
                i = (i + 1) % size;
            }
            Console.WriteLine();
        }*/

        public T pop()
        {
            if (start == end) return default(T);
            if (--end < 0) end = size - 1;
            return stack[end];
        }

        public bool isempty() 
        {
            return (start == end);
        }

        public void clear() 
        {
            start = end = 0;
        }

        /*
        public int count()
        {
            return 0;
        }*/
    }
}
