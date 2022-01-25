using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class IndividualAccount : InvestmentAccount
    {
        private decimal _limit = 500;

        public IndividualAccount() : base()
        { }

        protected override bool ValidateBalance(decimal money)
        {
            if (money > _limit)
            {
                Console.WriteLine(String.Format("Account: {0} - Your withdrawal limit is {1} dollars", Owner, _limit));
                return false;
            }
            return base.ValidateBalance(money);
        }

    }
}
