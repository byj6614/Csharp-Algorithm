using _0421.addition.Stack;

namespace _0421
{
    internal class Program
    {
        static void Test1()     //괄호 계산기
        {
            Stack<char> stack = new Stack<char>();
            bracket bracket = new bracket();
            stack.Push('(');
            stack.Push(')');
            stack.Push('(');
            stack.Push('(');
            stack.Push(')');
            stack.Push(')');
            bracket.Breacket(stack);
        }
        static void Main(string[] args)
        {
           Test1();
        }
    }
}