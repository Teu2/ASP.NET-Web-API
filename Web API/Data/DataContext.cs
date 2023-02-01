using Microsoft.EntityFrameworkCore;

namespace Web_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Web_API.Models.Mangas> MangasManhwas { get; set; } // name of table in database

    }
}
