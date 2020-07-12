using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class NotVerified : IAccountState
    {
        public IAccountState Close() => new Closed();

        public IAccountState Deposit()
        {
            throw new NotImplementedException();
        }

        public IAccountState Freeze()
        {
            throw new NotImplementedException();
        }

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
