using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    [Flags]
    enum DeviceStatus
    {
        AllFine = 0,
        NotOperational = 1,
        VisiblyDamaged = 2,
        CircuitryFailed = 4
    }
}
