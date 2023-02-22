using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class UserForCreateDto
    {
        [Required]
        public int UserTypeId { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string UserEmail { get; set; }
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string UserMobileNo { get; set; }
        public DateTime UserDOB { get; set; }
        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public bool isActivated { get; set; }
    }
}
