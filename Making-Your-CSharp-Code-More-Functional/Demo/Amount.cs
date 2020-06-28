using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Amount
    {
        public Currency Currency {get; }
        public decimal Value { get; }

        public Amount(Currency currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }
    }
}
