using System;
using System.Collections.Generic;
using System.Threading;

namespace pewpew.Characters
{
    public class Enemy : Character, IEnemy
    {
        public Enemy(int health, int damage) : base(health, damage) 
        {
            SpriteDirections.Add(Directions.LEFT, new Sprite(new List<List<char>>()
                {
                    new() { ' ', 'O', ' ' },
                    new() { '-', '|', ')' },
                    new() { '_', '|', ' ' }
                }));
            SpriteDirections.Add(Directions.RIGHT, new Sprite(new List<List<char>>()
                {
                    new() { ' ', 'O', ' ' },
                    new() { '(', '|', '-' },
                    new() { ' ', '|', '_' }
                }));
        }

        public int ShootTime { get; set; }
        public void ShootCheck()
        {
            _ = new Thread(() =>
              {
                  if (ShootTime >= new Random().Next(2, 5))
                  {
                      Shoot(CurrentDirection);
                      ShootTime = 0;
                  }

                  ShootTime++;
              });
        }
    }
}
