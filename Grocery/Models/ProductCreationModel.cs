using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class ProductCreationModel
    {
        [Key]
        [Display(Name = "Category")]
        public int ProductCategoryId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name must be fewer than 100 characters.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Range(0.01, 100000, ErrorMessage = "Product Price is required between .01 and ₹100,000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }
        [Range(0, 100)]
        [Display(Name = "Discount in (%)")]
        public virtual int? Discount { get; set; }
        //[Required]
        [StringLength(500, ErrorMessage = "PhotoPath must be fewer than 500 characters.")]
        public string ProductPhotoPath { get; set; }
        [StringLength(500, ErrorMessage = "Discription must be fewer than 500 characters.")]
        public virtual string Description { get; set; }
        //public virtual DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        public int CreatedBy { get; set; }
        //public virtual DateTime UpdatedOn { get; set; } = DateTime.Now;
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public bool isActivated { get; set; }
    }
}
