using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.ViewModels
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool isActivated { get; set; }

        public virtual Product Product { get; set; }

        //public virtual User CreatedByNavigation { get; set; }
        //public virtual User UpdatedByNavigation { get; set; }
    }
}
