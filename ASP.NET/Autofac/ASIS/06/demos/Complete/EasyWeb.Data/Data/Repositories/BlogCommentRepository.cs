using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using EasyBlog.Core;

namespace EasyBlog.Data
{
    public class BlogCommentRepository : DataRepositoryBase<BlogComment, EasyBlogDbContext>, IBlogCommentRepository
    {
        public BlogCommentRepository(string connectionStringName)
            : base(connectionStringName)
        {
        }

        protected override DbSet<BlogComment> DbSet(EasyBlogDbContext entityContext)
        {
            return entityContext.BlogCommentSet;
        }

        protected override Expression<Func<BlogComment, bool>> IdentifierPredicate(EasyBlogDbContext entityContext, int id)
        {
            return (e => e.BlogCommentId == id);
        }
    }
}
