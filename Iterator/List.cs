using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc
{
    internal class List<T> : IEnumerable<T>//IEnumerable<T> : 반복가능하다는 인터페이스 
    {
        private const int DefaultCapacity = 10;
        private T[] items;
        private int size;

        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
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
            if (size < items.Length)
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
            int index = Indexof(item);
            if (index >= 0)
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
            return Array.IndexOf(items, item, 0, size);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                {
                    return items[i];
                }
            }
            return default(T);
        }
        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }
        public void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        public IEnumerator<T> GetEnumerator()           //IEnumerator를 상속할때 만들어야 하는 함수
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()         //IEnumerator를 상속할때 만들어야 하는 함수
        {
            return new Enumerator(this);
        }


        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;           //list를 통해 어떤list인지 확인하는것
            private int index;              //index를 통해 배열의 몇번째인지 가르키는지 확인
            private T current;              

            internal Enumerator(List<T> list)
            {
                this.list = list;
                this.index = -1;            //foreach로 돌렸을때 0부터 볼 수 있게 하기위해서 -1을준다 대신 Current를 조심해야함
                this.current = default(T);
            }

            public T Current { get { return current; } }    //내가 현재 index로 가리키고 있는 값을 내보내는것

            object IEnumerator.Current              //T Current 하고 IEnumerator.Current의 차이점은 자료형을 알고 모르고의 차이
            {
                get
                {
                    if (index < 0 || index >= list.Count)
                        throw new InvalidOperationException();
                    return Current;
                }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if(index< list.Count-1)//배열보다 커질때에 대한 경우
                {
                    current = list[++index];
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
                
            }

            public void Reset()
            {
                index = -1;
                current = default(T);
            }
        }
    }
}
