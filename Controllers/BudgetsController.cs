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
    ///
    ///</summary>
    [RoutePrefix("api/Budgets")]
    public class BudgetsController : ApiController
    {    
        private ApiDbContext db = new ApiDbContext();
        #region Json
        ///<summary>
        ///Gets all of the columns for a single Budget record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Budget</param> 
        [Route("GetBudgetDataById/json")]
        public async Task<IHttpActionResult> GetBudgetDataByIdJson(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetDataById(Id));
            return Ok(json);
        }
        ///<summary>
        ///Gets all of the Budget records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllBudgetData/json")]
        public async Task<IHttpActionResult> GetAllBudgetDataJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetData(hhId));
            return Ok(json);
        }
        #endregion
        #region XML
        ///<summary>
        ///Gets all of the columns for a single Budget record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Budget</param> 
        [Route("GetBudgetDataById")]
        public async Task<Budget> GetBudgetDataById(int Id)

        {
            return await db.GetBudgetDataById(Id);
        }
        ///<summary>
        ///Gets all of the Budget records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData(int hhId)
        {
            return await db.GetAllBudgetData(hhId);

        }
        #endregion
        #region insert/add/create budget
        /// <summary>
        /// create a new Budget and add it to the Database
        /// </summary>   
        /// <param name="HouseHoldId">FK of HouseHold</param>
        /// <param name="OwnerId">Guid of user</param>
        /// <param name="BankAccontId">FK of Bank Account</param>      
        /// <param name="BudgetName">Name of the budget </param>
        /// <param name="Description">Description of the Budget</param>
        /// <returns></returns>
        [HttpPost, Route("CreateBudget")]
        public IHttpActionResult CreateBudget(int HouseHoldId, string OwnerId, int BankAccontId, string BudgetName, string Description)
        {
            return Ok(db.CreateBudget(HouseHoldId, OwnerId, BankAccontId, BudgetName, Description));
        }

        #endregion

        #region Update Budget
        /// <summary>
        ///  updates the Budget by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Budget</param>
        /// <param name="BankAccontId">FK of Bank Account</param>      
        /// <param name="BudgetName">Name of the budget </param>
        /// <param name="Description">Description of the Budget</param>
        /// <param name="IsDeleted">Bool used for softDelete </param>
        /// <returns></returns>
        [HttpPost, Route("UpdateBudget")]
        public IHttpActionResult UpdateBudget(int Id, int BankAccontId, string BudgetName, string Description, int IsDeleted)
        {
            return Ok(db.UpdateBudget(Id, BankAccontId, BudgetName, Description, IsDeleted));
        }
        #endregion
        #region delete Budget
        /// <summary>
        ///  deletes the Budget by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Budget</param>
       
        /// <returns></returns>
        [HttpPost, Route("DeleteBudgetById")]
        public IHttpActionResult DeleteBudgetdById(int Id)
        {
            return Ok(db.DeleteBudgetById(Id));
        }
        /// <summary>
        /// Soft Deletes the Budget by its Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of Budget</param>

        /// <returns></returns>
        [HttpPost, Route("SoftBudgetDeleteById")]
        public IHttpActionResult SoftBudgetDeleteById(int Id)
        {
            return Ok(db.SoftBudgetDeleteById(Id));
        }
        #endregion
    }
}
