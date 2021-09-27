using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    // TODO: Probably have to Update-Database
    public class ApplicationContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Link.db");
        }
    }
}
