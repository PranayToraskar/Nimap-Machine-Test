using System.Data;

namespace Nimap_Product_CRUD.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<DropDownSource> CategoryList {get; set;}
        public int TotalCount { get; set; }
        public Product()
        {
            CategoryList = new List<DropDownSource>();
        }

        public Product(IDataReader dr,bool isList = false)
        {
            CategoryList = new List<DropDownSource>();
            if (isList)
            {
                PopulateObjectList(this,dr);
            }
            else
            {
                PopulateObject(this,dr);
            }
        }

        public Product PopulateObject(Product product,IDataReader dr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dr["ProductID"])))
            {
                product.ProductID = Convert.ToInt32(dr["ProductID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["ProductName"])))
            {
                product.ProductName = Convert.ToString(dr["ProductName"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryID"])))
            {
                product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            }
            return product;
        }

        public Product PopulateObjectList(Product product, IDataReader dr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dr["ProductID"])))
            {
                product.ProductID = Convert.ToInt32(dr["ProductID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["ProductName"])))
            {
                product.ProductName = Convert.ToString(dr["ProductName"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryID"])))
            {
                product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["CategoryName"])))
            {
                product.CategoryName = Convert.ToString(dr["CategoryName"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["TotalCount"])))
            {
                product.TotalCount = Convert.ToInt32(dr["TotalCount"]);
            }
            return product;
        }
    }
}
