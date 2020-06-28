using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class BankCard
    {
        public DateTime ValidBefore { get; }
        public decimal Balance { get; }

        public BankCard(DateTime validBefore, decimal balance)
        {
            this.ValidBefore = validBefore;
            this.Balance = balance;
        }

        public decimal GetAvailableAmount(decimal desired, DateTime at)
        {
            if (at.CompareTo(this.ValidBefore) >= 0)
                return 0;
            return Math.Max(this.Balance, desired);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
