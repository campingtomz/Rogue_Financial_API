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
    ///HouseHold Controller
    ///</summary>
    [RoutePrefix("api/HouseHolds")]
    
    public class HouseHoldsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        ///<summary>
        ///Gets all of the columns for a single HouseHold record, based on the PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        ///<returns>Id, OwnerId, HouseHoldName, Greeting, CreatedDate, IsDeleted</returns>
        [Route("GetHouseHoldDataById/json")]
        public async Task<IHttpActionResult> GetHouseholdDataByIdJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHouseholdDataById(hhId));
            return Ok(json);
        }

        ///<summary>
        ///Gets all of the columns for a single HouseHold record. As well as the Children of that HouseHold, based on the PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        ///<returns>Id, OwnerId, HouseHoldName, Greeting, CreatedDate, IsDeleted</returns>
        [Route("GetHouseholdAndChildData/json")]
        public async Task<IHttpActionResult> GetHouseholdAndChildDataJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHouseholdAndChildData(hhId));
            return Ok(json);
        }

        ///<summary>
        ///Gets all of the columns for a single HouseHold record, based on the PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        ///<returns>Id, OwnerId, HouseHoldName, Greeting, CreatedDate, IsDeleted</returns>
        [Route("GetHouseHoldDataById")]
        public async Task<HouseHold> GetHouseholdDataById(int hhId)
        {
            return await db.GetHouseholdDataById(hhId);
        }
        ///<summary>
        ///Gets all of the columns for a single HouseHold record, based on the PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        ///<returns>Id, OwnerId, HouseHoldName, Greeting, CreatedDate, IsDeleted</returns>
        [Route("GetHouseholdAndChildData")]
        public async Task<HouseHoldAndChildVM> GetHouseholdAndChildData(int hhId)
        {
             
            var householdData = await db.GetHouseholdDataById(hhId);
            var householdBankAccountsData = await db.GetAllBankData(hhId);
            var householdBudgetsData = await db.GetAllBudgetData(hhId);
            var householdBudgetItemsData = await db.GetAllBudgetItemData(hhId);
            var householdTransactiontsData = await db.GetAllTransactionData(hhId);
            var householdMembersData = await db.GetHouseholdMembers(hhId);

            var newHouseHoldAndChild = new HouseHoldAndChildVM()
            {
                HouseHold = householdData,
                BankAccounts = householdBankAccountsData,
                Budgets = householdBudgetsData,
                BudgetItems = householdBudgetItemsData,
                Transactions = householdTransactiontsData,
                Members = householdMembersData
            };

            return newHouseHoldAndChild;
        }
        #region insert/add/create HouseHold
        /// <summary>
        /// create a new HouseHold and add it to the Database
        /// </summary>   
        /// <param name="OwnerId">Guid of user</param>
        /// <param name="HouseHoldName">Name of the Budget Item </param>
        /// <param name="Greeting">Greeting sent to a Invitation </param>

        /// <returns></returns>
        [HttpPost, Route("CreateHouseHold")]
        public IHttpActionResult CreateHouseHold(string OwnerId, string HouseHoldName, string Greeting)
        {
            return Ok(db.CreateHouseHold(OwnerId, HouseHoldName, Greeting));
        }
        #endregion
        #region Update HouseHold
        /// <summary>
        ///  updates the HouseHold by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Household</param>
        /// <param name="OwnerId">Guid of user</param>
        /// <param name="HouseHoldName">Name of the Budget Item </param>
        /// <param name="Greeting">Greeting sent to a Invitation </param>    
        /// <param name="IsDeleted">Bool used for softDelete </param>
        /// <returns></returns>
        [HttpPost, Route("UpdateHouseHold")]
        public IHttpActionResult UpdateHouseHold(int Id, string OwnerId, string HouseHoldName, string Greeting, int IsDeleted)
        {
            return Ok(db.UpdateHouseHold(Id, OwnerId, HouseHoldName, Greeting, IsDeleted));
        }
        #endregion
        #region delete HouseHold
        /// <summary>
        ///  deletes the HouseHold by its Guid
        /// </summary>   
        /// <param name="Id">Guid of HouseHold</param>

        /// <returns></returns>
        [HttpDelete, Route("DeleteHouseHoldById")]
        public IHttpActionResult DeleteHouseHoldById(int Id)
        {
            return Ok(db.DeleteHouseHoldById(Id));
        }
        /// <summary>
        /// Soft Deletes the HouseHold by its Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="hhId">Guid of HouseHold</param>

        /// <returns></returns>
        [HttpDelete, Route("SoftDeleteHouseHoldById")]
        public IHttpActionResult SoftDeleteHouseHoldById(int hhId)
        {
            db.SoftDeleteHouseHoldById(hhId);
            db.SoftDeleteBankAccountsByHouseHold(hhId);
            db.SoftDeleteBudgetByHouseHold(hhId);
            db.SoftDeleteBudgetItemByHouseHold(hhId);
            db.SoftDeleteTransactionByHouseHold(hhId); 
            return Ok();
        }
        #endregion
    }
}
