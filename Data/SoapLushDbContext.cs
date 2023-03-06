using Microsoft.EntityFrameworkCore;
using SoapLush.Models;

namespace SoapLush.Data
{
    public class SoapLushDbContext: DbContext
    {
        public SoapLushDbContext(DbContextOptions<SoapLushDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}
