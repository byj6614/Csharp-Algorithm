using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG.Scene
{
    public class Job : Scene
    {
        public Job(Game game) : base(game)
        {

        }
        public enum Myclass { None, Knight, Archer, Mage }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("직업을 선택하시오");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
        }

        public override void Update()
        {
            
          
                string input = Console.ReadLine();
                int command;
                if (!int.TryParse(input, out command))
                {
                    Console.WriteLine("잘 못 입력 하셨습니다.");
                    Console.WriteLine("다시 입력하세요");
                    Thread.Sleep(1000);//프로그램을 잠시 쉬게 해주는 명령어
                    return;
                }

                Myclass choice = Myclass.None;
                switch (command)
                {
                    case 1:
                            choice = Myclass.Knight;
                            break;
                        case 2:
                            choice = Myclass.Archer;
                            break;
                        case 3:
                            choice = Myclass.Mage;
                            break;
                        default:
                            Console.WriteLine("없는 직업입니다.");
                            Console.WriteLine("다시 정하세요");
                            Thread.Sleep(1000);
                    return;

                }

        }
    }
}
