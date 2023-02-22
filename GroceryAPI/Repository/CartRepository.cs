using GroceryAPI.Entities;
using GroceryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        #region Privet Filds
        private readonly AppDbContext _context;
        #endregion Privet Filds

        #region Constructor
        public CartRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion Constructor

        #region Add Cart Item
        public void AddCartItem(AddCartItem model)
        {
            var newItem = new CartItem
            {
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                Subtotal = model.Subtotal,
                CreatedBy = model.CreatedBy,
                //CreatedOn = DateTime.Now,
                UpdatedBy = model.UpdatedBy,
                //UpdatedOn = DateTime.Now,
                isActivated = model.isActivated
            };

            _context.JdTblCartItem.Add(newItem);

            try
            {
                _context.SaveChanges();
            }
            //catch (DbUpdateException)
            //{
            //    throw new InvalidOperationException("Database Exception occurred while item added to cart");
            //}
            catch (Exception e)
            {
                string m = e.ToString();
                //throw new InvalidOperationException("Database Exception occurred while item added to cart");
            }
        }

        
        #endregion Add Cart Item

        #region Get Products

        public async Task<List<CartItem>> GetProducts(int userId)
        {
            return await _context.JdTblCartItem.Include(e => e.Product).Where(e => e.isActivated && e.CreatedBy == userId).ToListAsync();
        }
        #endregion Get Products

        #region Delete products
        public void DeleteProduct(CartItem cartItem)
        {
            _context.JdTblCartItem.Remove(cartItem);
        }
        #endregion Delete products

        #region get product
        public async Task<CartItem> GetProduct(int id)
        {
            return await _context.JdTblCartItem.Include(e => e.Product).Where(e => e.isActivated && e.CartItemId == id).FirstOrDefaultAsync();
        }
        #endregion get product

        #region save
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        #endregion save

        #region add order
        public void AddOrder(Order model)
        {
            
            _context.JdTblOrder.Add(model);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                string m = e.ToString();
            }
        }
        #endregion add order

        #region delete products
        public void DeleteProduct(List<CartItem> cartItem)
        {
            _context.JdTblCartItem.RemoveRange(cartItem);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                string m = e.ToString();
            }
        }
        #endregion delete products

        #region get orders
        public async Task<List<Order>> GetOrders()
        {
            return await _context.JdTblOrder.Include(e => e.User).ToListAsync();
        }

        public async Task<Order> GetOrder(int OrderId)
        {
            return await _context.JdTblOrder.Include(e => e.User).Where(e => e.OrderId == OrderId).FirstOrDefaultAsync();
        }
        #endregion get orders
    }
}
