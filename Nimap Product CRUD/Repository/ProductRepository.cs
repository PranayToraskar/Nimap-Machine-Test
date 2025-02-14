using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nimap_Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap_Product_CRUD.Repository
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

        public async Task<Product> ProductDropDown()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProductDropDown", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    IDataReader data = await command.ExecuteReaderAsync();

                    Product product = new Product();

                    while (data.Read())
                    {
                        product.CategoryList.Add(new DropDownSource(data));

                    }
                    return product;
                }
            }
        }

        //Save and Edit both are using Same method
        public async Task<int> SaveProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SaveProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));
                    command.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                    command.Parameters.Add(new SqlParameter("@CategoryID", product.CategoryID));

                    return await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task<Product> ViewProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ViewProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ProductID", productId));
                    IDataReader data = await command.ExecuteReaderAsync();

                    Product product = new Product();

                    while (data.Read())
                    {
                        product = new Product(data);
                        
                    }
                    return product;
                }
            }
        }

        public async Task<int> DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeleteProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ProductID", productId));
                    return await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task<List<Product>> ProductList(DataParameterList dataParameter)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ProductList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Start", dataParameter.Start));
                    command.Parameters.Add(new SqlParameter("@Length", dataParameter.Length));
                    command.Parameters.Add(new SqlParameter("@Search", dataParameter.Search));
                    command.Parameters.Add(new SqlParameter("@SortColumn", dataParameter.SortColumn));
                    command.Parameters.Add(new SqlParameter("@SortDir", dataParameter.SortDir));

                    IDataReader data = await command.ExecuteReaderAsync();

                    List<Product> productList = new List<Product>();

                    while (data.Read())
                    {
                        productList.Add(new Product(data,true));

                    }
                    return productList;
                }
            }
        }

        public async Task<int> ValProduct(string productName, int categoryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ValProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ProductName", productName));
                    command.Parameters.Add(new SqlParameter("@CategoryID", categoryID));
                    IDataReader data = await command.ExecuteReaderAsync();
                    int record = 0;
                    while (data.Read())
                    {
                        record = Convert.ToInt32(data.GetValue(0));

                    }
                    return record;
                }
            }
        }
    }
}
