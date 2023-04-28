using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427
{
    internal class DynamicProgramming
    {
        static int[,] triangle;
 
    static void Cal(int n)
    {
        
        for (int i = 1; i < n; i++)
        {
            for(int j = 0; j <= i; j++)
            {
                if (j == 0)
                {
                    triangle[i, j] = triangle[i - 1, j] + triangle[i, j];
                }
                else if (j == i)
                {
                    triangle[i, j] = triangle[i - 1, j-1] + triangle[i, j];
                }
                else
                {
                    triangle[i, j] = Math.Max(triangle[i - 1, j - 1], triangle[i - 1, j]) + triangle[i, j];
                }
                    
            }
        }
        
        
    }
 
    static int max(int n)
    {
        int max_score = 0;
        for(int i = 0; i < n; i++)
        {
            max_score = Math.Max(triangle[n-1, i], max_score);
        }
        return max_score;
    }
 
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        int n = int.Parse(Console.ReadLine());  //삼각형의 크기
        triangle = new int[n, n];//삼각형 배열 크기 정하기
        for (int i = 0; i < n; i++) //삼각형 배열의 값넣기
        {
            var num = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for(int j = 0; j < num.Length; j++)
            {
                triangle[i, j] = num[j];
            }
        }
        Cal(n);
    } 
    }
}
