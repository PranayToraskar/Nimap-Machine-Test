namespace Nimap_Product_CRUD.Contarcts
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
    }
}
