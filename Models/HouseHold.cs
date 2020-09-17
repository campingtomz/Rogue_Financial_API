using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.Models
{
    ///<summary>
    ///HouseHold
    ///</summary>
    public class HouseHold
    {  
        ///<summary>
       ///Guid of the HouseHold
       ///</summary>
        public int Id { get; set; }
        ///<summary>
        ///Owner Id of the Household. The current Head
        ///</summary>
        public string OwnerId { get; set; }
        ///<summary>
        ///HouseHold Name
        ///</summary>
        public string HouseHoldName { get; set; }
        ///<summary>
        ///Household Greeting for when sending an Invitation 
        ///</summary>
        public string Greeting { get; set; }
        ///<summary>
        /// HouseHold Created Data
        ///</summary>
        public DateTime Created { get; set; }
        ///<summary>
        ///Bool for if the HouseHold is deleted
        ///</summary>
        public bool IsDeleted { get; set; }


    }
}