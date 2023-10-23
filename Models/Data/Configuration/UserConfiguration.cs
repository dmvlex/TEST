using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TEST.Models;

namespace TEST.Models.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<TestUser>
    {
        public void Configure(EntityTypeBuilder<TestUser> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Username).IsUnique();
        }
    }
}
