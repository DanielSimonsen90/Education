using pewpew.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pewpew
{
    public class Wave
    {
        public int WaveCount { get; protected set; } = 0;
        protected int EnemyCount { get; set; }
        protected Range Health { get; set; }
        protected Range Damage { get; set; }


        public Wave(int enemyCount, int minHealth, int maxHealth, int minDamage, int maxDamage)
        {
            EnemyCount = enemyCount;
            Health = new Range(minHealth, maxHealth);
            Damage = new Range(minDamage, maxDamage);
        }

        public List<Enemy> Next(Game game)
        {
            var enemies = new List<Enemy>();

            for (int i = 0; i < EnemyCount; i++)
            {
                var enemy = new Enemy(Health.Value, Damage.Value);
                enemy.HealthUpdate += (ICharacter character, int health) => game.OnEnemyHealthUpdated(character as IEnemy, health);
                enemy.DamageUpdate += (ICharacter character, int damage) => game.OnEnemyDamageUpdated(character as IEnemy, damage);
                enemy.Move += (ICharacter character, Directions direction) => game.OnEnemyMoved(character as IEnemy, direction);
                enemy.Death += (ICharacter character) => game.OnEnemyDeath(character as IEnemy);

                enemies.Add(enemy);
            }

            WaveCount++;
            EnemyCount++;
            Health = new Range(Health.Minimum + 1, Health.Maximum + 1);
            Damage = new Range(Damage.Minimum + 1, Damage.Maximum + 1);

            return enemies;
        }
    }
}
