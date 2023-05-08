using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
        }

        public override void Update()
        {
            
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up); break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down); break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right); break;
            }
            Monster monsterInPos = Data.MonsterInPos(Data.player.pos);
            if(monsterInPos != null)
            {
                game.BattleStart(monsterInPos);
                return;
            }
            foreach(Monster monster in Data.monsters)
            {
                monster.MoveAction();
                if (monster.pos.x == Data.player.pos.x &&
                    monster.pos.y == Data.player.pos.y)
                {
                    game.BattleStart(monster);
                    return;
                }
            }
            
        }
        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            for(int y=0;y<Data.map.GetLength(0);y++)
            {
                for (int x = 0; x < Data.map.GetLength(1);x++)
                {
                    if (Data.map[y, x])
                        sb.Append(' ');
                    else
                        sb.Append('■');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("직업 : {0}", Data.player.playerjob.jobNow);
            Console.WriteLine("체력 : {0}", Data.player.playerjob.hp);
            Console.WriteLine("마나 : {0}", Data.player.playerjob.mp);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach(Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.pos.x, monster.pos.y);
                Console.Write(monster.icon);
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x, Data.player.pos.y);
            Console.Write(Data.player.icon);
            Console.ResetColor();


            
        }
    }
}
