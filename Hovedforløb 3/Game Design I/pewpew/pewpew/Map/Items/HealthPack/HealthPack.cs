using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pewpew.Items
{
    class HealthPack : IHealthPack
    {
        public int Value { get; }

        public HealthPack(int value) => Value = value;

        public event IHealthPack.HealthPackCollision HealthPackHit;
    }
}
