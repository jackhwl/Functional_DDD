using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Active : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Withdraw() => this;

        public IFreezable Freeze() => new Frozen(this.OnUnfreeze);
    }
}
