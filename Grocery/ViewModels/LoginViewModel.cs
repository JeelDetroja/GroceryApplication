using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class LoginViewModel
    {
        #region Email
        [Required(ErrorMessage = "Enter Username")]
        [DataType(DataType.EmailAddress)]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Login Name")]
        public string Email { get; set; }
        #endregion Email

        #region Password
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Invalid login attempt", MinimumLength = 8)]
        public string Password { get; set; }
        #endregion Password
    }
}
