using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using EasyBlog.Core;

namespace EasyBlog.Data
{
    public class BlogPostRepository : DataRepositoryBase<BlogPost, EasyBlogDbContext>, IBlogPostRepository
    {
        public BlogPostRepository(string connectionStringName)
            : base(connectionStringName)
        {
        }

        protected override DbSet<BlogPost> DbSet(EasyBlogDbContext entityContext)
        {
            return entityContext.BlogPostSet;
        }

        protected override Expression<Func<BlogPost, bool>> IdentifierPredicate(EasyBlogDbContext entityContext, int id)
        {
            return (e => e.BlogPostId == id);
        }

        public BlogPost GetComplete(int blogPostId)
        {
            using (EasyBlogDbContext entityContext = new EasyBlogDbContext())
            {
                return entityContext.BlogPostSet
                    .Include(e => e.Comments)
                    .FirstOrDefault(e => e.BlogPostId == blogPostId);
            }
        }
    }
}
