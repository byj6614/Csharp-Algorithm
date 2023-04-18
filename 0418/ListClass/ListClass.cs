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
        
    }
}
