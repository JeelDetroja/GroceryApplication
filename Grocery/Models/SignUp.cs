using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string UserEmail { get; set; }
        [Required]
        [Display(Name = "User Mobile No")]
        public string UserMobileNo { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime? UserDob { get; set; }
        [Required, DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool isActivated { get; set; }
    }
}
