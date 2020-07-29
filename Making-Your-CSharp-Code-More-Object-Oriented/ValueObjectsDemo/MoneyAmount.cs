using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectsDemo
{
    class MoneyAmount
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }
        public MoneyAmount(decimal amount, string currencySymbol)
        {
            this.Amount = amount;
            this.CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor) => 
            new MoneyAmount(this.Amount * factor, this.CurrencySymbol);

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}
