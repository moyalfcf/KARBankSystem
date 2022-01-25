using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class KarAccount : IAccountTransaction
    {
        public Guid Id { get; private set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; protected set; }

        public KarAccount()
        {
            Id = Guid.NewGuid();
        }

        public virtual void Deposit(decimal money)
        {
            Balance += money;
            Console.WriteLine("Account: {0} - Direct Deposit Received. Amount: ${1}; Cuurent Balance: ${2}", Owner, money, Balance);
        }

        public virtual void Withdraw(decimal money)
        {
            if (ValidateBalance(money))
            {
                Balance -= money;
                Console.WriteLine("Account: {0} - Deposit was withdrawn. Amount: ${1}; Cuurent Balance: ${2}", Owner, money, Balance);
            }
        }

        public virtual void Transfer(decimal money, KarAccount destinateAccount)
        {
            if (ValidateBalance(money))
            {
                Balance -= money;
                destinateAccount.Deposit(money);
                Console.WriteLine("Account: {0} - The ${1} funds transfer that you requested is completed.", Owner, money);
            }
        }
        protected virtual bool ValidateBalance(decimal money)
        {
            if (money > Balance)
            {
                var msg = String.Format("Account: {0} - Your account balance is insufficient. Your current balance is: ${1}", Owner, Balance);
                Console.WriteLine(msg);
                return false;
            }
            return true;
        }

    }
}
