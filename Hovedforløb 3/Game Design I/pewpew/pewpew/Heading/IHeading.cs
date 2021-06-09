using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pewpew
{
    public interface IHeading
    {
        Stats Stats { get; }
        Score Score { get; }
    }
}
