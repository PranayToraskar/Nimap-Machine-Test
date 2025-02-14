using Nimap_Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        public Task<Product> ProductDropDown();
        public Task<int> SaveProduct(Product product);
        public Task<Product> EditProduct(int productId);
        public Task<int> DeleteProduct(int productId);
        public Task<List<Product>> ProductList();
    }
}
