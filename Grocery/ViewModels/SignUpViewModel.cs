using Grocery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.ViewModels
{
    public class SignUpViewModel : SignUp
    {
        [Required, DataType(DataType.Password)]
        [Compare("UserPassword")]
        public string ConfirmPassword { get; set; }
    }
}
