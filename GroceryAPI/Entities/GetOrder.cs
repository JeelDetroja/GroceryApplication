using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class GetOrder
    {
        public GetOrder(Order model)
        {
            OrderId = model.OrderId;
            CustomerName = model.User.UserName;
            CustomerId = model.CustomerId;
            GrandTotal = model.GrandTotal;
            isDelivered = model.isDelivered;
            OrderDate = model.OrderDate;
            DeliveredDate = model.DeliveredDate;
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
        public decimal GrandTotal { get; set; }
        public bool isDelivered { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        //public virtual User User { get; set; }

    }
}
