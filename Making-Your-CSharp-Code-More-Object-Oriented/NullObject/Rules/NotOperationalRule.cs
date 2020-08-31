using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class NotOperationalRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }
        public NotOperationalRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            base.Claim = base.Forward;
            this.ClaimAction = claimAction;
        }

        protected override void HandleNotOperational()
        {
            base.Claim = this.ClaimAction;
        }

        protected override void HandleOperational()
        {
            base.Claim = this.Forward;
        }
    }
}
