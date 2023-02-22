using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class ProductForUpdateDto : ProductForManipulationDto
    {
        public override string Description { get => base.Description; set => base.Description = value; }
        
        public override int? Discount { get => base.Discount; set => base.Discount = value; }

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
