using pewpew.Characters;
using System.Collections.Generic;

namespace pewpew.Items
{
    public class Bullet : IBullet, IPositionMe
    {
        public ICharacter ShotBy { get; }
        public int Damage { get; }
        public Directions Direction { get; }

        public Sprite Sprite { get; }

        public Bullet(ICharacter shotBy, Directions direction, int damage)
        {
            ShotBy = shotBy;
            Damage = damage;
            Direction = direction;
            Sprite = new Sprite(new List<List<char>>() { new List<char>() { '-' } });
        }

        public void Hit(ICharacter character) => BulletHit.Invoke(character, this);
        public event IBullet.BulletHitHandler BulletHit;
    }
}
