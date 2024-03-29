﻿namespace Stack
{
    internal class Program
    {
        /******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/
        static void Test()
        {
            Stack<int> stack = new Stack<int>();
            for(int i=0; i<10; i++)
            {
                stack.Push(i);          // 0 1 2 3 4 5 6 7 8 9
            }
            Console.WriteLine(stack.Peek());//최상단의 무엇인지를 확인하기 위한것
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}