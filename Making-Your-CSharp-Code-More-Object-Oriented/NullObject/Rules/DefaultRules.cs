using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class DefaultRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(Action<Action> claimMoneyBack,
                                     Action<Action> claimNotOperationalWarranty,
                                     Action<Action> claimCircuitryWarranty) =>
            new NotOperationalRule(claimNotOperationalWarranty,
                new CircuitryRule(claimCircuitryWarranty,
                    new MoneyBackRule(claimMoneyBack,
                        new NotSatisfiedRule())));
    }
}
