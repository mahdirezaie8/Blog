using Blog.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Db.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c=>c.Text).IsRequired().HasMaxLength(500);
            builder.HasOne(c => c.User).WithMany(u => u.Comments);
            builder.HasOne(c => c.Post).WithMany(p => p.Comments);
        }
    }
}
