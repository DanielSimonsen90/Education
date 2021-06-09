using pewpew.Characters;
using System.Collections.Generic;

namespace pewpew
{
    public interface IMap
    {
        void MovePlayerHorizontal(Player player, int direction);
        void MovePlayerVertical(Player player, int direction);

        void MoveEnemyHorizontal(Enemy enemy, int direction);
        void MoveEnemyVertical(Enemy enemy, int direction);

        void Draw(IPositionMe character, int x, int y);
        void Erase(IPositionMe character);

        List<Enemy> SpawnEnemies(List<Enemy> enemies);
        //void DrawObsticle();
    }
}
