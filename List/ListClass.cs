using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class ListClass<T>
    {
        private const int DefaultCapacity = 10;
        private T[] items;
        private int size;

        public ListClass()
        {
            this.items= new T[DefaultCapacity];
            this.size= 0;
        }
        public int Capacity
        {
            get
            { 
                return items.Length; 
            }
        }
        public int Count
        {
            get
            {
                return size;
            }
        }
        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                return items[index]; 
            } 
            set 
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                items[index] = value; 
            }
        }
        public void Add(T item)
        {
            if(size<items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();
                items[size++] = item;
            }
        }
        public bool Remove(T item)
        {
            int index =Indexof(item);
            if(index>=0)
            {
                //TODO : 지우기 작업
                RemoveAt(index);
                return true;
            }
            else
            {
                //못 찾은 경우
                return false;
            }
        }

        public int Indexof(T item)
        {
            return Array.IndexOf(items, item,0,size);
        }

        public void RemoveAt(int index)
        {
            if(index<0||index>=size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items,index+1,items,index,size-index); 
        }

        public T? Find(Predicate<T> match)
        {
            if(match==null)
                throw new ArgumentNullException("match");
            for(int i=0;i<size;i++)
            {
                if (match (items[i]))
                {
                    return items[i]; 
                }
            }
            return default(T);
        }
        public int FindIndex(Predicate<T> match)
        {
            for(int i=0;i<size;i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }
        public void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems=new T[newCapacity];
            Array.Copy(items,0,newItems,0,size);
            items= newItems;
        }
    }
}
