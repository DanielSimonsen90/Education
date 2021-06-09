using pewpew.Characters;

namespace pewpew.Items
{
    public interface IBullet
    {
        public ICharacter ShotBy { get; }
        public int Damage { get; }
        public Directions Direction { get; }

        delegate void BulletHitHandler(ICharacter character, IBullet bullet);
        public event BulletHitHandler BulletHit;
    }
}
