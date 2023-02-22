using GroceryAPI.Entities;
using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Repository
{
    public interface ICartRepository
    {
        //int GetItemById(int productId);
        void AddCartItem(AddCartItem model);
        void AddOrder(Order model);
        Task<List<CartItem>> GetProducts(int userId);
        Task<CartItem> GetProduct(int id);
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int OrderId);
        void DeleteProduct(CartItem cartItem);
        void DeleteProduct(List<CartItem > cartItem);
        bool Save();
    }
}
