using RogueFinancialPortal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.Models
{
    ///<summary>
    ///Bank Account
    ///</summary>
    public class BankAccount
    {  ///<summary>
       ///Bank Account Id
       ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///HouseHold Id that the Bank Account is in
        ///</summary>
        public int HouseHoldId { get; set; }
        ///<summary>
        /// Owner/creator Id of the Bank Account 
        ///</summary>
        public string OwnerId { get; set; }
        ///<summary>
        ///Name of Bank Account
        ///</summary>
        public string BankAccountName { get; set; }
        ///<summary>
        /// Created Date
        ///</summary>
        public DateTime Created { get; set; }
        ///<summary>
        ///Current Balance 
        ///</summary>
        public decimal CurrentBalance { get; set; }
        ///<summary>
        ///Warning Balance
        ///</summary>
        public decimal WarningBalance { get; set; }
        ///<summary>
        ///Bool for if the Bank Account is deleted
        ///</summary>
        public bool IsDeleted { get; set; }
        ///<summary>
        ///Account Type
        ///</summary>
        public AccountType AccountType { get; set; }

        
    }
}