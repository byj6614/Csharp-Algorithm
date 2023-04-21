using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0421.addition.Stack
{
    internal class bracket
    {
        
        public void Breacket(Stack<char> chars)
        {
            char[] abc= chars.ToArray();
            int a=0;
            for(int i=0;i<abc.Length;i++)
            {
                if (abc[i] == '(')
                    a++;
                else if (abc[i] == ')')
                    a--;
            }
            if(a==0)
            {
                Console.WriteLine("정답");
            }
            else
            {
                Console.WriteLine("오답");
            }
        }
    }
}
