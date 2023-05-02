using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class Search
    {
        // <순차 탐색>
        //전부 탐색하여 찾는 값이 있다면 출력하고 없다면 -1을 내보내준다.
        //어떤 자료구조던 순차 탐색이 가능하다
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }

        // <이진 탐색>
        //이진 탐색은 데이터들이 모두 정렬 되있을 경우에만 가능한 탐색 방법이다
        //데이터를 찾고자 하는 공간에 중간값을 지정하여 찾는 값보다 크고 작은걸 따져 크다면 중간값보다 더 큰값을 작다면
        //더 작은 값을 무시하고 찾는다.
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {                                //in : 입력 매개변수//out : 출력 전용 매개변수
            int low = 0;
            int high = list.Count - 1;

            while(low<=high)
            {
                int middle = (low + high) / 2;
                //int middel = (int)((low + high) * 0.5f);//나누기 보다는 곱이 더 빠르기 때문에 0.5로 나누기 2를 대신한다
                int compare = list[middle].CompareTo(item);

                if (compare < 0)//비교후 더 작다면 low에 middle+1을 넣어준다.
                    low = middle + 1;
                else if (compare > 0)//비교후 더 크다면 high에 middle-1을 넣어준다
                    high = middle - 1;
                else
                    return compare;
            }
            return -1;//비교하면서 low와 high가 엇갈려 넘어갔다면 찾는 탐색이 없다는 뜻이므로 -1을 내보낸다.
        }


    }
}
