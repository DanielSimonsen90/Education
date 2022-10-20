using pewpew.Characters;
using pewpew.Items;

namespace pewpew
{
    public class Stats : IStats
    {
        public Player Player { get; protected set; } = new Player("Player");
        public int PlayerHealth => Player.Health;
        public int PlayerDamage => Player.Damage;
        public int BulletsShot => Player.BulletsShot;
        public int EnemiesKilled { get; protected set; } = 0;
        public int HealthPacksPickedUp { get; set; } = 0;

        public Stats(Player player)
        {
            Player = player;
            player.PlayerUpdate += (Player player) => Player = player;
        }

        public void OnEnemyKilled(IEnemy enemy) => EnemiesKilled++;
        public void OnHealthPackPickedUp(IPlayer hitBy, IHealthPack healthPack) => HealthPacksPickedUp++;
    }
}
