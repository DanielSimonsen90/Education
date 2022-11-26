using pewpew.Characters;
using System.Collections.Generic;

namespace pewpew
{
    public class EnemyCollection : List<Enemy>
    {
        public EnemyCollection AddAndDraw(Enemy enemy, int topX)
        {
            base.Add(enemy);
            ListAdd.Invoke(enemy, topX);
            return this;
        }
        public EnemyCollection RemoveAndErase(Enemy enemy)
        {
            base.Remove(enemy);
            ListRemove.Invoke(enemy);
            return this;
        }

        public delegate void AddHandler(Enemy enemy, int topX);
        public delegate void RemoveHandler(Enemy enemy);
        public event AddHandler ListAdd;
        public event RemoveHandler ListRemove;
    }
}
