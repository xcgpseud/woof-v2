using Application.App.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.App.Database
{
    public class SqliteContext : DbContext
    {
        public DbSet<TestEntity> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=woof.db");
        }
    }
}