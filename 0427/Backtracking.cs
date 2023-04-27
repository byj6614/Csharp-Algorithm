using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _0427
{
    class Class1
    {
        static StringBuilder sb = new StringBuilder();

        static int[] arr;
        static bool[] visit;
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());//반복할 횟수
            int count = int.Parse(Console.ReadLine());//열거할 길이

            arr = new int[count];//열거할 길이의 배열을 만들어준다.
            visit = new bool[num];//이미 쓴 숫자는 true로 만들어 사용했다는 것을 알린다.
            DFS(num, count, 0);
            Console.WriteLine(sb.ToString());

        }
        static void DFS(int a, int b, int dep)//dep은 깊이
        {
            if (dep == b)//깊이와 열거할 길이가 같은 경우 출력값을 저장해준다
            {
                foreach (int val in arr)
                {
                    sb.Append(val + " ");
                }
                sb.AppendLine();
                return;
            }
            for (int i = 0; i < a; i++)//반복할 횟수
            {
                if (!visit[i])
                {
                    arr[dep] = i + 1;

                    DFS(a, b, dep + 1);//제귀를 통해 값을 깊이를 증가해준다

                    visit[i] = false;
                }
            }
        }
    }
}