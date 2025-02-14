using System.Data;

namespace Nimap_Product_CRUD.Models
{
    public class DropDownSource
    { 
        public string Value { get; set; }
        public string Text { get; set; }
       
        public DropDownSource(IDataReader data)
        {
            PopulateObject(this, data);
        }
        public DropDownSource PopulateObject(DropDownSource DropDownSource, IDataReader dr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dr["Value"])))
            {
                DropDownSource.Value = Convert.ToString(dr["Value"]);
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dr["Text"])))
            {
                DropDownSource.Text = Convert.ToString(dr["Text"]);
            }

            return DropDownSource;
        }

    }
}
