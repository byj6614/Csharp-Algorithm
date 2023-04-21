using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Queue<T>             //LinkedList를 어댑터로 이용하면 o(n)되기 때문에 직접 구현한다.
    {
        private const int DefaultCapacity = 4;          //Queue도 배열로 나타낼거기 때문에 기본 크기를 설정해준다.
        private T[] array;                              //Queue의 배열을 생성
        private int head;                               //선입선출이기에 가장 먼저 들어온 값이 head
        private int tail;                               //가장 늦게 들어온 값이 tail이 된다.

        public Queue()                  //Queue 초기화
        {
            array = new T[DefaultCapacity + 1];         //head와 tail이 같이 있으면 꽉찬것과 비어있는것이 모호하기 때문에 그것을 방지하기위해 기존보다 1크게 만든다.
            head = 0;                                   //아무것도 없는 상태이기 때문에 배열의 0번째 공간에 있다.       
            tail = 0;                                   //head와 같은 이유
        }
        public int Count                //Queue배열 안에 있는 값에 갯수를 세기 위한것
        {
            get
            {
                if (head <= tail)       //배열의 위치가 head가 tail보다 앞쪽에 있을 때
                    return tail - head; //tail에서 head를 뺀 갯수
                else                    //그것이 아니라면 위치가 tail이 더 앞에 있다는 뜻
                    return tail - head + array.Length;      //위와 똑같은 계산을 하면 -가 나온다 거기서 array의 전체길이를 더해주면 남은 값의 갯수를 알 수 있다.
            }
        }
        public void Enqueue(T item)     //Enqueue는 item매개변수를 array[tail]공간 안에 값을 넣는 함수
        {
            if (ISFull())           //배열이 가득찬 상태에서 들어올려고 한다면 Queue의 기본 크기를 늘리기 위한 조건
            {
                Grow();             //자세한건 아래서 설명
            }
            array[tail] = item;     //배열의 매개변수를 넣는다
            MoveNext(ref tail);     //tail의 크기를 늘린다. 하지만 Queue는 원형순환이기 때문에 과정이 복잡하기에 아래서 설명
        }                           //ref란 매개변수로 전달한 값의 원본이 변경이기 때문에 이 함수 내에 있는 tail의 값을 변경한다는 뜻
        public T Dequeue()          //배열에서 값을 내보내고 그 공간을 지우는 함수
        {
            if (IsEmpty())          //그 공간이 비어있다==아직 이 배열에 아무것도 없다는 것을 뜻하며 오류를 내보낸다
            {
                throw new InvalidOperationException();
            }
            T result = array[head];//처음 들어온 값이 head이기 때문에 result에 array[head]안에 값을 넣어준다
            MoveNext(ref head);     //처음 들어온 값이 없어졌기에 2번째로 들어온 값이 1번째가 되도록 한다.
            return result;          //result를 내보내준다.
        }

        public T Peek()             //peek은 가장 처음 들어온 값(head)이 무엇인지 알려주는 함수
        {
            if (IsEmpty())          //비어있다면 head에 들어가 있는게 없다는 뜻이니 오류를 내보낸다.
            {
                throw new InvalidOperationException();
            }
            return array[head];     //array[head]를 내보낸다.
        }
        public void MoveNext(ref int index) //head 혹은 tail의 값이 변경 되는걸 도와 주는 함수
        {
            index = (index == array.Length - 1) ? 0 : index + 1;    //head혹은 tail이 (배열의 길이-1)과 같을 때 원형 순환구조이기 때문에
        }                                                           //다시 처음으로 돌아온다. 하지만 다르다면 그냥 +1 해주면 된다.
        private bool IsEmpty()          //배열이 텅 비어있을 때를 알려주는 함수
        {
            return head == tail;        //머리와 꼬리가 같은 위치에 있다는건 없단는 뜻
        }
        private bool ISFull()           //배열이 꽉 찬걸 알려주는 함수
        {
            if (head > tail)            //head가 tail보다 뒤에 있을 때
            {
                return head == tail + 1;        //배열의 위치가 head가 더 뒤에 있다면 꽉찬 상태의 원형이라면 head 앞에 tail이 있는걸 내보낸다.
            }                                   //tail뒤에 바로 head가 있다면 true를 내보낸다는 뜻이다.
            else return head == 0 && tail == array.Length - 1; //기존보다 크게 만든 배열인 이유는 head와 tail이 겹치면 비어있는것과의 경계가 모호해지기 때문에
                                                               //여유 공간을 하나 더 주고 tail과 head가 겹치지 않게 하기 위해서다 
        }                                                      //head가 0일경우와 tail의 맨 끝 추가 공간에 있을경우 true를 내보내 꽉찬걸 알려준다.

        private void Grow()             //배열이 꽉찬 상태에서 매개변수가 들어온다면 들어갈 공간이 없기 때문에 배열을 확장시켜주기 위한 함수
        {
            int newCapacity = array.Length * 2;     //배열의 새로운 크기를 기존 배열의 길이*2를 넣어준다.
            T[] newarray = new T[newCapacity];      //기존 배열에값을 복사해줄 임시 배열
            if (head < tail)                        //head가 tail보다 앞에 있다면
            {
                Array.Copy(array, newarray, Count);// 기존 배열에있는 값을 newarray에 newarray[Count]부터 복사한다
            }
            else
            {
                Array.Copy(array, head, newarray, 0, array.Length - 1); //기존 배열의 array[head]부터 array[array.Length-1]까지 newarray[0]에서 부터 복사한다. 
                Array.Copy(array, 0, newarray, array.Length - head, tail);//기존 배열의 array[0]부터 array[tail]까지 newarray[array.Length-head]부터 복사한다.
                head = 0;//복사하는 과정에서 head가 다시 맨 앞으로 도달했기 때문에 0을 넣어준다.
                tail = Count;//tail은 다음 값이 넣어질 곳을 가리켜야하기 때문에 count를 넣어준다.
            }
            array = newarray;       //기존 배열의 newarray를 넣어준다.
        }
    }
}
