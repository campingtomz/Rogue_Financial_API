using Newtonsoft.Json;
using Rogue_Financial_API.Models;
using Rogue_Financial_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rogue_Financial_API.Controllers
{
    ///<summary>
    ///Transactions Controller 
    ///</summary>
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        #region json
        ///<summary>
        ///Gets all of the columns for a single Transaction record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Transaction</param>
        [Route("GetTransactionDataById/json")]
        public async Task<IHttpActionResult> GetTransactionDataByIdJson(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDataById(Id));
            return Ok(json);
        }
        ///<summary>
        ///Gets all of the Transaction records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllTransactionData/json")]
        public async Task<IHttpActionResult> GetAllTransactionDataJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAllTransactionData(hhId));
            return Ok(json);
        }
        #endregion
        #region XML
        ///<summary>
        ///Gets all of the columns for a single Transaction record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Transaction</param>
        [Route("GetTransactionDataById")]
        public async Task<Transaction> GetTransactionDataById(int Id)

        {
            return await db.GetTransactionDataById(Id);
        }
        ///<summary>
        ///Gets all of the Transaction records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData(int hhId)
        {
            return  await db.GetAllTransactionData(hhId);

        }
        #endregion
        #region insert/add/create Transaction
        /// <summary>
        /// create a new Transaction and add it to the Database
        /// </summary> 
        /// <param name="OwnerId">Guid of user</param>
        /// <param name="BankAccountId">FK of Bank Account</param>
        /// <param name="BudgetItemId">FK of Budget Item</param>      
        /// <param name="TransactionType">Enum: Deposit, Withdrawal, Transfer</param>
        /// <param name="Amount">Amount</param>
        /// <param name="Memo">Information about this transaction</param>
        /// <param name="FilePath">File Path of attachment</param>
        /// <returns></returns>
        [HttpPost, Route("CreateTransaction")]
        public IHttpActionResult CreateTransaction(int OwnerId, int BankAccountId, int BudgetItemId, string TransactionType, string Amount, string Memo, string FilePath)
        {
            return Ok(db.CreateTransaction(OwnerId, BankAccountId, BudgetItemId, TransactionType, Amount, Memo, FilePath));
        }

        #endregion
        #region Update Transaction
        /// <summary>
        ///  updates the Budget by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Transaction</param>
        /// <param name="BankAccountId">FK of Bank Account</param>
        /// <param name="BudgetItemId">FK of Budget Item</param>      
        /// <param name="TransactionType">Enum: Deposit, Withdrawal, Transfer</param>
        /// <param name="Amount">Amount</param>
        /// <param name="Memo">Information about this transaction</param>
        /// <param name="FilePath">File Path of attachment</param>
        /// <param name="IsDeleted">Bool used for softDelete </param>
        /// <returns></returns>
        [HttpPost, Route("UpdateTransaction")]
        public IHttpActionResult UpdateTransaction(int Id, string BankAccountId, int BudgetItemId, string TransactionType, string Amount, string Memo, string FilePath, int IsDeleted)
        {
            return Ok(db.UpdateTransaction(Id, BankAccountId, BudgetItemId, TransactionType, Amount, Memo, FilePath, IsDeleted));
        }
        #endregion
        #region delete Transaction
        /// <summary>
        ///  deletes the Transaction by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Transaction</param>

        /// <returns></returns>
        [HttpDelete, Route("DeleteTransactionById")]
        public IHttpActionResult DeleteTransactionById(int Id)
        {
            return Ok(db.DeleteTransactionById(Id));
        }
        /// <summary>
        /// Soft Deletes the Transaction by its Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of Transaction</param>

        /// <returns></returns>
        [HttpDelete, Route("SoftTransactionDeleteById")]
        public IHttpActionResult SoftTransactionDeleteById(int Id)
        {
            return Ok(db.SoftTransactionDeleteById(Id));
        }
        /// <summary>
        /// Soft Deletes the Transactions by the Bank Account Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of BankAccount</param>

        /// <returns></returns>
        [HttpDelete, Route("SoftDeleteTransactionByBankAccount")]
        public IHttpActionResult SoftDeleteTransactionByBankAccount(int Id)
        {
            return Ok(db.SoftDeleteTransactionByBankAccount(Id));
        }
        /// <summary>
        /// Soft Deletes the Transactions by the Budget Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of Budget</param>

        /// <returns></returns>
        [HttpDelete, Route("SoftDeleteTransactionByBudget")]
        public IHttpActionResult SoftDeleteTransactionByBudget(int Id)
        {
            return Ok(db.SoftDeleteTransactionByBudget(Id));
        }
        /// <summary>
        /// Soft Deletes the Transactions by the BugetItem Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of BugetItem</param>

        /// <returns></returns>
        [HttpDelete, Route("SoftDeleteTransactionByBudgetItem")]
        public IHttpActionResult SoftDeleteTransactionByBudgetItem(int Id)
        {
            return Ok(db.SoftDeleteTransactionByBudgetItem(Id));
        }
        #endregion
        #region get Transactions by BankAccountId
        /// <summary>
        ///  Gets Transactions by BankAccount Guid
        /// </summary>   
        /// <param name="Id">Guid of BankAccount</param>

        /// <returns></returns>
        [HttpPost, Route("GetBankAndTransactionData")]
        public async Task<GetBankAndTransactionDataVM> GetBankAndTransactionData(int Id)
        {
            var  transactionByBankAccount =  await db.GetBankAndTransactionData(Id);
            var  bankAccount = await db.GetBankDataById(Id);
            var newGetBankAndTransactionData = new GetBankAndTransactionDataVM()
            {
                BankAccount = bankAccount,
                Transactions = transactionByBankAccount
            };
            return newGetBankAndTransactionData;
        }
        #endregion
    }
}