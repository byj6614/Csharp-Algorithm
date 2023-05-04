using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public static class Data
    {
        
        public static bool[,] map;
        public static Player player;
        public static List<Monster> monsters;
        public static void Release()
        {

        }
        public static void Init()
        {
            player = new Player();
        }

        public static void LoadLevel()
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };
            player.pos =new Position(2, 2);

           // Monster slime1 = new Slime();

            //slime1.pos = new Position(3, 5);
            //monsters.Add(slime1);
        }
        /*public static Monster MonsterInPos(Position pos)
        {
            Monster monster=monsters.Find(tartget => tartget.pos.x == pos.x && tartget.pos.y == pos.y);
            return monster;

        }*/

     
        
    }

    
}
