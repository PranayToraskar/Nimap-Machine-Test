using Microsoft.Extensions.Configuration;
using Nimap_Product_CRUD.Models;
using System.Da
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly IConfiguration _configuration;
        private string connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Con");
        }

        public Task<int> SaveProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
            }
        }

        public Task<int> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> EditProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> ProductDropDown()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> ProductList()
        {
            throw new NotImplementedException();
        }


    }
}
