using EasyBlog.Core;
using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Data
{
    public interface IBlogPostRepository : IDataRepository<BlogPost>
    {
        BlogPost GetComplete(int blogPostId);
    }
}
