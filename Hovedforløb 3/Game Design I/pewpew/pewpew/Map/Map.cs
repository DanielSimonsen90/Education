using pewpew.Characters;
using System;
using System.Collections.Generic;

namespace pewpew
{
    public class Map : IMap
    {
        private Dictionary<IPositionMe, Hitbox> Positions { get; set; }
        private GameConsole GamingConsole { get; }
        private Floor Floor { get; }

        public List<Enemy> Enemies { get; protected set; } = new List<Enemy>();

        public Map(IPlayer player, GameConsole console)
        {
            Positions = new Dictionary<IPositionMe, Hitbox>();
            GamingConsole = console;
            Floor = new Floor(
                console.BottomRight.X - 1 +
                console.BottomLeft.X - 1
            );
            Draw(Floor, console.BottomLeft.X, console.BottomLeft.Y + 3);
            Draw(player, 0);
        }

        #region Move
        public void MoveEnemyHorizontal(Enemy enemy, int direction)
        {
            throw new NotImplementedException();
        }
        public void MoveEnemyVertical(Enemy enemy, int direction)
        {
            throw new NotImplementedException();
        }
        public void MovePlayerHorizontal(Player player, int direction)
        {
            var topLeft = Positions[player].TopLeft;
            Erase(player);
            Draw(player, topLeft.X + direction);
        }
        public void MovePlayerVertical(Player player, int direction)
        {
            var topLeft = Positions[player].TopLeft;
            Erase(player);
            Draw(player, topLeft.X, topLeft.Y + direction);
        }
        #endregion

        #region Draw Characters
        public void Draw(IPositionMe item, int topX, int topY = 0)
        {
            //Modify Y when item isn't Floor
            if (item.GetType() != typeof(Floor))
                topY = Positions[Floor].BottomRight.Y - item.Sprite.Height - topY - 1;

            //Add item's hitbox to Positions
            var itemHitbox = new Hitbox(
                new Position(topX, topY),
                new Position(topX + item.Sprite.Width, topY + item.Sprite.Height)
            );

            if (Positions.ContainsKey(item))
                Positions.Remove(item);
            Positions.Add(item, itemHitbox);

            //Draw sprite
            ModifyCanvas(item, topX, topY, true);
        }
        public void Erase(IPositionMe character)
        {
            Hitbox hitbox = Positions[character];
            Positions.Remove(character);
            ModifyCanvas(character, hitbox.TopLeft, false);
        }

        private void ModifyCanvas(IPositionMe item, Position topLeft, bool draw) => ModifyCanvas(item, topLeft.X, topLeft.Y, draw);
        private void ModifyCanvas(IPositionMe item, int topX, int topY, bool draw)
        {
            Position startPosition = new(topX, topY);
            for (int height = 0; height < item.Sprite.Height; height++)
            {
                for (int width = 0; width < item.Sprite.Width; width++)
                {
                    char spriteItem = item.Sprite[height][width];
                    Position spriteItemPos = new(startPosition.X + width, startPosition.Y + height);
                    GamingConsole.SetPosition(spriteItemPos, draw ? spriteItem : ' ');
                }
            }
        }

        public void GameOver(string gameOver, Heading heading)
        {
            GamingConsole.CenterText($"Score: ${heading.Score}", 5);
            GamingConsole.CenterText($"Stats: ${heading.Stats}", 3);
            GamingConsole.CenterText(gameOver);
        }

        public List<Enemy> SpawnEnemies(List<Enemy> enemies)
        {
            int lastX = GamingConsole.Center.X;

            foreach (Enemy enemy in enemies)
            {
                Enemies.Add(enemy);
                Draw(enemy, lastX -= 5);
            }
            return Enemies;
        }
        #endregion
    }
}
