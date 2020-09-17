using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rogue_Financial_API.Models
{
    ///<summary>
    ///Member
    ///</summary>
    public class Member
    {
        ///<summary>
        ///Id of Member
        ///</summary>
        public string Id { get; set; }
        ///<summary>
        ///First Name
        ///</summary>
        public string FirstName { get; set; }
        ///<summary>
        ///Last Name
        ///</summary>
        public string LastName { get; set; }
        ///<summary>
        ///User Name
        ///</summary>
        public string UserName { get; set; }
        ///<summary>
        ///Email Address
        ///</summary>
        public string Email { get; set; }
        ///<summary>
        ///Full Name
        ///</summary>
        public string FullName { get; set; }
        ///<summary>
        ///Description
        ///</summary>
        public string Description { get; set; }
        ///<summary>
        ///Avatar Path
        ///</summary>
        public string AvatarPath { get; set; }
        ///<summary>
        ///Phone Number
        ///</summary>
        public string PhoneNumber { get; set; }
        ///<summary>
        ///HouseHold Id
        ///</summary>
        public int? HouseHoldId { get; set; }
    }
}