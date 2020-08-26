using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLIGE;

namespace DampCaves
{
    public class Damager : GameManager
    {
        public GameObject gameObject;
        public int damage;
        public int durability;
        public int lifeSpan;
        public int alignment;

        public Damager(int id, int direction, Entity source)
        {
            if (id == 0)
            {
                Vector sDir = source.gameObject.direction;
                Vector dir = new Vector(0, 0, 2);

                if (direction == 1) { dir.Update(sDir.r, sDir.c); }
                else if (direction == 2) 
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(1, -1); }
                        else { dir.Update(-1, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(1, 1); }
                        else { dir.Update(-1, -1); }
                    }
                }
                else if (direction == 3)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(1, 1); }
                        else { dir.Update(-1, -1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-1, 1); }
                        else { dir.Update(1, -1); }
                    }
                }
                else if (direction == 4)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(0, -1); }
                        else { dir.Update(0, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(1, 0); }
                        else { dir.Update(-1, 0); }
                    }
                }
                else if (direction == 5)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(0, 1); }
                        else { dir.Update(0, -1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-1, 0); }
                        else { dir.Update(1, 0); }
                    }
                }
                else if (direction == 6)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-1, -1); }
                        else { dir.Update(1, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(1, -1); }
                        else { dir.Update(-1, 1); }
                    }
                }
                else if (direction == 7)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-1, 1); }
                        else { dir.Update(1, -1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-1, -1); }
                        else { dir.Update(1, 1); }
                    }
                }
                else if (direction == 8)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-1, 0); }
                        else { dir.Update(1, 0); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(0, -1); }
                        else { dir.Update(0, 1); }
                    }
                }
                else if (direction == 9)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(2, -1, 1); }
                        else { dir.Update(-2, 1, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(1, 2, 1); }
                        else { dir.Update(-1, -2, 1); }
                    }
                }
                else if (direction == 10)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(2, 1, 1); }
                        else { dir.Update(-2, -1, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-1, 2, 1); }
                        else { dir.Update(1, -2, 1); }
                    }
                }
                else if (direction == 11)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(1, -2, 1); }
                        else { dir.Update(-1, 2, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(2, 1, 1); }
                        else { dir.Update(-2, -1, 1); }
                    }
                }
                else if (direction == 12)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(1, 2, 1); }
                        else { dir.Update(-1, -2, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-2, 1, 1); }
                        else { dir.Update(2, -1, 1); }
                    }
                }
                else if (direction == 13)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-1, -2, 1); }
                        else { dir.Update(1, 2, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(2, -1, 1); }
                        else { dir.Update(-2, 1, 1); }
                    }
                }
                else if (direction == 14)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-1, 2, 1); }
                        else { dir.Update(1, -2, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-2, -1, 1); }
                        else { dir.Update(2, 1, 1); }
                    }
                }
                else if (direction == 15)
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-2, -1, 1); }
                        else { dir.Update(2, 1, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(1, -2, 1); }
                        else { dir.Update(-1, 2, 1); }
                    }
                }
                else
                {
                    if (Math.Abs(sDir.r) > Math.Abs(sDir.c))
                    {
                        if (sDir.r > 0) { dir.Update(-2, 1, 1); }
                        else { dir.Update(2, -1, 1); }
                    }
                    else
                    {
                        if (sDir.c > 0) { dir.Update(-1, -2, 1); }
                        else { dir.Update(1, 2, 1); }
                    }
                }

                gameObject = new GameObject(2, new Position(source.gameObject.position.r + dir.r, source.gameObject.position.c + dir.c), "* ", 0, 15);
                gameObject.ChangeDirection(dir);
                lifeSpan = source.range * 2;
            }
            else
            {
                gameObject = new GameObject(3, source.gameObject.position, "/\\", 0, 8);
                lifeSpan = source.trail;
            }

            damage = source.damage;
            durability = source.piercing;
            alignment = source.alignment;
        }
    }
}
