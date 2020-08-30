using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class NotOperationalRule : ChainedRule, IWarrantyRules
    {
        private Action<Action> ClaimAction { get; }
        public NotOperationalRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            base.Claim = base.Forward;
            this.ClaimAction = claimAction;
        }

        public override void NotOperational()
        {
            base.Claim = this.ClaimAction;
        }

        public override void Operational()
        {
            base.Claim = this.Forward;
        }
    }
}
