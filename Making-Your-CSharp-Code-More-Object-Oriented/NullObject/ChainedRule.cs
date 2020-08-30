using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    abstract class ChainedRule : IWarrantyRules
    {
        private IWarrantyRules Next { get; }
        public ChainedRule(IWarrantyRules next)
        {
            this.Next = next;
        }

        protected void Forward(Action onValidClaim) => this.Next.Claim(onValidClaim);

        public virtual void CircuitryOperational() { }
        public virtual void CircuitryFailed() { }
        public virtual void VisiblyDamaged() { }
        public virtual void NotOperational() { }
        public virtual void Operational() { }

        public Action<Action> Claim { get; protected set; }
    }
}
