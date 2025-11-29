using Blog.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Db.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.Username).IsRequired().HasMaxLength(300);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(300);
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(300);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(250);
            builder.Property(u => u.PhoneNumber).HasMaxLength(15);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasMany(u=>u.Categories).WithOne(c => c.User).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
