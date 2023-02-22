using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class UserForCreationDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserMobileNo { get; set; }
        [Required]
        public DateTime? UserDob { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool isActivated { get; set; }
    }
}
