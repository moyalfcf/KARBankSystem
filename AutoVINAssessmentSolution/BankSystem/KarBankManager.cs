using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class KarBankManager : IBankManager
    {
        private static KarBankManager _instance;
        public static KarBankManager Instance
        {
            get
            {
                if (_instance == null) _instance = new KarBankManager();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private KarBankManager()
        {

        }

        private Dictionary<string, KarBank> _allBanks = new Dictionary<string, KarBank>();

        public CheckingAccount TestingAccount { get; } = new CheckingAccount() { Owner = "sys", Balance = 99999 };
       
        public IEnumerable<KarBank> GetAllBanks()
        {
            return _allBanks.Values.ToList();
        }
        public KarBank FindABank(string name)
        {
            if (_allBanks.ContainsKey(name)) return _allBanks[name];
            else return null;
        }
        public KarBank OpenABank(string name)
        {
            if (_allBanks.ContainsKey(name))
            {
                Console.WriteLine(string.Format("Bank: {0} exists. Please choose another name."));
                return _allBanks[name];
            }
            else
            {
                var newBank = new KarBank() { Id = Guid.NewGuid(), Name = name };
                _allBanks.Add(name, newBank);
                return newBank;
            }
        }
        public void CloseABank(string name)
        {
            if (!_allBanks.ContainsKey(name))
            {
                Console.WriteLine(string.Format("Bank: {0} does not exist."));
            }
            else
            {
                _allBanks.Remove(name);
            }
        }

    }
}
