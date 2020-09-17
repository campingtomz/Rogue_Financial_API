using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.Models
{

    ///<summary>
    ///Budget
    ///</summary>
    public class Budget
    {

        ///<summary>
        ///Budget Id
        ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///HouseHold Id that the Budget is in
        ///</summary>
        public int HouseHoldId { get; set; }
        ///<summary>
        ///Owner/ creator Id of the Budget
        ///</summary>
        public string OwnerId { get; set; }
        ///<summary>
        ///Bank Account Id of the Bank Account associated with the budget
        ///</summary>
        public int BankAccontId { get; set; }
        ///<summary>
        ///Description
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///Budget Name
        ///</summary>
        public string BudgetName { get; set; }
        ///<summary>
        ///Current Amount
        ///</summary>
        public decimal CurrentAmount { get; set; }
        ///<summary>
        ///Target Amount
        ///</summary>
        public decimal TargetAmount { get; set; }
        ///<summary>
        ///Created Date
        ///</summary>
        public DateTime Created { get; set; }
        ///<summary>
        ///Bool for if the Budget is deleted
        ///</summary>

        public bool IsDeleted { get; set; }


    }
}