using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class UserTypes
    {
        public UserTypes()
        {
            JdTblUser = new HashSet<User>();
        }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActivated { get; set; }

        public virtual ICollection<User> JdTblUser { get; set; }
    }
}
