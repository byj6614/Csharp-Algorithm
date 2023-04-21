using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Stack<T>
    {
        private List<T> container;      //어탭터로 List 를 불러오기
        public Stack()      //stack을 배열로 만들기 위해 새로운 list를 만든다
        {   //                  ↓↓↓↓↓↓   
            container = new List<T>();
        }
        public void Push(T item)// 입력받은 item을 배열에 추가한다.
        {
            container.Add(item);        //list의 Add함수를 통해 배열에 추가
        }
        public T Pop()              //PoP은 배열 가장 마지막에 있는 값을 내보내고 그 공간을 지우는 함수
        {
            T item = container[container.Count - 1];        //count를 통해 배열 마지막을 불러온다
            container.RemoveAt(container.Count - 1);        //그리고 그 배열의 공간을 삭제한다.
            return item;                                    //item이라는 공간에 있던 값을 내보낸다.
        }
    }
}
