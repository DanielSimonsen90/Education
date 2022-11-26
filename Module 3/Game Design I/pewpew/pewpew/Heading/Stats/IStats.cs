using pewpew.Characters;
using pewpew.Items;

namespace pewpew
{
    public interface IStats
    {
        //public IPlayer Player { get; set; }
        //public int PlayerHealth { get; protected set; }
        //public int PlayerDamage { get; protected set; }
        //public int BulletsShot { get; protected set; }

        //public int EnemiesKilled { get; protected set; }
        void OnEnemyKilled(IEnemy enemy);

        //public int HealthPacksPickedUp { get; protected set; }
        void OnHealthPackPickedUp(IPlayer hitBy, IHealthPack healthPack);
    }
}
