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

        private IAccountState Freezable { get; set; }

        public Account(Action onUnfreeze)
        {
            this.Freezable = new Active(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            if (!this.IsClosed)
                return;
            // Deposit money
            this.Freezable = this.Freezable.Deposit();
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVarified)
                return;
            if (!this.IsClosed)
                return;
            this.Freezable = this.Freezable.Withdraw();
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

        public void Freeze()
        {
            if (this.IsClosed)
                return; // Account must not be closed
            if (!this.IsVarified)
                return; // Account must be verified
            this.Freezable = this.Freezable.Freeze();
        }
    }
}
