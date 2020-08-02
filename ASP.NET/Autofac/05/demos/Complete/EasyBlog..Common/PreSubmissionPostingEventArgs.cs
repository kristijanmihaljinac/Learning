using EasyBlog.Support.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EasyBlog.Common
{
    public class PreSubmissionPostingEventArgs : CancelEventArgs
    {
        public PreSubmissionPostingEventArgs(BlogPost blogPost)
        {
            BlogPost = blogPost;
        }

        public BlogPost BlogPost { get; set; }
    }
}
