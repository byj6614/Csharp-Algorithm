using Project_TextRPG.Scean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Game
    {
        private bool running = true;

        private Scene curScene;
        private MainMenuScene mainmenuScene;
        private MapScene mapScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;
        public void Run()
        {
            //초기화
            Init();
            //게임 루프
            while(running)
            {
                //표현
                Render();
                //갱신
                Update();
            }

            //마무리 작업
            Release();
        }
        private void Init()
        {
            Console.Clear();
            Data.Init();
            mainmenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            curScene = mainmenuScene;
        }

        public void GameStart()
        {
            Data.LoadLevel();
            curScene = mapScene;
        }

        public void GameOver()
        {
            running = false;
        }
        public void BattleStart(Monster monster)
        {
            curScene = battleScene;
            battleScene.BattleStart(monster);
        }
        private void Render() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            curScene.Render();
        }
       
        private void Update()
        {
            curScene.Update();
        }

        private void Release()
        {
            Data.Release();
        }
    }
}
