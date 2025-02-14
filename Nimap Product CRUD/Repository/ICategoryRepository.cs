using Nimap_Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap_Product_CRUD.Repository
{
    public interface ICategoryRepository
    {
        //Save and Edit both are using Same method
        public Task<int> SaveCategory(Category category);
        public Task<Category> ViewCategory(int categoryId);
        public Task<int> DeleteCategory(int categoryId);
        public Task<List<Category>> CategoryList(DataParameterList dataParameter);
        Task<int> ValCategory(string categoryName);
    }
}
