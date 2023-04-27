using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427
{
    
    internal class DivideAndConquer
    {
    
        static int blue = 0;
        static int white = 0;
        static int[][] paper;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            paper = new int[n][];
            for (int i = 0; i < n; i++)
                paper[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            find_color(0, 0, n);
            Console.WriteLine(white);
            Console.WriteLine(blue);
        }

        static void find_color(int x, int y, int n) //x 위아래, y 왼오
        {
            if (n < 1)
                return;

            bool isblue = true;
            bool iswhite = true;
            //Console.WriteLine($"x {x}부터 {x+n}, y {y}부터{y+n}까지");
            for(int i = x; i< x + n; i++)
            {
                for(int j = y; j<y + n; j++)
                {
                    if (paper[i][j] == 1)
                        iswhite = false;
                    else
                        isblue = false;
                }
            }

            if (isblue)
            {
                blue++;
                //Console.WriteLine($"x{x}부터 {x+n}, y{y}부터{y+n}까지 blue");
            }
            else if (iswhite)
            {
                white++;
                //Console.WriteLine($"x{x}부터 {x + n}, y{y}부터{y + n}까지 white");
            }
            else
            {
                n /= 2;
                find_color(x, y, n); // 좌측 상
                find_color(x, y + n, n); // 우측 상
                find_color(x + n, y, n); // 좌측 하
                find_color(x + n , y + n, n); // 우측 하
            }
        }
    }
}
