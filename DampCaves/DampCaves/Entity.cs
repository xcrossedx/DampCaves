using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLIGE;

namespace DampCaves
{
    public class Entity : GameManager
    {
        public GameObject gameObject;

        public int health = 10;

        public int damage = 1;
        public int range = 10;
        public int spread = 1;
        public int fireRate = 0;
        public int piercing = 0;
        public int trail = 0;

        public int[] powerUpCounter = new int[6];

        public Entity(int id)
        {
            if (id == 0)
            {
                gameObject = new GameObject(0, new Position("center"), "  ", 7, 0);
            }
            else
            {
                Position pos = new Position(rng.Next(Window._position.r, Window._position.r + Window._height), rng.Next(Window._position.c, Window._position.c + Window._width));
                while(Game.grid[pos.r][pos.c] != 0) { pos = new Position(rng.Next(Window._position.r, Window._position.r + Window._height), rng.Next(Window._position.c, Window._position.c + Window._width)); }

                gameObject = new GameObject(1, pos, "  ", 4, 0);

                health = 1;
            }
        }

        public void AddPowerUp(int id)
        {
            powerUpCounter[id] += 1;

            if (id == 0)
            {
                if (health < 10)
                {
                    health += 1;
                    Window.bulletins.Add(new Bulletin("+1", "()", "Your health is restored by 1 point!", 6));
                }
                else
                {
                    Window.bulletins.Add(new Bulletin("+1", "()", "But your health is already full!", 6));
                }
            }
            else if (id == 1)
            {
                if (range < 20)
                {
                    range += 2;
                    Window.bulletins.Add(new Bulletin("+1", "oo", "Your range is increased by 2 spaces!", 6));
                }
                else
                {
                    Window.bulletins.Add(new Bulletin("+1", "oo", "But your range is already maxed out!", 6));
                }
            }
            else if (id == 2)
            {
                if (fireRate < 5)
                {
                    fireRate += 1;
                    Window.bulletins.Add(new Bulletin("+1", "||", "Your fire rate is increased by 1 tenth of a second!", 2));
                }
                else
                {
                    Window.bulletins.Add(new Bulletin("+1", "||", "But your fire rate is already maxed out!", 2));
                }
            }
            else if (id == 3)
            {
                if (piercing < 5)
                {
                    piercing += 1;
                    Window.bulletins.Add(new Bulletin("+1", "<>", "Your piercing is increased by 1 point!", 2));
                }
                else
                {
                    Window.bulletins.Add(new Bulletin("+1", "<>", "But your piercing is already maxed out!", 2));
                }
            }
            else if (id == 4)
            {
                if (trail < 10)
                {
                    trail += 2;
                    Window.bulletins.Add(new Bulletin("+1", "^^", "Your trail length is increased by 2 spaces!", 5));
                }
                else
                {
                    Window.bulletins.Add(new Bulletin("+1", "^^", "But your trail length is already maxed out!", 5));
                }
            }
            else if (id == 5)
            {
                if (spread < 7)
                {
                    spread += 2;
                    Window.bulletins.Add(new Bulletin("+1", "{}", "Your spread is increased by 2 bullets!", 5));
                }
                else if (spread < 16)
                {
                    spread += 1;
                    Window.bulletins.Add(new Bulletin("+1", "{}", "Your spread is increased by 1 bullet!", 5));
                }
                else
                {
                    Window.bulletins.Add(new Bulletin("+1", "{}", "But your spread is already maxed out!", 5));
                }
            }
        }

        public void AddPowerUps(int[] ids)
        {
            for (int p = 0; p < 6; p++)
            {
                powerUpCounter[p] += ids[p];
            }

            health += ids[0];
            if (health > 10) { health = 10; }

            range += ids[1];
            if (range > 20) { range = 20; }

            fireRate += ids[2];
            if (fireRate > 5) { fireRate = 5; }

            piercing += ids[3];
            if (piercing > 5) { piercing = 5; }

            trail += ids[4];
            if (trail > 10) { trail = 10; }

            for (int s = 0; s < ids[5]; s++)
            {
                if (spread < 7)
                {
                    spread += 2;
                }
                else
                {
                    spread += 1;
                }
            }
            if (spread > 16) { spread = 16; }
        }
    }
}
