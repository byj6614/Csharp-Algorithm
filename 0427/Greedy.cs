using System;
using System.Collections;
class Greedy
{
    private static void Main()
    {
        string input = Console.ReadLine();
        string[] s;
        if (input.Contains("-"))    //-가 있으면
        {
            s = input.Split('-');//s 문자 배열에 분할
            int[] my = new int[s.Length];//s의 길이만큼 int 배열생성
            for (int i = 0; i < s.Length; i++)//-분할 된 배열을 수색
            {
                if (s[i].Contains("+"))//배열중 +가 포함된 문자열이 있을경우
                {
                    string[] temp = s[i].Split('+');//+가 를 분할하고
                    int sum = 0;
                    for (int j = 0; j < temp.Length; j++)//분할한 숫자를 더해준다.
                    {
                        sum += int.Parse(temp[j]);
                    }
                    my[i] = sum;//int 배열에 더해준 값을 넣어준다.
                }
                else
                {
                    my[i] = int.Parse(s[i]);//+문자가 없으면 int형으로 바꾸고 넣어준다.
                }
            }
            int result2 = 0;//총 결과값
            for (int i = 1; i < my.Length; i++)
            {
                result2 -= my[i];//최솟 값을 구하기 위해 +수식을 ()안에 넣어 계산한걸로 생각하여 그값을 -로 바꿔준다
            }
            Console.WriteLine(result2 + my[0]);//가장 앞에 있는 값을 -해준다
        }
        else
        {
            s = input.Split('+');//-수식이 없다면 +만 하면된다.
            int result = 0;
            foreach (string a in s)//분할 한 값을 모두 더해준다.
            {
                result += int.Parse(a);
            }
            Console.WriteLine(result);
        }
    }
}