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
        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }
        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (!this.IsClosed)
                return;
            // Deposit money
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVarified)
                return;
            if (!this.IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            // Withdraw money
            this.Balance -= amount;
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
            this.IsFrozen = true;
        }
    }
}
