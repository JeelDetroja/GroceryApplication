using System;
using System.Collections.Generic;

namespace GroceryAPI.Models
{
    public partial class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActivated { get; set; }

        public virtual User CreationByNavigation { get; set; }
        public virtual User UpdationByNavigation { get; set; }
    }
}
