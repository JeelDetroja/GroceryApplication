using GroceryAPI.Entities;
using System;
using System.Collections.Generic;

namespace GroceryAPI.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int? Discount { get; set; }
        public string ProductPhotoPath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActivated { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
