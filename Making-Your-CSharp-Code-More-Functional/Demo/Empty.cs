using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Empty : SpecificMoney
    {
        public Empty(Currency currency) : base(currency)
        {

        }

        public override Money On(Timestamp time)
        {
            throw new NotImplementedException();
        }

        public override (Amount taken, Money remaining) Take(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
