using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class ChristmassRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(
            Action<Action> claimMoneyBack,
            Action<Action> claimNotOperationalWarranty,
            Action<Action> claimCircuitryWarranty) =>
                new ConditionalRule(IsAroundChristmas, claimMoneyBack,
                   new DefaultRules().Create(claimMoneyBack, 
                                             claimCircuitryWarranty,
                                             claimCircuitryWarranty));

        private static bool IsAroundChristmas() => DateTime.Today.Month == 12;
    }
}
