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
    /// BudgetItems Controller
    ///</summary>
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        #region json
        ///<summary>
        ///Gets all of the columns for a single Budget Item record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Budget Item</param> 
        [Route("GetBudgetItemDataById/json")]
        public async Task<IHttpActionResult> GetBudgetItemDataByIdJson(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItemDataById(Id));
            return Ok(json);
        }
        ///<summary>
        ///Gets all of the Budget Item records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllBudgetItemData/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemDataJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetItemData(hhId));
            return Ok(json);
        }
        #endregion
        #region XML
        ///<summary>
        ///Gets all of the columns for a single Budget Item record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Budget Item</param>
        [Route("GetBudgetItemDataById")]
        public async Task<BudgetItem> GetBudgetItemDataById(int Id)

        {
            return await db.GetBudgetItemDataById(Id);
        }
        ///<summary>
        ///Gets all of the Budget Item records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData(int hhId)
        {
            return await db.GetAllBudgetItemData(hhId);

        }
        #endregion
        #region insert/add/create budgetItem
        /// <summary>
        /// create a new Budget Item and add it to the Database
        /// </summary>   
        /// /// <param name="HouseHoldId">FK of HouseHold</param>
        /// <param name="OwnerId">Guid of user</param>
        /// <param name="BudgetId">FK of The Budget</param>      
        /// <param name="ItemName">Name of the Budget Item </param>
        /// <param name="Description">Description of the BudgetItem </param>
        /// <param name="TargetAmount">Target Amount or Limit of spending </param>

        /// <returns></returns>
        [HttpPost, Route("CreateBudgetItem")]
        public IHttpActionResult CreateBudgetItem(int HouseHoldId, string OwnerId, int BudgetId, string ItemName, string Description, decimal TargetAmount)
        {
            return Ok(db.CreateBudgetItem(HouseHoldId, OwnerId, BudgetId, ItemName, Description, TargetAmount));
        }

        #endregion
        #region Update UpdateBudgetItem
        /// <summary>
        ///  updates the Budget by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Budget Item</param>
        /// <param name="BudgetId">FK of Budget</param>      
        /// <param name="ItemName">Name of the BudgetItem </param>
        /// <param name="Description">Description of the Budget Item</param>
        /// <param name="TargetAmount">Target Amount or Limit of spending </param>
        /// <param name="IsDeleted">Bool used for softDelete </param>
        /// <returns></returns>
        [HttpPost, Route("UpdateBudgetItem")]
        public IHttpActionResult UpdateBudgetItem(int Id, int BudgetId, string ItemName, string Description, decimal TargetAmount, int IsDeleted)
        {
            return Ok(db.UpdateBudgetItem(Id, BudgetId, ItemName, Description, TargetAmount, IsDeleted));
        }
        #endregion
        #region delete Budget Item
        /// <summary>
        ///  deletes the BudgetItem by its Guid
        /// </summary>   
        /// <param name="Id">Guid of Budget</param>

        /// <returns></returns>
        [HttpPost, Route("DeleteBudgetItemById")]
        public IHttpActionResult DeleteBudgetdById(int Id)
        {
            return Ok(db.DeleteBudgetById(Id));
        }
        /// <summary>
        /// Soft Deletes the BudgetItem by its Guid. Sets the IsDeleted field to true
        /// </summary>   
        /// <param name="Id">Guid of Budget</param>

        /// <returns></returns>
        [HttpPost, Route("SoftBudgetDeleteItemById")]
        public IHttpActionResult SoftBudgetItemDeleteById(int Id)
        {
            return Ok(db.SoftBudgetItemDeleteById(Id));
        }
        #endregion
    }
}
