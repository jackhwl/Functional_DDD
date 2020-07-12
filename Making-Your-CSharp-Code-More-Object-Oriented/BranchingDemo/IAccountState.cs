using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    interface IAccountState
    {
        IAccountState Deposit();
        IAccountState Withdraw();
        IAccountState Freeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
