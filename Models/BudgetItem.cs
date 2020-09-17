using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.Models
{
    ///<summary>
    ///BudgetItem
    ///</summary>
    public class BudgetItem
    {
        ///<summary>
        ///BudgetItem Id
        ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///Owner/ creator Id of the BudgetItem
        ///</summary>
        public string OwnerId { get; set; }
        ///<summary>
        ///Budget Id of the Budget associated with the Budget Item
        ///</summary>
        public int BudgetId { get; set; }
        ///<summary>
        ///Item Name
        ///</summary>
        public string ItemName { get; set; }
        ///<summary>
        ///Created Date
        ///</summary>
        public DateTime Created { get; set; }
        ///<summary>
        ///Description
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///Current Amount
        ///</summary>
        public decimal CurrentAmount { get; set; }
        ///<summary>
        ///Target Amount
        ///</summary>
        public decimal TargetAmount { get; set; }
        ///<summary>
        ///Bool for if the BudgetItem is deleted
        ///</summary>
        public bool IsDeleted { get; set; }


    }
}