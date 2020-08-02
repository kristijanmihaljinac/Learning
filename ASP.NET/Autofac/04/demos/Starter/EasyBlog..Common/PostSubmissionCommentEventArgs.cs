using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Common
{
    public class PostSubmissionCommentEventArgs : EventArgs
    {
        public PostSubmissionCommentEventArgs(BlogComment blogComment)
        {
            BlogComment = blogComment;
        }

        public BlogComment BlogComment { get; set; }
    }
}
