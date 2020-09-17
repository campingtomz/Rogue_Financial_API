using Rogue_Financial_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.ViewModel
{
    public class HouseHoldAndChildVM
    {
        public HouseHold HouseHold { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public ICollection<Budget> Budgets { get; set; }
        public ICollection<BudgetItem> BudgetItems { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Member> Members { get; set; }

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