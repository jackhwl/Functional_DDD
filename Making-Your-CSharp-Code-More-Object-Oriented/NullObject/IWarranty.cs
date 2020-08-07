using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal interface IWarranty
    {
        bool IsValidOn(DateTime date);
    }
}
