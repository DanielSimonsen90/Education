using pewpew.Characters;
using pewpew.Items;
using System.Collections.Generic;

namespace pewpew
{
    public class Map : IMap
    {
        public string Name { get; set; } = "My Map";
        public int ObsticleCount { get; set; } = 0;
        public EnemyCollection Enemies { get; protected set; }

        protected Dictionary<IPositionMe, Hitbox> Positions { get; set; }
        protected GameConsole GamingConsole { get; }
        protected Floor Floor { get; }

        private static readonly object Lock = new();

        public Map(Player player, GameConsole console)
        {
            Positions = new Dictionary<IPositionMe, Hitbox>();
            Enemies = new EnemyCollection();
            Enemies.ListAdd += OnEnemiesAdded;
            Enemies.ListRemove += OnEnemiesRemoved;

            GamingConsole = console;
            Floor = new Floor(
                console.BottomRight.X - 1 +
                console.BottomLeft.X - 1
            );

            player.Death += (ICharacter character) => OnPlayerDead(character as Player);

            Draw(Floor, console.BottomLeft.X, console.BottomLeft.Y + 3);
            Draw(player, 0);
        }
        public Map(string name, int obsticles, Player player, GameConsole console) : this(player, console)
        {
            Name = name;
            ObsticleCount = obsticles;
        }

        #region Drawing
        public virtual void MoveIPosition<IPosition>(IPosition item, Directions directionType, int direction) where IPosition : IPositionMe
        {
            bool isHorizontal = directionType == Directions.LEFT || directionType == Directions.RIGHT;

            if (!Positions.TryGetValue(item, out Hitbox value))
            {
                if (item.GetType() == typeof(Bullet))
                {
                    Bullet bullet = item as Bullet;
                    ICharacter shotBy = bullet.ShotBy;
                    Hitbox shotByPos = Positions[shotBy];
                    Sprite shotBySprite = shotBy.Sprite;

                    value = Draw(item,
                        shotBy.CurrentDirection == Directions.RIGHT ?
                            shotByPos.BottomRight.X + 1 :
                            shotByPos.TopLeft.X - 1,
                        shotBySprite.Height / 2
                    );
                }
                else return;
            }

            Position topLeft = value.TopLeft;

            lock (Lock)
            {
                Erase(item);
                Draw(item, isHorizontal ? topLeft.X + direction : topLeft.X, isHorizontal ? 0 : direction);
            }
        }

        protected virtual Hitbox Draw(IPositionMe item, int topX, int topY = 0)
        {
            //Modify Y when item isn't Floor
            if (item.GetType() != typeof(Floor))
                topY = Positions[Floor].BottomRight.Y - item.Sprite.Height - topY - 1;

            //Add item's hitbox to Positions
            var itemHitbox = new Hitbox(
                new Position(topX, topY),
                new Position(topX + item.Sprite.Width, topY + item.Sprite.Height)
            );

            Positions.Set(item, itemHitbox);

            //Draw sprite
            ModifyCanvas(item, topX, topY, true);

            return itemHitbox;
        }
        protected virtual void Erase(IPositionMe item)
        {
            if (!Positions.TryGetValue(item, out Hitbox hitbox)) return;
            Positions.Remove(item);
            ModifyCanvas(item, hitbox.TopLeft, false);
        }

        protected virtual void ModifyCanvas(IPositionMe item, Position topLeft, bool draw) => ModifyCanvas(item, topLeft.X, topLeft.Y, draw);
        protected virtual void ModifyCanvas(IPositionMe item, int topX, int topY, bool draw)
        {
            Position startPosition = new(topX, topY);
            for (int height = 0; height < item.Sprite.Height; height++)
            {
                for (int width = 0; width < item.Sprite.Width; width++)
                {
                    char spriteItem = item.Sprite[height][width];
                    Position spriteItemPos = new(startPosition.X + width, startPosition.Y + height);

                    if (Positions.Includes(spriteItemPos, out IPositionMe collided) && collided != null && !HandleCollision(item, collided))
                        return;

                    GamingConsole.SetPosition(spriteItemPos, draw ? spriteItem : ' ');
                }
            }
        }
        #endregion

        public bool HasType<T>() where T : IPositionMe
        {
            foreach (var key in Positions.Keys)
            {
                if (key.GetType() == typeof(T))
                    return true;
            }
            return false;
        }
        public void ClearBullets()
        {
            if (!HasType<Bullet>()) return;

            List<IPositionMe> bulletKeys = new();
            foreach (var kvp in Positions)
            {
                if (kvp.Key.GetType() != typeof(Bullet)) continue;
                bulletKeys.Add(kvp.Key);
            }

            bulletKeys.ForEach(key => Erase(key));
        }

        #region Collision
        protected virtual bool HandleCollision(IPositionMe collider, IPositionMe collided)
        {
            if (collider == collided) return true;

            Player player = ConvertCollider<Player>(collider, collided);
            Enemy enemy = ConvertCollider<Enemy>(collider, collided);
            Bullet bullet = ConvertCollider<Bullet>(collider, collided);

            if (bullet != null) Positions.Remove(bullet);

            if (player != null)
            {
                if (bullet != null)
                {
                    player.BeShot(bullet.Damage);
                    bullet.StopMoving();
                }
                else if (enemy != null) enemy.Die();
                return player == collider;
            }
            else if (enemy != null && bullet != null && bullet.ShotBy.GetType() != typeof(Enemy))
            {
                enemy.BeShot(bullet.Damage);
                bullet.StopMoving();

                return enemy == collider;
            }
            return false;
        }
        protected static T ConvertCollider<T>(IPositionMe collider, IPositionMe collided) where T : class =>
            collider.GetType() == typeof(T) ? collider as T :
            collided.GetType() == typeof(T) ? collided as T : null;
        #endregion

        public virtual void GameOver(string gameOver, Heading heading)
        {
            GamingConsole.CenterText($"Score: ${heading.Score}", 5);
            GamingConsole.CenterText($"Stats: ${heading.Stats}", 3);
            GamingConsole.CenterText(gameOver);
        }
        public virtual List<Enemy> SpawnEnemies(List<Enemy> enemies)
        {
            int lastX = GamingConsole.Center.X;

            foreach (Enemy enemy in enemies)
                Enemies.AddAndDraw(enemy, lastX += enemy.Sprite.Width + 2);
            return Enemies;
        }

        protected virtual void OnPlayerDead(Player player) => Erase(player);
        protected virtual void OnEnemiesAdded(Enemy enemy, int topX) => Draw(enemy, topX);
        protected virtual void OnEnemiesRemoved(Enemy enemy) => Erase(enemy);
        public virtual void OnBulletsMoving(Bullet bullet)
        {
            MoveIPosition(bullet, bullet.Direction, bullet.Direction == Directions.RIGHT ? 1 : -1);
        }
    }
}
