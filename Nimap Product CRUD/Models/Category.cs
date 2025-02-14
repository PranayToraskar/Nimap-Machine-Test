using System.Data;

namespace Nimap_Product_CRUD.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool InActive { get; set; }
        public string InActiveText { get; set; }
        public int TotalCount { get; set; }

        public Category()
        {
         
        }

        public Category(IDataReader dr,bool isList=false)
        {
            if (isList)
            {
                PopulateObjectList(this, dr);
            }
            else
            {
                PopulateObject(this, dr);
            }
        }

        public Category PopulateObject(Category category, IDataReader dr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryID"])))
            {
                category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryName"])))
            {
                category.CategoryName = Convert.ToString(dr["CategoryName"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["InActive"])))
            {
                category.InActive = Convert.ToBoolean(dr["InActive"]);
            }
            return category;
        }


        public Category PopulateObjectList(Category category, IDataReader dr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryID"])))
            {
                category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryName"])))
            {
                category.CategoryName = Convert.ToString(dr["CategoryName"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["InActiveText"])))
            {
                category.InActiveText = Convert.ToString(dr["InActiveText"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["TotalCount"])))
            {
                category.TotalCount = Convert.ToInt32(dr["TotalCount"]);
            }
            return category;
        }

    }
}
