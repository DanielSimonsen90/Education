using pewpew.Items;
using System;
using System.Collections.Generic;

namespace pewpew.Characters
{
    public class Enemy : Character, IEnemy
    {
        private static readonly object Lock = new();

        public Enemy(int health, int damage, IPlayer player) : base(health, damage)
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
            CurrentDirection = player.CurrentDirection == Directions.RIGHT ? Directions.LEFT : Directions.RIGHT;
        }

        public int ShootTime { get; set; }
        public Bullet ShootCheck()
        {
            Bullet bullet = null;

            if (ShootTime >= new Random().Next(2, 5))
            {
                bullet = Shoot(CurrentDirection);
                ShootTime = 0;
            }

            ShootTime++;

            return bullet;
        }
    }
}
