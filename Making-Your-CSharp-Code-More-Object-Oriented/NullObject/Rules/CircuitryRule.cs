using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class MoneyBackRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }
        public MoneyBackRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            base.Claim = claimAction;
        }

        protected override void HandleVisiblyDamaged()
        {
            base.Claim = base.Forward;
        }
        protected override void HandleNotOperational()
        {
            base.Claim = base.Forward;
        }

        protected override void HandleCircuitryFailed()
        {
            base.Claim = this.Forward;
        }
    }
}
