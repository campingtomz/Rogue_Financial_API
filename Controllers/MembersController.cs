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
    /// Members Controller
    ///</summary>
    public class MembersController : ApiController
    {
       
        private ApiDbContext db = new ApiDbContext();
        #region json
        ///<summary>
        ///Gets all of the columns for a single Member record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Member</param>
        [Route("GetHouseholdMemberById/json")]
        public async Task<IHttpActionResult> GetHouseholdMemberByIdJson(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetHouseholdMemberById(Id));
            return Ok(json);
        }
        ///<summary>
        ///Gets all of the Member records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetHouseholdMembers/json")]
        public async Task<IHttpActionResult> GetHouseholdMembersJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHouseholdMembers(hhId));
            return Ok(json);
        }
        #endregion
        #region XML
        ///<summary>
        ///Gets all of the columns for a single Member record, based on the PK specified 
        ///</summary>        
        ///<param name="Id">The PK of the Member</param>
        [Route("GetHouseholdMemberById")]
        public async Task<Member> GetHouseholdMemberById(int Id)

        {
            return await db.GetHouseholdMemberById(Id);
        }
        ///<summary>
        ///Gets all of the Member records, based on the HouseHold PK specified 
        ///</summary>        
        ///<param name="hhId">The PK of the HouseHold</param>
        [Route("GetHouseholdMembers")]
        public async Task<List<Member>> GetHouseholdMembers(int hhId)
        {
            return await db.GetHouseholdMembers(hhId);

        }
        #endregion
    }
}
