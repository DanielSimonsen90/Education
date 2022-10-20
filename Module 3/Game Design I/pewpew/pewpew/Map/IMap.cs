using pewpew.Characters;
using pewpew.Items;
using System.Collections.Generic;

namespace pewpew
{
    public interface IMap
    {
        //void Draw(IPositionMe character, int x, int y);
        //void Erase(IPositionMe character);
        void MoveIPosition<IPosition>(IPosition item, Directions directionType, int direction) where IPosition : IPositionMe;
        List<Enemy> SpawnEnemies(List<Enemy> enemies);
    }
}
