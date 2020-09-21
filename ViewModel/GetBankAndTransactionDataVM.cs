using Rogue_Financial_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.ViewModel
{
    ///<summary>
    ///Gets the Transaction and Bank Account Data
    ///</summary>
    public class GetBankAndTransactionDataVM
    {
        ///<summary>
        ///Bank Account Object
        ///</summary>
        public BankAccount BankAccount { get; set; }

        ///<summary>
        ///List Of Transactions 
        ///</summary>
        public ICollection<Transaction> Transactions { get; set; }
        ///<summary>
        ///Method for initializing Transactions 
        ///</summary>
        public GetBankAndTransactionDataVM()
        {
            Transactions = new List<Transaction>();
        }
    }
}