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
        static bool CanPay(Money money, Amount expense)
        {
            Timestamp now = Timestamp.NOW;
            switch (money)
            {
                case Amount amount when amount.Currency == expense.Currency;
                    return amount.Value >= expense.Value;
                case GiftCard 
            }
        }
        static void Main(string[] args)
        {
            IDictionary<Currency, Money> moneys = new Dictionary<Currency, Money>();

            Money money = new Amount(Currency.USD, 100);
            moneys.Add(Currency.USD, money);
            Console.WriteLine($"Added {money}. ");

            if (moneys.ContainsKey(Currency.USD))
            {
                Console.WriteLine($"Found {moneys[Currency.USD]}");
            }
            else
            {
                Console.WriteLine($"{Currency.USD} not found. ");
            }

            Console.ReadLine();
        }
    }
}
