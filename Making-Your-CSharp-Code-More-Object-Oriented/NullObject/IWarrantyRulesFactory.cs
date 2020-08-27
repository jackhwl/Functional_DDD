using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    interface IWarrantyRulesFactory
    {
        IWarrantyRules Create(
            Action<Action> claimMoneyBack,
            Action<Action> claimNotOperationalWarranty,
            Action<Action> claimCircuitryWarranty);
    }
}
