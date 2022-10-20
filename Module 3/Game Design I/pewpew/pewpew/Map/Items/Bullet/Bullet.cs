using pewpew.Characters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace pewpew.Items
{
    public class Bullet : IBullet
    {
        public ICharacter ShotBy { get; }
        public int Damage { get; }
        public Directions Direction { get; }

        public bool Moving { get; private set; } = false;
        public int MovementSpeed { get; } = 100;
        protected Thread MovingSequence { get; }

        public Sprite Sprite { get; }

        public Bullet(ICharacter shotBy, Directions direction, int damage)
        {
            ShotBy = shotBy;
            Damage = damage;
            Direction = direction;
            Sprite = new Sprite(new List<List<char>>() { new List<char>() { '-' } });

            MovingSequence = new Thread(new ThreadStart(() =>
            {
                while (Moving)
                {
                    Move.Invoke(this);
                    Thread.Sleep(MovementSpeed);
                }
            }));
        }

        public delegate void BulletMoveHandler(Bullet bullet);
        public event BulletMoveHandler Move;

        public void StartMoving() => ToggleMove(true);
        public void StopMoving() => ToggleMove(false);
        private void ToggleMove(bool moving)
        {
            Moving = moving;
            if (moving) MovingSequence.Start();
        }

        public void Hit(ICharacter character) => BulletHit.Invoke(character, this);
        public event IBullet.BulletHitHandler BulletHit;
    }
}
