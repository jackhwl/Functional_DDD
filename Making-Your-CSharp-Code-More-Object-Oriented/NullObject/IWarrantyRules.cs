using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    public interface IWarrantyRules
    {
        void CircuitryOperational();
        void CircuitryFailed();
        void VisiblyDamaged();
        void NotOperational();
        void Operational();
        Action<Action> Claim { get; }
    }
}
