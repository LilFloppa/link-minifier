using LinkShortener.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data
{
    // TODO: Probably have to Update-Database
    public class ApplicationContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Link.db");
        }
    }
}
