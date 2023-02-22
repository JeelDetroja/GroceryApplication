using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class ProductDto
    {
        public ProductDto(Product x)
        {
            ProductId = x.ProductId;
            ProductCategoryName = x.ProductCategory.ProductCategoryName.ToString();
            ProductName = x.ProductName;
            ProductPrice = x.ProductPrice;
            Discount = x.Discount;
            Price = (decimal)(x.Discount.HasValue ? (x.ProductPrice - ((x.ProductPrice * x.Discount) / 100)) : x.ProductPrice);
            ProductPhotoPath = x.ProductPhotoPath;
            Description = x.Description;
            CreatedBy = x.CreatedBy;
            UpdatedBy = x.UpdatedBy;
            isActivated = x.IsActivated;
        }
        public int ProductId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int? Discount { get; set; }
        public decimal Price { get; set; }
        public string ProductPhotoPath { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool isActivated { get; set; }

    }
}
