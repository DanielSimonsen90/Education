using pewpew.Items;
using System.Collections.Generic;
using System.Threading;

namespace pewpew.Characters
{
    public abstract class Character : ICharacter
    {
        #region Properties 
        public Sprite Sprite => SpriteDirections[CurrentDirection];
        public Dictionary<Directions, Sprite> SpriteDirections { get; } = new Dictionary<Directions, Sprite>();

        #region Health
        protected int health = 100;
        public int Health
        {
            get => health;
            protected set
            {
                health = value;
                HealthUpdate(this, value);
            }
        }
        public event ICharacter.HealthUpdatedHandler HealthUpdate;
        #endregion

        #region Damage
        protected int damage = 10;
        public int Damage
        {
            get => damage;
            protected set
            {
                damage = value;
                DamageUpdate(this, value);
            }
        }
        public event ICharacter.DamageUpdateHandler DamageUpdate;
        #endregion 

        public virtual Directions CurrentDirection { get; protected set; } = Directions.RIGHT;
        #endregion

        public Character(int health, int damage)
        {
            this.health = health;
            this.damage = damage;

            Move += OnMoved;
            Shot += OnShot;
        }


        #region Events

        #region Move Event
        public event ICharacter.MoveHandler Move;
        public virtual void MoveToThe(Directions direction)
        {
            Move.Invoke(this, direction);

            if (direction == Directions.JUMP) 
                Jump(() => Fall());
        }
        protected virtual void OnMoved(ICharacter character, Directions direction) => CurrentDirection = direction;

        protected virtual ThreadStart Fall() => new(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Move.Invoke(this, Directions.FALL);
                Thread.Sleep(10);
            }
        });
        protected virtual ThreadStart Jump(ThreadStart fall) => new(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Move.Invoke(this, Directions.JUMP);
                Thread.Sleep(15);
            }
            fall.Invoke();
        });
        #endregion

        #region Shot Event
        public event ICharacter.ShotHandler Shot;
        public virtual int BeShot(int damage) => Shot.Invoke(damage);
        protected virtual int OnShot(int damage) => Health -= damage;
        #endregion

        #region Die Event
        public event ICharacter.DeathHandler Death;
        public virtual void Die() => Death.Invoke(this);
        #endregion

        #endregion

        public virtual Bullet Shoot(Directions direction)
        {
            var bullet = new Bullet(this, direction, Damage);
            bullet.BulletHit += (ICharacter character, IBullet bullet) =>
            {
                if (character == this)
                    OnShot(bullet.Damage);
            };

            return bullet;
        }
    }
}
