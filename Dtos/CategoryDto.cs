using SoapLush.Models;

namespace SoapLush.Dtos
{
    public class CategoryDto
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string SubCategories { get; set; } = string.Empty;
    }
}
