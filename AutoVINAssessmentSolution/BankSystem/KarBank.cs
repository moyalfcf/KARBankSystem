using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class KarBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<KarAccount> Accounts { get; set; } = new List<KarAccount>();
    }
}
