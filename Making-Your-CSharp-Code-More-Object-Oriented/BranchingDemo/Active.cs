using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Active : IFreezable
    {
        IFreezable IFreezable.Deposit()
        {
            throw new NotImplementedException();
        }

        IFreezable IFreezable.Freeze()
        {
            throw new NotImplementedException();
        }

        IFreezable IFreezable.Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
