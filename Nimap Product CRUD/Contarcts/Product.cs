namespace Nimap_Product_CRUD.Contarcts
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<DropDownSource> CategoryList { get; set; }

        public int TotalCount { get; set; }

        public Product()
        {
            CategoryList = new List<DropDownSource>();
        }
    }
}
