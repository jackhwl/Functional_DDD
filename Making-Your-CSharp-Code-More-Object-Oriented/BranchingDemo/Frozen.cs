using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
         
        public IFreezable Deposit()
        {
            this.OnUnfreeze();
            return new Active();
        }

        public IFreezable Withdraw()
        {
            this.OnUnfreeze();
            return new Active();
        }

        public IFreezable Freeze() => this;
    }
}
