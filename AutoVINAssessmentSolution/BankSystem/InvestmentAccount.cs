using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class InvestmentAccount : KarAccount
    {
        public InvestmentAccount() : base()
        {
            AccountType = "Investment";
        }
    }
}
