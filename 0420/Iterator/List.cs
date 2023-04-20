using _0420.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    internal class List<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>       //class가 아닌 struct로 구현 하는건 가리키는 '값'이기 때문
        {
            private List<T> list;                   //list를 지정하기위한 변수
            private int index;                      //List 배열의 위치를 지정하는 변수
            private T current;                      //list[index]의 값을 넣기 위한 변수
            public Enumerator(List<T> list)         //초기화
            {
                this.list = list;                   //list에 List<T> list를 넣는다.
                this.index = 0;                     //배열 시작위치는 0부터 이기 때문에 0을 넣는다.
                this.current=default(T);            //배열이 아닌 위치이니 default(T)를 넣어 아무것도 없는것으로 한다.
            }
            public T Current { get { return current; } }        //aaa.Current시 current를 내보낸다.

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
             
            }

            public bool MoveNext()                      //배열의 앞으로 이동하기 위한 함수
            {
                if (index < 0||index>= list.Count)      //배열은 0부터 시작해서 Count-1까지 있으므로 그아래거아 이상이면 값이 존재하지 않는다는 뜻
                {
                    current = default(T);
                    return false;
                }
                else
                {
                    current= list[index++];             //가르키는 인덱스의 값을 옮기기전에 current에 기존 값을 넣고 인덱스를 옮긴다.
                    return true;
                }
               

               
            }

            public void Reset()                         //Reset을 통해 처음으로 돌아간다.
            {
                current = default(T);                   //처음으로 돌아가기 때문에 index는0을 current는 아무것도 없는 상태로 만든다.
                index = 0;
            }
        }
    }
}
