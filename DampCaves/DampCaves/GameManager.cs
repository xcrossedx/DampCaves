using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLIGE;
using System.Diagnostics;

namespace DampCaves
{
    public class GameManager
    {
        public static int gameState;
        public static int score;

        public static Random rng;

        public static HUD hud;

        public static Entity player;
        public static List<Entity> enemies;
        public static List<PowerUp> powerUps;
        public static List<Damager> damagers;

        public static void Init()
        {
            Game.Init(1000, 1000, 5);
            GameLoop();
        }

        public static void Reset()
        {
            Game.Reset();
            gameState = 1;
            score = 0;
            player = new Entity(0);
            enemies = new List<Entity>();
            powerUps = new List<PowerUp>();
            damagers = new List<Damager>();
            hud = new HUD($"Health: {player.health}", $"PowerUps: () x{player.powerUpCounter[0]}  oo x{player.powerUpCounter[1]}  || x{player.powerUpCounter[2]}  <> x{player.powerUpCounter[3]}  ^^ x{player.powerUpCounter[4]}  {{}} x{player.powerUpCounter[5]}", $"Score: {score}");
        }

        private static void GameLoop()
        {
            while(gameState != -1)
            {
                if (gameState == 1)
                {
                    PlayerUpdate();
                    EnemiesUpdate();
                    BulletsUpdate();
                    Game.Update(3);
                    Window.HUDUpdate(hud);
                    Window.Update();
                }

                if (Console.KeyAvailable)
                {
                    if (gameState == 0)
                    {
                        Reset();
                    }

                    ConsoleKey input = Console.ReadKey(true).Key;
                    if (gameState == 2) { gameState = 1; }
                    else if (input == ConsoleKey.Escape)
                    {
                        if (gameState == 0) { gameState = -1; }
                        else if (gameState == 1) { gameState = 2; }
                    }
                    else if (input == ConsoleKey.Spacebar) { player.Fire(); }
                    else { player.gameObject.ChangeDirection(input); }
                }
            }
        }

        private static void PlayerUpdate()
        {
            if (player.gameObject.movementDelay.Check() && player.gameObject.direction.v > 0)
            {
                if (player.trail > 0) { damagers.Add(new Damager(1, 0, player)); }
                player.gameObject.Move();
            }
        }

        private static void EnemiesUpdate()
        {

        }

        private static void BulletsUpdate()
        {
            List<int> removeIndexes = new List<int>();

            for (int d = 0; d < damagers.Count(); d++)
            {
                Damager damager = damagers[d];

                int v = damager.gameObject.direction.v;
                if (v == 0) { v = 1; }

                if (damager.gameObject.movementDelay.Check(v))
                {
                    if (damager.lifeSpan > 0)
                    {
                        if (damager.gameObject.direction.v == 1) { damager.lifeSpan -= 2; }
                        else { damager.lifeSpan -= 1; }

                        if (damager.gameObject.direction.v > 0)
                        {
                            if (!damager.gameObject.Move()) { removeIndexes.Add(d); }
                        }
                    }
                    else
                    {
                        removeIndexes.Add(d);
                    }
                }
            }

            removeIndexes.Sort();
            removeIndexes.Reverse();

            foreach (int i in removeIndexes)
            {
                damagers[i].gameObject.Delete();
                damagers.RemoveAt(i);
            }
        }

        public static void Log(string log)
        {
            Debug.WriteLine(log);
        }
    }
}
