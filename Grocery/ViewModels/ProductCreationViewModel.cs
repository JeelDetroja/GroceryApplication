using Grocery.CustomValidation;
using Grocery.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.ViewModels
{
    public class ProductCreationViewModel : ProductCreationModel
    {
        [Required(ErrorMessage = "please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSizeAttribute(5 * 1024 * 1024)]
        [AllowedExtensionsAttribute(new string[] { ".jpg", ".png", ".jfif" })]
        public IFormFile Photo { get; set; }
    }
}
