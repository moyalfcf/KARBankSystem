using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public interface IAccountTransaction
    {
        void Deposit(decimal money);
        void Withdraw(decimal money);
        void Transfer(decimal money, KarAccount destinateAccount);
    }
}
