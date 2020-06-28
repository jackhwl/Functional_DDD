using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public abstract class Money
    {
        public abstract Money On(Timestamp time);
        public abstract SpecificMoney Of(Currency currency);
    }
}
