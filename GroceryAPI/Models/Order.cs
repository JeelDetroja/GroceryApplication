using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal GrandTotal { get; set; }
        public bool isDelivered { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public virtual User User { get; set; }
    }
}
