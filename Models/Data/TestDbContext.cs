using Microsoft.EntityFrameworkCore;
using TEST.Models.Data.Configuration;

namespace TEST.Models.Data
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        public DbSet<TestUser> Users { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            :base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
