using Rogue_Financial_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.ViewModel
{
    public class GetBankAndTransactionDataVM
    {
        public BankAccount BankAccount { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public GetBankAndTransactionDataVM()
        {
            Transactions = new List<Transaction>();
        }
    }
}