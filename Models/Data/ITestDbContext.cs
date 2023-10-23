using Microsoft.EntityFrameworkCore;

namespace TEST.Models.Data
{
    public interface ITestDbContext
    {
        DbSet<TestUser> Users { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
