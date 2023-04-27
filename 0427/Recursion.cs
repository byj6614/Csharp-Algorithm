/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignTechnique
{
    internal class Program
    {
        public static void Move(StringBuilder sb, int count, int start, int end)
        {

            if (count == 0)
                return;
            int other = (6 - start - end);

            Move(sb, count - 1, start, other);
            sb.AppendFormat("{0} {1}\n", start, end);
            Move(sb, count - 1, other, end);
        }
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());

            double K = Math.Pow(2, N) - 1;
            Console.WriteLine(K);
            StringBuilder sb = new StringBuilder();
            Move(sb, N, 1, 3);
            Console.WriteLine(sb.ToString());
        }
    }
}*/