using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0418.ListClass
{
    internal class ListClass<T>
    {
        private const int arnum = 10;
        private T[] array;
        private int size;

        public ListClass()
        {
            this.array = new T[arnum];              // 인스턴스를 생성 할때 만들어지는 배열
            this.size = 0;                          // 인스턴스를 생성 하면서 생기는 사이즈
        }
        public T this[int index]            //array[index]의 값을 넣거나 쓰기위한것
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                array[index] = value;
            }
        }
        public int Count                //배열의 길이를 알기 위한 
        {
            get                 //Count를 실행했을때 size를 쓴다
            {
                return size;
            }
        }
        public int indexof(T item)
        {
            return Array.IndexOf(array, item, 0, size);         //인덱스오브 함수 생성 : 내가 찾는 단어의 배열 위치 찾기
        }

        public void Add(T item)                  //받은 내용을 추가하는 함수
        {
            if(size<arnum)                      //배열의 크기가 넘치는지 아닌지 확인하는 if문(안넘쳤을때)
                array[size++] = item;           //늘어나기전에 item을 넣기
            else
            {
                Grow();                         //size가 배열의 최대 크기를 넘었으므로 배열크기 증가
                array[size++] = item;
            }
        }

        public bool Remove(T item)
        {
            int index = indexof(item);
            if(index>=0)            //양수면 item이 배열안에 있다는 뜻으로 빼는것 가능
            {
                RemoveAt(index);    //배열에서 item을 빼기위한 함수
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public T? Find(Predicate<T> match)                  //이해가 애매합니다
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < size; i++)
            {
                if (match(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public int FindIndex(Predicate<T> match)            //이해가 애매합니다
        {
            for (int i = 0; i < size; i++)
            {
                if (match(array[i]))
                    return i;
            }
            return -1;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)               //index가 배열의 크기보다 크거가 -1일 경우 오류난것을 알리는것
                throw new IndexOutOfRangeException();
            size--;         //빼기 위해서 사이즈를 줄임
          //Array.Copy(복사할 배열,복사를 시작할 위치,복사된걸 넣을 배열,복사의 시작 위치,복사의 갯수)
            Array.Copy(array, index + 1, array, index, size - index);
        }
        public void Grow()                                          //List 배열의 기존 크기보다 커질때 배열 크기를 늘리기위한 함수
        {
            int newarnum = array.Length * 2;        //늘릴려는 길이를 넣는 그릇
            T[] newarray = new T[newarnum];         //복사할 새로운 배열
            Array.Copy(array, 0, newarray, 0, size);//기존 배열에 새로운배열로 복사
            array = newarray;                       //복사한 배열을 기존 배열에 넣기
        }

    }
}
