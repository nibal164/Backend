namespace SoapLush.InputModels
{
    public class CreateCategoryInputModel
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string SubCategories { get; set; } = string.Empty;
    }
}
