using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueFinancialPortal.Enums
{

    ///<summary>
    ///Transaction Type Enum
    ///</summary>
    public enum TransactionType
    {
        ///<summary>
        ///Deposit
        ///</summary>
        Deposit,
        ///<summary>
        ///Withdrawal
        ///</summary>
        Withdrawal,
        ///<summary>
        ///Transfer
        ///</summary>
        Transfer,
        ///<summary>
        ///Refund
        ///</summary>
        Refund,

    }
}