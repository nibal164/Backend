namespace SoapLush.Models
{
    public class Category
    {
        public int id { get; set; }  //primary key
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string SubCategories { get; set; } = string.Empty;
        
        //navigation properties
        public IEnumerable<Product>? Products { get; set; } //collection navigation
        public IEnumerable<SubCategory>? subCategories { get; set;} //collection navigation
    }
}
