using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Queue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] array;
        private int head;
        private int tail;

        public Queue()
        { 
            array = new T[DefaultCapacity+1];
            head = 0;
            tail = 0;
        }
        public int Count
        {
            get
            {
                if(head <= tail)
                    return tail - head;
                else 
                    return tail- head + array.Length;
            }
        }
        public void Enqueue(T item)
        {
            if(ISFull())
            {
                Grow();
            }
            array[tail] = item;
            MoveNext(ref tail);
        }
        public T Dequeue()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException();
            }
            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public  T Peek()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return array[head];
        }
        public void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1;
        }
        private bool IsEmpty()
        {
            return head == tail;
        }
        private bool ISFull()
        {
            if (head > tail)
            {
                return head == tail + 1;
            }
            else return head == 0 && tail == array.Length - 1;

        }

        private void Grow()
        {
            int newCapacity= array.Length*2;
            T[] newarray= new T[newCapacity];
            if(head<tail)
            {
                Array.Copy(array, newarray, Count);
            }
           else
            {
                Array.Copy(array, head, newarray, 0, array.Length - 1);
                Array.Copy(array, 0, newarray, array.Length - head, tail);
                head = 0;
                tail = Count;
            }
            array= newarray;
        }
    }
}
