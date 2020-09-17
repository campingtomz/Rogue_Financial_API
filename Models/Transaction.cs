using RogueFinancialPortal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.Models
{
    ///<summary>
    ///Transaction
    ///</summary>
    public class Transaction
    {
        ///<summary>
        ///Transaction Id
        ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///Owner/ creator Id of the Transaction
        ///</summary>
        public string OwnerId { get; set; }
        ///<summary>
        ///Bank Account Id of the Bank Account associated with the Transaction
        ///</summary>
        public int BankAccontId { get; set; }
        ///<summary>
        ///Budget Item Id of the Budget Item associated with the Transaction
        ///</summary>
        public int? BudgetItemId { get; set; }
        ///<summary>
        ///Created
        ///</summary>
        public DateTime Created { get; set; }
        ///<summary>
        ///Amount
        ///</summary>
        public decimal Amount { get; set; }
        ///<summary>
        ///Memo
        ///</summary>
        public string Memo { get; set; }
        ///<summary>
        ///File Path
        ///</summary>
        public string FilePath { get; set; }
        ///<summary>
        ///Bool for if the Transaction is deleted
        ///</summary>
        public bool IsDeleted { get; set; }
        ///<summary>
        ///Transaction Type
        ///</summary>
        public TransactionType TransactionType { get; set; }
    }
}