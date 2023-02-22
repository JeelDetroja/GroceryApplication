using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int? Discount { get; set; }
        public decimal Price { get; set; }
        public string ProductPhotoPath { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool isActivated { get; set; }
    }
}
