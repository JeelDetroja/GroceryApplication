using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class AddCartItem
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public bool isActivated { get; set; }
    }
}
