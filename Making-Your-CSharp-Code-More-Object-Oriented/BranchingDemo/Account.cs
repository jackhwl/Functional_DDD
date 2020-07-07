using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Account
    {
        public decimal Balance { get; private set;}

        private bool IsVarified { get; set;}
        private bool IsClosed { get; set; }

        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }
        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing =  this.StayUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (!this.IsClosed)
                return;
            // Deposit money
            ManageUnfreezing();
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVarified)
                return;
            if (!this.IsClosed)
                return;
            ManageUnfreezing();
            // Withdraw money
            this.Balance -= amount;
        }

        private void Unfreeze()
        {
            this.OnUnfreeze();
            this.ManageUnfreezing = this.StayUnfreeze;
        }

        private void StayUnfreeze()
        {
        }

        public void HolderVerified()
        {
            this.IsVarified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Frozen()
        {
            if (this.IsClosed)
                return; // Account must not be closed
            if (!this.IsVarified)
                return; // Account must be verified
            this.ManageUnfreezing = this.Unfreeze;
        }
    }
}
