using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public abstract class SpecificMoney : Money
    {
        public Currency Currency { get; }

        protected SpecificMoney(Currency currency)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        //public static SpecificMoney Of(SpecificMoney @this, Currency currency)
        //{
        //    if (currency.Equals(@this.Currency))
        //        return @this;
        //    return new Empty(currency);
        //}

        public override SpecificMoney Of(Currency currency)
        {
            if (currency == this.Currency)
                return this;
            return new Empty(currency);
        }

        public abstract (Amount taken, Money remaining) Take(decimal amount);
    }
}
