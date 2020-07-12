using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
         
        public IAccountState Deposit()
        {
            this.OnUnfreeze();
            return new Active(OnUnfreeze);
        }

        public IAccountState Withdraw()
        {
            this.OnUnfreeze();
            return new Active(OnUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}
