using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>  //비교해서 같은 값인지 확인 가능한것만 가능하게 제한자를 건다
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted}   //사용중인지 아닌지를 나타내기

            public State state;
            public int hashCode;
            public TKey key;            //키 값
            public TValue value;        //데이터 값
        }

        private Entry[] table;

        public Dictionary() 
        {
            table = new Entry[DefaultCapacity];
        }

        public TValue this[TKey key]
        {
            get
            {
                //1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);//GetHashCode는 해쉬코드로 바꿔주는 함수
               //2.key가 일치하는 데이터가 나올때까지 다음으로 이동
                while (table[index].state==Entry.State.Using)
                {
                    //3-1.동일한 키값을 찾았을 때 반환하기
                    if (key.Equals(table[index].key))
                    {
                        return table[index].value;
                        
                    }
                    //3-2. 동일한 키값을 못찾고 비어있는 공간을 만났을 때
                    if (table[index].state==Entry.State.None)
                    {
                        break;
                    }
                    //3-3. index를 다음으로 이동
                    index = ++index%table.Length;
                }
                throw new InvalidOperationException();
            }
            set
            {
                //1.key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                //2.key가 일치하는 데이터가 나올때가지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    //3동일한 키값을 찾았을 때 덮어 쓰기
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return;
                    }
                    if (table[index].state == Entry.State.Using)
                    {
                        break;
                    }
                    index = index < table.Length - 1 ? index + 1 : 0;
                }
                throw new InvalidOperationException();
            }
        }
        public void Add(TKey key, TValue value)
        {
            //1. key를 index로 해싱
            int index= Math.Abs(key.GetHashCode()% table.Length);   //Math.Abs는 절대값으로 바꾸는 함수

            //2.사용중이 아닌 index 까지 다음으로 이동
            while (table[index].state==Entry.State.Using)
            {
                //3-1 동일한 키값을 찾았을 때 오류(C# Dictionary는 중복 키를 허횽하지 않음)
                if (key.Equals(table[index].key))
                {
                    throw new InvalidOperationException();  
                }
                //3-3 다음 index로 이동
                index = ++index % table.Length;
            }

            //4.사용중이 아닌 index를 발견한 경우 그 위치에 저장
            table[index].key= key;
            table[index].value= value;
            table[index].state = Entry.State.Using;
            
        }

        public bool Remove(TKey key)
        {
            //1.key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            //2.key값과 동일한 데이터를 찾을때까지 index 증가
            while (table[index].state == Entry.State.Using)
            {
                //3-1. 동일한 키값을 찾았을 때 지운상태로 표시
                if (key.Equals(table[index].key))
                {
                    table[index].state=Entry.State.Deleted;
                    return true;
                }
                if (table[index].state == Entry.State.None)
                {
                    break;
                }
                index = ++index % table.Length;
            }
            throw new InvalidOperationException();
        }
    }
}
