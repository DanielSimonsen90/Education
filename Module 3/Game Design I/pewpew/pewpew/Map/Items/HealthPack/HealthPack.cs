namespace pewpew.Items
{
    public class HealthPack : IHealthPack
    {
        public int Value { get; }

        public HealthPack(int value) => Value = value;

        public event IHealthPack.HealthPackCollision HealthPackHit;
    }
}
