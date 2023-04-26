using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class HashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }      //비어있는지 사용하는지 지워지는지 나타내기 위한 열거형

            public State state;     //열거형
            public TKey key;        //키
            public TValue value;    //값
        }

        private Entry[] table;      //테이블

        public HashTable()
        {
            table = new Entry[DefaultCapacity]; //테이블 생성
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;   //내보낼 value를 넣어줄 그릇 생성
                if (TryGetValue(key, out value))    //key가 가르키는index의 value를 찾아내고 잇을경우 true를 없는경우 false를 내모내는 함수
                    return value;   //value를 내보낸다
                else
                    throw new KeyNotFoundException();//key가 table에 없다면 오류를 내보낸다.
            }
            set
            {
                TryInsert(key, value, InsertionBehavior.OverrideExist); //key가 위치한곳에 value를 넣어주고 이미 값이 있다면 덮어씌어주기
            }
        }

        public void Add(TKey key, TValue value)
        {
            TryInsert(key, value, InsertionBehavior.ThrowOnExisting);
        }

        public bool TryAdd(TKey key, TValue value)
        {
            return TryInsert(key, value, InsertionBehavior.None);
        }

        public void Clear()
        {
            table = new Entry[DefaultCapacity];
        }

        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out var value);
        }

        public bool TryGetValue(TKey key, out TValue value) //내가 찾는 key의 인덱스를 가져오는 함수
        {
            int index = FindIndex(key); //key의 index를 찾아주는 함수를 실행

            if (index < 0)  //index가 0보다 작다는것은 찾는 index가 없다는 뜻이므로
            {
                value = default(TValue);    //value에 default를 주고 false를 내보낸다.
                return false;
            }
            else    //index가 잇다는 것
            {
                value = table[index].value; //value에 내가 찾는 key의 value를 넣어준다.
                return true;    //내가 찾는 value 가 있으므로 true를 내보낸다
            }
        }

        public bool Remove(TKey key)
        {
            int index = FindIndex(key);

            if (index < 0)
            {
                return false;
            }
            else
            {
                table[index].state = Entry.State.Deleted;
                return true;
            }
        }

        private enum InsertionBehavior { None, OverrideExist, ThrowOnExisting }//덮어 씌울지 오류가 난 상태인지 비어있는지 알려주는 열거형
        private bool TryInsert(TKey key, TValue value, InsertionBehavior behavior)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);//key를 index로 해싱
            while (true)//내가 끝낼때 까지 반복
            {
                if (table[index].state == Entry.State.None) //index가 가리키고 있는곳이 비어있다면 종료
                    break;
                else if (table[index].state == Entry.State.Deleted)//아래에 설명 있음
                    continue;

                if (key.Equals(table[index].key))   //key와 index의 key가 같다면 
                {
                    switch (behavior)   //InsertionBehavior의 값에 따라 아래 스위치 case 실행
                    {
                        case InsertionBehavior.OverrideExist:
                            table[index].key = key;     //지금 index.key에 받아온 key를 넣어준다
                            table[index].value = value; //지금 index.value에 받아온 value를 넣어준다.
                            return true;        //내가 찾는곳에 값이 있고 값을 덮어 씌어주었으니 true를 내보낸다.
                        case InsertionBehavior.ThrowOnExisting:     
                            throw new ArgumentException();      //오류를 내보낸다.
                        case InsertionBehavior.None:    
                        default:
                            return false;   //찾는것이 없기에 false를 내보낸다.
                    }
                }
                index = (index + 1) % table.Length;//index의 크기를 증가
            }

            //비어있는곳에 넣어주기
            table[index].state = Entry.State.Using; //index에 공간이 들어갔기에 Using을 넣어준다.
            table[index].key = key;             //지금 index.key에 받아온 key를 넣어준다
            table[index].value = value;         //지금 index.value에 받아온 value를 넣어준다.
            return true;                        //값을 넣어주는게 성공했으니 true를 내보낸다.
        }

        private int FindIndex(TKey key)     //key의 index를 찾는 함수
        {
            int index = Math.Abs(key.GetHashCode() % table.Length); //key를 index로 해싱 하기
            while (true)    //내가 break할 때 까지 반복
            {
                if (table[index].state == Entry.State.None) //key의 인덱스가 가리키는곳이 빈 공간일경우 반복을 끝낸다.
                    break;     
                else if (table[index].state == Entry.State.Deleted) //Deleted는 지워도 되는 공간==Add를 통해 덮어 씌울수 있는 공간이라는 뜻이므로 반복을 계속한다.
                    continue;

                if (key.Equals(table[index].key))   //key와 해싱한index의 key가 같은경우 index를 내보낸다.
                {
                    return index;
                }
                index = (index + 1) % table.Length; //위에 조건이 다 맞지 않는다면 index를 증가시킨다.
            }

            return -1;  //찾는 index가 없다는 뜻이므로 -1을 return
        }
    }
}