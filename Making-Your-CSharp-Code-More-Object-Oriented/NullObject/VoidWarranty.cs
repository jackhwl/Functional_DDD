using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class VoidWarranty : IWarranty
    {
        public bool IsValidOn(DateTime date) => false;
    }
}
