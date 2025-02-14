using Microsoft.Data.SqlClient;
using Nimap_Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap_Product_CRUD.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly IConfiguration _configuration;
        private string connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Con");
        }
        //Save and Edit both are using Same method
        public async Task<int> SaveCategory(Category category)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SaveCategory", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CategoryID", category.CategoryID));
                        command.Parameters.Add(new SqlParameter("@CategoryName", category.CategoryName));
                        command.Parameters.Add(new SqlParameter("@InActive", category.InActive));

                        return await command.ExecuteNonQueryAsync();

                    }
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public async Task<Category> ViewCategory(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ViewCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CategoryID", categoryId));
                    IDataReader data = await command.ExecuteReaderAsync();

                    Category category = new Category();

                    while (data.Read())
                    {
                        category = new Category(data);

                    }
                    return category;
                }
            }
        }
       
        public async Task<int> DeleteCategory(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeleteCategory", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CategoryID", categoryId));
                    return await command.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task<List<Category>> CategoryList(DataParameterList dataParameter)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CategoryList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Start", dataParameter.Start));
                    command.Parameters.Add(new SqlParameter("@Length", dataParameter.Length));
                    command.Parameters.Add(new SqlParameter("@Search", dataParameter.Search));
                    command.Parameters.Add(new SqlParameter("@SortColumn", dataParameter.SortColumn));
                    command.Parameters.Add(new SqlParameter("@SortDir", dataParameter.SortDir));
                    IDataReader data = await command.ExecuteReaderAsync();

                    List<Category> categoryList = new List<Category>();

                    while (data.Read())
                    {
                        categoryList.Add(new Category(data,true));

                    }
                    return categoryList;
                }
            }
        }

        public async Task<int> ValCategory(string categoryName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ValCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CategoryName", categoryName));
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
