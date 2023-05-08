using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bae_TexTRPG
{
    public class Game
    {
        private bool running = true; //게임구동과 끝낼때를 나눔

        private Scene curScene;
        private MapScene mapScene;
        private JobScene jobScene;
        private MainMenuScene mainMenuScene;
        private BattleScene battleScene;    
        public void Run()
        {
            Init();
            while(running)
            {
                Render();
                Update();
            }
            Release();
        }
        public void Init()//초기화
        {
            Console.Clear();
            Data.Init();
            mapScene=new MapScene(this);
            jobScene = new JobScene(this);
            mainMenuScene = new MainMenuScene(this);
            battleScene = new BattleScene(this);
            curScene = mainMenuScene;
        }
        public void Map()
        {
            curScene=mapScene;
        }
        public void ChoseJob()
        {
            curScene = jobScene;
        }
        public void GameStart()
        {
            switch(Data.levelCount)
            {
                case 0:
                    Data.LoadLevel();
                    curScene = mapScene;
                    break;
                case 1:
                    Data.LoadLeve2();
                    curScene = mapScene;
                    break;
                    case 2:
                    Console.WriteLine("YOUR CHAMPION");
                    running = false;
                    break;
            }
            
        }
        public void GameOver()
        {
            Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀\r\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼\r\n██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀\r\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼\r\n███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼\r\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼\r\n██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            Thread.Sleep(1000);
            
            running = false;
        }
        public void BattleStart(Monster monster)
        {
            curScene=battleScene;
            battleScene.BattleStart(monster);
        }
        public void BattleEnde()
        {

        }
        public void Render()//랜더링
        {
            Console.Clear();
            curScene.Render();
        }
        public void Update()//업데이트
        {
            curScene.Update();
        }
        public void Release()//마무리
        {
            Data.Release();
        }
    }
}
