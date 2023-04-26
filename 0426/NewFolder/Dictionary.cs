using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0426.NewFolder
{
    internal class Dictionary<Tkey, TValue> where Tkey : IEquatable<Tkey>   //비교해서 같은 값인지 확인 가능할때 사용가능하게 제한자를 설정
    {
        private const int DefaultCapacity = 1000; //HashTable의 크기를 사전에 설정해준다.

        private struct Entry
        {
            public enum State { None, Using, Deleted}   //열거형으로 key가 지정된 table에 상태를 확인하는걸 나타낸다.

            public State state;
            public Tkey key;        //키 값
            public TValue value;    //데이터 값
        }

        private Entry[] table; //구조체 Entry를 기준으로 table 배열 생성(HashTable에 큰 박스를 생성)

        public Dictionary()
        {
            table = new Entry[DefaultCapacity]; //Dictionary() 인스턴스를 생성시 생성되게 설정
        }

        public TValue this[Tkey key]
        {
            get//this[Tkey key]로 입력받았을때 key위치에 있는 value의 값을 내보내기
            {
                //key를 index로 해싱하는것
                int index = Math.Abs(key.GetHashCode()%table.Length);   //Math.Abs는 절대값으로 만들어주는 함수
                                                                        //GetHashCode는 Tkey로 받은 값을 해싱 해주는 함수
                //key가 일치하는 데이터가 나올때까지 다음으로 이동하며 반복
                while (table[index].state==Entry.State.Using)
                {
                    //key와 table[index]의 키가 동일할때
                    if (key.Equals(table[index].key))       //Equals는 a.Equals(b)일때 a와 b가 같은 경우 true를 내보낸다.
                    {
                        //그 table[index]의 value를 내보낸다.
                        return table[index].value;
                    }
                    //동일한 키 값을 못찾고 비어있는 공간을 못찾으면 반복을 끝내준다.
                    if (table[index].state==Entry.State.None)
                    {
                        break;
                    }
                    //index를 다음칸으로 이동
                    index=++index%table.Length;
                }
                throw new InvalidOperationException(); //찾는 Key가 없다고 오류를 내보낸다.
            }
            set//this{Tkey key]에 value를 집어 넣기
            {
                //key를 index로 해싱
                int index=Math.Abs(key.GetHashCode()%table.Length);

                //key가 일치하는 데이터가 나올 때까지 다음으로 이동
                while (table[index].state==Entry.State.Using)
                {
                    //동일한 키값을 찾은 경우 그 값에 덮어 쓴다
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return;
                    }
                    //동일한 키 값을 못찾고 비어있는 공간을 못찾으면 반복을 끝내준다.
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    index=++index%table.Length;
                }
                throw new InvalidOperationException();//동일한 Key를 찾지 못한경우 오류를 내보낸다
            }
        }

        public void Add(Tkey key, TValue value) //비어있는 자리에 새로운 key와 value를 넣는 함수
        {
            //key를 index로 해싱
            int index = Math.Abs(key.GetHashCode()%table.Length);

            //사용중이 아닌 index 까지 다음으로 이동하며 반복
            while (table[index].state==Entry.State.Using)
            {
                //동일한 키 값을 찾았을 때 오류
                if (key.Equals(table[index].key))   //하나의 키에 두개의 값이 들어 갈 수 없으니 오류를 내보낸다
                {
                    throw new InvalidOperationException();
                }
                //다음 index로 이동
                index=++index%table.Length;
            }
            //사용중이 아닌 index를 발견한 경우 그 위치에 저장해준다
            table[index].key = key;
            table[index].value = value;
            table[index].state=Entry.State.Using;//빈 공간에 값이 들어갔으므로 using으로 바꿔준다.
        }
        public bool Remove(Tkey key)    //기존에 저장되어있는 key와 value를 지우는 함수
        {
            //key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            //key값과 동일한 데이터를 찾을때까지 index 증가
            while (table[index].state != Entry.State.None)  //비어있지 않은 공간일 경우 계속 반복
            {
                if (table[index].state == Entry.State.Deleted)//지워진 장소일 경우 찾는 공간 Using 상태가 아니므로 빈공간은 아니므로 그냥 continue 해준다.
                    continue;
                //동일한 키값을 찾았을 때 지운상태로 표시
                if (key.Equals(table[index].key))
                {
                    table[index].state = Entry.State.Deleted;   //Deleted로 설정해주면 Add로 추가할때 그 위에 덮어 쓸 수 있다.
                    return true;
                }
                //동일한 키값을 찾지 못한경우 반복을 끝내준다.
                if (table[index].state == Entry.State.None)
                {
                    break;
                }
                //index를 증가시킨다.
                index = ++index % table.Length;
            }
            //지우려는 키값이 없으므로 false를 내보내준다.
            return false;
        }

    }
}
