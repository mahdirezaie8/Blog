using Blog.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Db.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(500);
            builder.HasOne(c=>c.User).WithMany(u=>u.Categories).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.Posts).WithOne(p=>p.Category).HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
