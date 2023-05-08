using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class JobScene : Scene
    {
        public JobScene(Game game) : base(game)
        {

        }
        
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

                
                switch (command)
                {
                        case 1:
                            Data.player.icon = Data.knight.Icon();
                    Data.player.playerjob = Data.knight;
                    Console.WriteLine("기사를 골랐습니다.");
                    Thread.Sleep(1000);
                    game.GameStart();
                    break;
                        case 2:
                           Data.player.icon= Data.archer.Icon();
                    Data.player.playerjob = Data.archer;
                    Console.WriteLine("궁수를 골랐습니다.");
                    Thread.Sleep(1000);
                    game.GameStart();
                    break;
                        case 3:
                           Data.player.icon=Data.Mage.Icon();
                    Data.player.playerjob = Data.Mage;
                    Console.WriteLine("마법사를 골랐습니다.");
                    Thread.Sleep(1000);
                    game.GameStart();
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
