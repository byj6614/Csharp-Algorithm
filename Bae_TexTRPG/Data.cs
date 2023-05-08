using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public static class Data
    {
        public static bool[,] map;
        public static Job archer=new Archer();
        public static Job knight = new Knight();
        public static Job Mage = new Mage();
        public static Player player;
        public static int levelCount = 0;
        public static List<Monster> monsters=new List<Monster>();
        
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
                {false,false,false,false,false,false,false,false},
                {false,true,true,false,true,true,true,false},
                {false,true,true,false,true,true,true,false },
                {false,true,true,false,true,false,false,false },
                {false,false,true,true,true,true,true,false },
                {false,true,true,true,true,true,true,false },
                {false,true,true,false,true,true,true,false },
                {false,false,false,false,false,false,false,false }
            };
            player.pos = new Position(1, 1);

           Monster slime1 = new Slime();
           Monster skeleton=new Skeleton();
           slime1.pos = new Position(2, 2);
           monsters.Add(slime1);
           skeleton.pos= new Position(6, 6);
           monsters.Add(skeleton);
        }
        public static void LoadLeve2()
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
            player.pos = new Position(1, 1);

            Monster slime1 = new Slime();
            Monster slime2= new Slime();
            Monster skeleton1=new Skeleton();
            Monster skeleton2 = new Skeleton();
            slime1.pos = new Position(2, 2);
            monsters.Add(slime1);
            slime2.pos = new Position(1, 14);
            monsters.Add(slime2);
            skeleton1.pos = new Position(6, 6);
            monsters.Add(skeleton1);
            skeleton2.pos = new Position(13,14);
            monsters.Add(skeleton2);
        }
        public static Monster MonsterInPos(Position pos)
        {
            Monster monster = monsters.Find(tartget => tartget.pos.x == pos.x && tartget.pos.y == pos.y);
            return monster;

        }
    }
}
