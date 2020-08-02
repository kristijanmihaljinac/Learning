using EasyBlog.Core;
using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EasyBlog.Data
{
    public class EasyBlogDbContext : DbContext
    {
        public EasyBlogDbContext()
            : base("name=easyBlog")
        {
            //Database.SetInitializer<EasyBlogDbContext>(null);
        }

        public EasyBlogDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            //Database.SetInitializer<EasyBlogDbContext>(null);
        }

        public DbSet<BlogPost> BlogPostSet { get; set; }
        public DbSet<BlogComment> BlogCommentSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<BlogPost>().HasKey(e => e.BlogPostId).Ignore(e => e.EntityId);
            modelBuilder.Entity<BlogComment>().HasKey(e => e.BlogCommentId).Ignore(e => e.EntityId);

            modelBuilder.Entity<BlogPost>().HasMany<BlogComment>(e => e.Comments).WithRequired(e => e.BlogPost).HasForeignKey(e => e.BlogPostId);
        }
    }
}
