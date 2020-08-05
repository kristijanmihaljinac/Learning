using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EasyBlog.Common
{
    public class PreSubmissionCommentEventArgs : CancelEventArgs
    {
        public PreSubmissionCommentEventArgs(BlogComment blogComment)
        {
            BlogComment = blogComment;
            CommentReplacement = String.Empty;
        }

        public BlogComment BlogComment { get; set; }
        public string CommentReplacement { get; set; }
    }
}
