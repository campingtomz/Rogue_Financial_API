using Newtonsoft.Json;
using Rogue_Financial_API.Models;
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
    ///Bank Accounts Controller
    ///</summary>
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountscontroller : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        #region Json get
        ///<summary>
        ///Gets all of the columns for a single Bank Account record, based on the PK specified 
        ///</summary>
        ///<remarks>Returns</remarks>
        ///<param name="Id">The PK of the Bank Account</param>        
        [Route("GetBankDataById/json")]
        public async Task<IHttpActionResult> GetBankDataByIdJson(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankDataById(Id));
            return Ok(json);
        }
        ///<summary>
        ///Gets all of the Bank Account records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllBankData/json")]
        public async Task<IHttpActionResult> GetAllBankDataJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBankData(hhId));
            return Ok(json);
        }
        #endregion
        #region XML get
        ///<summary>
        ///Gets all of the columns for a single Bank Account record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Bank Account</param> 
        [Route("GetBankDataById")]
        public async Task<BankAccount> GetBankDataById(int Id)

        {
            return await db.GetBankDataById(Id);
        }
        ///<summary>
        ///Gets all of the Bank Account records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetBankDataData")]
        public async Task<List<BankAccount>> GetAllBankData(int hhId)
        {
            return await db.GetAllBankData(hhId);

        }
        #endregion
        #region insert/add/create BankAccount
        /// <summary>
        /// create a new BankAccount and add it to the Database
        /// </summary>   
        /// <param name="HouseHoldId">FK of HouseHold</param>
        /// <param name="OwnerId">Guid of user</param>
        /// <param name="BankAccountName">Name of Bank Account</param>      
        /// <param name="StartingBalance">The Starting Balance </param>
        /// <param name="WarningBalance">Warning Balance: Sends alert when BankAccount reaches this value</param>
        /// <param name="AccountType">Enum: Checking, Savings, MoneyMarket</param>

        /// <returns></returns>
        [HttpPost, Route("CreateBankAccount")]
        public IHttpActionResult CreateBankAccount(int HouseHoldId, string OwnerId, string BankAccountName, decimal StartingBalance, decimal WarningBalance, int AccountType)
        {
            return Ok(db.CreateBankAccount(HouseHoldId, OwnerId, BankAccountName, StartingBalance, WarningBalance, AccountType));
        }

        #endregion
        #region Update BankAccount
        /// <summary>
        ///  updates the BankAccount by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Household</param>
        /// <param name="HouseHoldId">FK of HouseHold</param>
        /// <param name="BankAccountName">Name of Bank Account</param>      
        /// <param name="WarningBalance">Warning Balance: Sends alert when BankAccount reaches this value</param>
        /// <param name="AccountType">Enum: Checking, Savings, MoneyMarket</param>    
        /// <param name="IsDeleted">Bool used for softDelete </param>
        /// <returns></returns>
        [HttpPost, Route("UpdateBankAccount")]
        public IHttpActionResult UpdateBankAccount(int HouseHoldId, int Id, string BankAccountName, decimal WarningBalance, int AccountType, int IsDeleted)
        {
            return Ok(db.UpdateBankAccount(HouseHoldId, Id, BankAccountName, WarningBalance, AccountType, IsDeleted));
        }
        #endregion
        #region delete BankAccount
        /// <summary>
        ///  deletes the BankAccount by its Guid
        /// </summary>   
        /// <param name="Id">Guid of BankAccount</param>

        /// <returns></returns>
        [HttpDelete, Route("DeleteBankAccountById")]
        public IHttpActionResult DeleteBankAccountById(int Id)
        {
            return Ok(db.DeleteBankAccountById(Id));
        }
        /// <summary>
        /// Soft Deletes the BankAccount by its Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of BankAccount</param>

        /// <returns></returns>
        [HttpDelete, Route("SoftDeleteBankAccountById")]
        public IHttpActionResult SoftDeleteBankAccountById(int Id)
        {
            db.SoftDeleteBankAccountById(Id);
            db.SoftDeleteBudgetByBankAccount(Id);
            db.SoftDeleteBudgetItemsByBankAccount(Id);
            db.SoftDeleteTransactionByBankAccount(Id);

            return Ok();
        }
        #endregion
    }
}
