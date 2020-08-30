using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class NotOperationalRule : IWarrantyRules
    {
        private Action<Action> ClaimAction { get; }
        private IWarrantyRules Next { get; }
        private Action<Action> ClaimStrategy { get; set; }
        public NotOperationalRule(Action<Action> claimAction, IWarrantyRules next)
        {
            this.ClaimAction = claimAction;
            this.Next = next;
        }
        public void CircuitryOperational() { }
        public void CircuitryFailed() { }
        public void VisiblyDamaged() { }

        public void NotOperational()
        {
            this.ClaimStrategy = (onValidClaim) => this.ClaimAction(onValidClaim);
        }

        public void Operational()
        {
            this.ClaimStrategy = (onValidClaim) => this.Next.Claim(onValidClaim);
        }
        public void Claim(Action onValidClaim) 
        {
            ClaimStrategy(onValidClaim);
        }
    }
}
