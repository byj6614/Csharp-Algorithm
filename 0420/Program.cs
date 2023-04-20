using System.Collections.Immutable;

namespace _0420
{
    internal class Program
    {
        /*
         * 1.List,LinkedList IEnumberable 구현
         * 2.foreach에 List,LinkedList 반복 확인
         */
        static void Main(string[] args)
        {
            ABC.List<int> list = new ABC.List<int>();
            ABC.LinkedList<int> linkedList = new ABC.LinkedList<int>();
            for (int i = 1; i <= 5; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            foreach (int i in linkedList)
            {
                Console.WriteLine(i);
            }

        }
        
        public static double Average(ICollection<int> container)
        {
            double sum = 0;
            int count = 0;
            foreach(int item in container)
            {
                count++;
                sum += item;
            }
            return sum/count;
        }
    }
}