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

        public void Deposit(decimal amount)
        {
            if (!this.IsClosed)
                return;
            // Deposit money
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!this.IsVarified)
                return;
            if (!this.IsClosed)
                return;
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
    }
}
