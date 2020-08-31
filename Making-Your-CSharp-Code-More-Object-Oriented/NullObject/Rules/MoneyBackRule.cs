using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class CircuitryRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }
        public CircuitryRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            base.Claim = base.Forward;
            this.ClaimAction = claimAction;
        }

        protected override void HandleCircuitryFailed()
        {
            base.Claim = this.ClaimAction;
        }

        protected override void HandleCircuitryOperational()
        {
            base.Claim = this.Forward;
        }
    }
}
