using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectsDemo
{
    class MoneyAmount
    {
        public decimal Amount { get; set; }
        public string CurrencySymbol { get; set; }

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}
