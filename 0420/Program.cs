﻿namespace _0420
{
    internal class Program
    {
        /*
         * 1.List,LinkedList IEnumberable 구현
         * 2.foreach에 List,LinkedList 반복 확인
         */
        static void Main(string[] args)
        {
            ABC.List<int> list=new ABC.List<int>();
            for(int i=1;i<=5;i++)
            {
                list.Add(i);
            }
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}