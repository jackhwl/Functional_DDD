using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Wallet
    {
        private IList<Money> Content { get; } = new List<Money>();

        public void Add(Money money)
        {
            this.Content.Add(money);
        }

        public void Charge(Currency currency, Amount toCharge)
        {
            IEnumerable<SpecificMoney> moneys =
            this.Content.Select(money => money.On(Timestamp.Now))
                        .Select(money => money.Of(currency))
        }
    }
}
