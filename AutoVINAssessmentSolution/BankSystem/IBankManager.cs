using System.Collections.Generic;

namespace BankSystem
{
    public interface IBankManager
    {
        IEnumerable<KarBank> GetAllBanks();
        KarBank FindABank(string name);
        KarBank OpenABank(string name);
        void CloseABank(string name);
    }
}