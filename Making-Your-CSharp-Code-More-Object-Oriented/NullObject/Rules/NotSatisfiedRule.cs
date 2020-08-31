using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class NotSatisfiedRule : IWarrantyRules
    {

        public void CircuitryOperational() { }
        public void CircuitryFailed() { }
        public void VisiblyDamaged() { }
        public void NotOperational() { }
        public void Operational() { }

        public Action<Action> Claim => (action) => { };
    }
}
