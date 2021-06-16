using pewpew.Items;
using System.Collections.Generic;

namespace pewpew.Characters
{
    public class Player : Character, IPlayer
    {
        public string Name { get; }
        public int BulletsShot { get; set; }

        public Player(string name) : base(health: 100, damage: 10)
        {
            Name = name;
            BulletsShot = 0;

            HealthUpdate += (ICharacter character, int health) => TestCharacterUpdate(character);
            DamageUpdate += (ICharacter character, int damage) => TestCharacterUpdate(character);

            CurrentDirection = Directions.RIGHT;
            SpriteDirections.Add(Directions.RIGHT, new(new List<List<char>>()
            {
                new() { ' ', 'o', ' '  },
                new() { '<', '|', '-'  },
                new() { '/', ' ', '\\' }
            }));
            SpriteDirections.Add(Directions.LEFT, new(new List<List<char>>()
            {
                new() { ' ', 'o', ' '  },
                new() { '-', '|', '>'  },
                new() { '/', ' ', '\\' }
            }));
            SpriteDirections.Add(Directions.JUMP, new(new List<List<char>>()
            {
                new() { '\\', 'o', '/' },
                new() { ' ', '|', ' '  },
                new() { '(', ' ', ')'  }
            }));
        }

        public override Bullet Shoot(Directions direction)
        {
            Bullet bullet = base.Shoot(direction);
            BulletsShot++;
            PlayerUpdate.Invoke(this);
            
            return bullet;
        }
        protected override int OnShot(int damage)
        {
            var result = base.OnShot(damage);
            PlayerUpdate.Invoke(this);
            return result;
        }

        public delegate void PlayerUpdateHandler(Player player);
        public event PlayerUpdateHandler PlayerUpdate;
        private void TestCharacterUpdate(ICharacter character)
        {
            if (character == this)
                PlayerUpdate.Invoke(this);
        }
    }
}
