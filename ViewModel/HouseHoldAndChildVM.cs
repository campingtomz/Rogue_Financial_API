using Rogue_Financial_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.ViewModel
{    ///<summary>
     ///Model for getting HouseHold and the child data
     ///</summary>
    public class HouseHoldAndChildVM
    {
        ///<summary>
        ///HouseHold Object
        ///</summary>
        public HouseHold HouseHold { get; set; }
        ///<summary>
        ///List of Bank Accounts
        ///</summary>
        public ICollection<BankAccount> BankAccounts { get; set; }
        ///<summary>
        ///List of Budgets
        ///</summary>
        public ICollection<Budget> Budgets { get; set; }
        ///<summary>
        ///List of Budget Items
        ///</summary>
        public ICollection<BudgetItem> BudgetItems { get; set; }
        ///<summary>
        ///List of Transactions
        ///</summary>
        public ICollection<Transaction> Transactions { get; set; }
        ///<summary>
        ///List of Members
        ///</summary>
        public ICollection<Member> Members { get; set; }
        ///<summary>
        ///Method for initializing BankAccounts,Budgets,BudgetItems, Transactions, Members 
        ///</summary>
        public HouseHoldAndChildVM()
        {
            BankAccounts = new List<BankAccount>();
            Budgets = new List<Budget>();
            BudgetItems = new List<BudgetItem>();
            Transactions = new List<Transaction>();
            Members = new List<Member>();


        }
    }
}