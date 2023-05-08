using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    internal class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 게임시작");
            sb.AppendLine("2. 게임종료");
            sb.Append("메뉴를 선택하세요 : ");
            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘 못 입력 하셨습니다.");
                Thread.Sleep(1000);//프로그램을 잠시 쉬게 해주는 명령어
                return;
            }

            switch (command)
            {
                case 1:
                    game.ChoseJob();
                    Thread.Sleep(1000);
                    // ToDO :게임 시작
                    break;
                case 2:
                    game.GameOver();
                    Thread.Sleep(1000);
                    //ToDo: 게임종료
                    break;
                default:
                    Console.WriteLine("잘 못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
