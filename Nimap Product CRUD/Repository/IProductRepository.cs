using Nimap_Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap_Product_CRUD.Repository
{
    public interface IProductRepository
    {
        public Task<Product> ProductDropDown();
        //Save and Edit both are using Same method
        public Task<int> SaveProduct(Product product);
        public Task<Product> ViewProduct(int productId);
        public Task<int> DeleteProduct(int productId);
        public Task<List<Product>> ProductList(DataParameterList dataParameter);
        Task<int> ValProduct(string productName, int categoryID);
    }
}
