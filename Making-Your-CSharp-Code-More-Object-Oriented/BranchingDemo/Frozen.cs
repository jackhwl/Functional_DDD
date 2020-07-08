using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Frozen : IFreezable
    {
        public IFreezable Deposit()
        {
            throw new NotImplementedException();
        }

        public IFreezable Freeze()
        {
            throw new NotImplementedException();
        }

        public IFreezable Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
