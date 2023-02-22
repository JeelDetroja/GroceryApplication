using GroceryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
        int GetProductByName(string Name);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        bool Save();
    }
}
