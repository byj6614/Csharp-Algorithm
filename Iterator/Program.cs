using System.ComponentModel;

namespace Iterator
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 ******************************************************/
        //처음부터 끝까지 하나하나 찾아봤을 때 있는지 확인해보기
        //
        void Main(string[] args)
        {
            //대부분의 자료구조가 반복기를 지원        //(없는것도 있음)
            //반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            List<int> list = new List<int>();                              
            LinkedList<int> linkedList = new LinkedList<int>();            
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복            
            // 즉, 반복기가 있다면 foreach 반복문으로 순회 가능 
            foreach (int i in list) { }
            foreach (int i in linkedList) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            foreach (int i in IterFunc()) { }


            // 반복기 직접조작
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) strings.Add($"{i}데이터");

            IEnumerator<string> iter = strings.GetEnumerator(); //GetEnumerator()반복기를 주는것
            iter.MoveNext();            //다음으로 가는것
            Console.WriteLine(iter.Current);    // output : 0데이터
            iter.MoveNext();            
            Console.WriteLine(iter.Current);    // output : 1데이터           
            //반복기는 하나하나 꺼내서 MoveNext()로 이동하고 current로 꺼낸다
            //다음값으로 이동 : MoveNext()
            //현재값을 꺼내는것 :current
            //처음으로 가는것 :Reset()
            iter.Reset();//Reset() 무조건 처음으로 가는것
            while(iter.MoveNext())//MoveNext가 false면 다음 값이 없다는 뜻이다
            {
                
                Console.WriteLine(iter.Current);
            }
        }
        IEnumerable<int> IterFunc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}