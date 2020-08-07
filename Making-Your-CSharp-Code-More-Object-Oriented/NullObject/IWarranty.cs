using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim ); 
    }
}
