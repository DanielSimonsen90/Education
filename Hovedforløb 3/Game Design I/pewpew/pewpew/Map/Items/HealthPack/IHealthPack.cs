using pewpew.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pewpew.Items
{
    public interface IHealthPack
    {
        int Value { get; }

        delegate void HealthPackCollision(ICharacter hitBy, IHealthPack healthPack);
        event HealthPackCollision HealthPackHit;
    }
}
