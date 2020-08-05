using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Common
{
    public class PostSubmissionPostingEventArgs : EventArgs
    {
        public PostSubmissionPostingEventArgs(BlogPost blogPost)
        {
            BlogPost = blogPost;
        }

        public BlogPost BlogPost { get; set; }
    }
}
