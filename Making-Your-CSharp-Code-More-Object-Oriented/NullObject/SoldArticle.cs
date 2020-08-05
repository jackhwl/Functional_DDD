using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class SoldArticle
    {
        public Warranty MoneyBackGuarantee { get; }
        public Warranty ExpressWarranty { get; }

        public SoldArticle(Warranty moneyBack, Warranty express)
        {
            this.MoneyBackGuarantee = moneyBack;
            this.ExpressWarranty = express;
        }
    }
}
