using Blog.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Db.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(400);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(800);
            builder.HasOne(p=>p.User).WithMany(u=>u.Posts);
            builder.HasOne(p => p.Category).WithMany(c=>c.Posts);
            builder.HasMany(p=>p.Comments).WithOne(c=>c.Post).HasForeignKey(p=>p.PostId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
