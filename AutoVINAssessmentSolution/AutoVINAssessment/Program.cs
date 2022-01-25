using BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVINAssessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBankManager bm = KarBankManager.Instance;
            var aBank = bm.OpenABank("Auto VIN Bank");
            BuildTestBank(aBank);
            TestTransactions(aBank);
        }
        private static void TestTransactions(KarBank bank)
        {
            foreach (IAccountTransaction trans in bank.Accounts)
            {
                var msg = string.Format("Testing {0} account: {1}...", (trans as KarAccount).AccountType, (trans as KarAccount).Owner);
                Console.WriteLine(msg);
                trans.Deposit(100);
                trans.Withdraw(50);
                trans.Withdraw(501);
                trans.Transfer(100, KarBankManager.Instance.TestingAccount);
                trans.Transfer(500, KarBankManager.Instance.TestingAccount);
                Console.WriteLine("---------------------------------------------------");
            }
        }

        private static void BuildTestBank(KarBank bank)
        {
            bank.Accounts.Add(new CheckingAccount() { Owner = "A", Balance = 100010000 });
            bank.Accounts.Add(new IndividualAccount() { Owner = "B", Balance = 5000 });
            bank.Accounts.Add(new CorporateAccount() { Owner = "C", Balance = 10010100010 });
            bank.Accounts.Add(new IndividualAccount() { Owner = "D", Balance = 100 });
        }

    }
}
