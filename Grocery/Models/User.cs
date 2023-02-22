using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class User
    {
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

        //public virtual UserTypes UserType { get; set; }
    }
}
