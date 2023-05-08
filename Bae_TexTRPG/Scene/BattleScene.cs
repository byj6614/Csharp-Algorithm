using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    internal class BattleScene : Scene
    {
        private Monster monster;
        public BattleScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            Console.WriteLine($"{monster.name}    {monster.hp}");
            Console.WriteLine();
            Console.WriteLine($"{monster.image}");
            Console.WriteLine();
            Console.WriteLine($"{Data.player.playerjob.jobNow}의 체력 : {Data.player.playerjob.hp}");
            Console.WriteLine($"{Data.player.playerjob.jobNow}의 마나 : {Data.player.playerjob.mp}");


        }

        public override void Update()
        {
            Console.WriteLine("행동을 선택하세요");
            Console.WriteLine("[1] 공격하기");
            Console.WriteLine("[2] 스킬");
            Console.WriteLine("[3] 도망가기");
            string input=Console.ReadLine();
            int key;
            
            int monsterAp = monster.ap - Data.player.playerjob.dp;
            int playerAp= Data.player.playerjob.ad - monster.dp;
            if(!int.TryParse(input, out key))
            {
                Console.WriteLine("잘못 입력했습니다.");
                Thread.Sleep(1000);
                return;
            }
            else if(key<1||key>3)
            {
                Console.WriteLine("잘못 입력했습니다.");
                Thread.Sleep(1000);
                return;
            }
            else if(key==2)
            {
                
                Data.player.playerjob.Skill();
                int sp = Data.player.playerjob.sp - monster.dp;
                Console.WriteLine("몬스터의 공격!!!!");
                Thread.Sleep(1000);
                if (Data.player.playerjob.dp < monster.ap)
                {

                    Data.player.playerjob.hp -= monsterAp;
                    Console.WriteLine("데미지 {0} 를 받았습니다.", monsterAp);
                    Thread.Sleep(1000);
                    if (Data.player.playerjob.hp <= 0)
                    {
                        game.GameOver();
                        return;
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    Data.player.playerjob.hp -= 1;
                    Console.WriteLine("데미지 1를 받았습니다.");
                    Thread.Sleep(1000);
                    if (Data.player.playerjob.hp <= 0)
                    {
                        game.GameOver();
                        return;
                    }
                    Thread.Sleep(1000);
                }
                Console.WriteLine($"플레이어의 {Data.player.playerjob.skname} 발동!!!!!");
                Thread.Sleep(1000);
                if(Data.player.playerjob.sp > monster.dp)
                {
                    monster.hp -= sp;
                    Console.WriteLine("데미지 {0}를 입혔다!!!", sp);
                    Thread.Sleep(1000);
                    if (monster.hp <= 0)
                    {
                        Data.monsters.Remove(monster);
                        Console.WriteLine($"{monster.name}을 쓰러뜨렸다.!!!");
                        Thread.Sleep(1000);
                        if (Data.monsters.Count == 0)
                        {
                            Data.levelCount++;
                            Console.Clear();
                            Console.WriteLine("스테이지 클리어!!!!");
                            Thread.Sleep(1000);
                            game.GameStart();
                        }
                        game.Map();
                    }
                }
                else
                {
                    monster.hp -= 1;
                    Console.WriteLine("데미지 1을 주었습니다.");
                    Thread.Sleep(1000);
                    if (monster.hp <= 0)
                    {
                        Data.monsters.Remove(monster);
                        Console.WriteLine($"{monster.name}을 쓰러뜨렸다.!!!");
                        Thread.Sleep(1000);
                        if (Data.monsters.Count == 0)
                        {
                            Data.levelCount++;
                            Console.Clear();
                            Console.WriteLine("스테이지 클리어!!!!");
                            Thread.Sleep(1000);
                            game.GameStart();
                        }
                        game.Map();
                    }
                }
            }
            else if(key==1)
            {
                Console.WriteLine("몬스터의 공격!!!!");
                Thread.Sleep(1000);
                if (Data.player.playerjob.dp < monster.ap)
                {
                    
                    Data.player.playerjob.hp -= monsterAp;
                    Console.WriteLine("데미지 {0} 를 받았습니다.", monsterAp);
                    Thread.Sleep(1000);
                    if (Data.player.playerjob.hp <= 0)
                    {
                        game.GameOver();
                        return;
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    Data.player.playerjob.hp -= 1;
                    Console.WriteLine("데미지 1를 받았습니다.");
                    Thread.Sleep(1000);
                    if (Data.player.playerjob.hp <= 0)
                    {
                        game.GameOver();
                        return;
                    }
                    Thread.Sleep(1000);
                }
                
                Console.WriteLine("플레이어의 공격!!!!");
                Thread.Sleep(1000);
                
                if (Data.player.playerjob.ad>monster.dp)
                {
                    monster.hp -= playerAp;
                    Console.WriteLine("데미지 {0}를 주었습니다.", playerAp);
                    Thread.Sleep(1000);
                    if (monster.hp <= 0)
                    {
                        Data.monsters.Remove(monster);
                        Console.WriteLine($"{monster.name}을 쓰러뜨렸다.!!!");
                        Thread.Sleep(1000);
                        if (Data.monsters.Count == 0)
                        {
                            Data.levelCount++;
                            Console.Clear();
                            Console.WriteLine("스테이지 클리어!!!!");
                            Thread.Sleep(1000);
                            game.GameStart();
                        }
                        game.Map();
                    }
                }
                else
                {
                    monster.hp -= 1;
                    Console.WriteLine("데미지 1을 주었습니다.");
                    Thread.Sleep(1000);
                    if (monster.hp <= 0)
                    {
                        Data.monsters.Remove(monster);
                        Console.WriteLine($"{monster.name}을 쓰러뜨렸다.!!!");
                        Thread.Sleep(1000);
                        if (Data.monsters.Count == 0)
                        {
                            Data.levelCount++;
                            Console.Clear();
                            Console.WriteLine("스테이지 클리어!!!!");
                            Thread.Sleep(1000);
                            game.GameStart();
                        }
                        game.Map();
                    }
                }
            }
            else if(key==3)
            {
                Console.WriteLine("당신은 다음 기회를 노립니다.");
                Thread.Sleep(1000);
                game.Map();
            }
        }
        public void BattleStart(Monster monster)
        {
            this.monster = monster;
            

            Console.Clear();
            Console.WriteLine("{0} 과 전투",monster.name);
            Thread.Sleep(1000);
        }
    }
}
      