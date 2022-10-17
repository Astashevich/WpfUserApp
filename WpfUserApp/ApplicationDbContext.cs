using System.Data.Entity;

namespace WpfUserApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
    }
}
