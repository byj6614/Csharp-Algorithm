﻿namespace Queue
{
    internal class Program
    {
        /******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

        static void Test()
        {
            Queue<int> queue= new Queue<int>();
            for(int i=0;i<10; i++) queue.Enqueue(i); //0 1 2 3 4 5 6 7 8 9 

            Console.WriteLine(queue.Peek());        //최전방에 있는 데이터 확인
            while(queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}