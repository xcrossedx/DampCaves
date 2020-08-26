using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLIGE;

namespace DampCaves
{
    public class GameManager
    {
        public static int gameState = 0;

        public static Random rng;

        public static HUD hud;

        public static Entity player;
        public static Entity[] enemies;
        public static PowerUp[] powerUps;
        public static Damager[] damagers;

        public static void Init()
        {
            Game.Init(1000, 1000, 5);
            GameLoop();
        }

        private static void GameLoop()
        {
            while(gameState != -1)
            {
                if (gameState == 1)
                {
                    Game.Update(1);
                    Window.HUDUpdate();
                    Window.Update();
                }

                if (Console.KeyAvailable)
                {
                    if (gameState == 0)
                    {

                    }

                    ConsoleKey input = Console.ReadKey(true).Key;
                }
            }
        }
    }
}
