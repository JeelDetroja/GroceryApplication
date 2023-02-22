using System;
using System.Collections.Generic;

namespace GroceryAPI.Models
{
    public partial class User
    {
        public User()
        {
            JdTblProductCategoryCreationByNavigation = new HashSet<ProductCategory>();
            JdTblProductCategoryUpdationByNavigation = new HashSet<ProductCategory>();
            JdTblProductCreatedByNavigation = new HashSet<Product>();
            JdTblProductUpdatedByNavigation = new HashSet<Product>();
            //JdTblCartItemCreatedByNavigation = new HashSet<CartItem>();
            //JdTblCartItemUpdatedByNavigation = new HashSet<CartItem>();
        }

        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobileNo { get; set; }
        public DateTime? UserDob { get; set; }
        public string UserPassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActivated { get; set; }

        public virtual UserTypes UserType { get; set; }
        public virtual ICollection<ProductCategory> JdTblProductCategoryCreationByNavigation { get; set; }
        public virtual ICollection<ProductCategory> JdTblProductCategoryUpdationByNavigation { get; set; }
        public virtual ICollection<Product> JdTblProductCreatedByNavigation { get; set; }
        public virtual ICollection<Product> JdTblProductUpdatedByNavigation { get; set; }

        public virtual ICollection<Order> FK_JD_tblOrder_JD_tblUser { get; set; }
        //public virtual ICollection<CartItem> JdTblCartItemUpdatedByNavigation { get; set; }

    }
}
