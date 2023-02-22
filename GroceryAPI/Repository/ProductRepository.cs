using GroceryAPI.Entities;
using GroceryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.JdTblProduct.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.JdTblProduct.Remove(product);
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _context.JdTblProduct.Include(e => e.ProductCategory).Where(e => e.IsActivated && e.ProductId == productId).FirstOrDefaultAsync();
        }

        public int GetProductByName(string Name)
        {
            return  _context.JdTblProduct.Where(e => e.IsActivated && e.ProductName == Name).Count();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.JdTblProduct.Include(e => e.ProductCategory).Where(e => e.IsActivated).OrderBy(c => c.ProductName).ToListAsync();      
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product product)
        {
            //any code
        }
    }
}
