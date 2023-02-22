using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class UserDto
    {
        public UserDto(User x)
        {
            UserId = x.UserId;
            UserTypeId = x.UserTypeId;
            UserName = x.UserName;
            UserEmail = x.UserEmail;
            UserMobileNo = x.UserMobileNo;
            UserDob = x.UserDob;
            UserPassword = x.UserPassword;
            CreatedOn = x.CreatedOn;
            CreatedBy = x.CreatedBy;
            UpdatedOn = x.UpdatedOn;
            UpdatedBy = x.UpdatedBy;
            IsActivated = x.IsActivated;
        }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobileNo { get; set; }
        public DateTime? UserDob { get; set; }
        public string UserPassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActivated { get; set; }

    }
}
