using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Common
{
    public class ModuleEvents
    {
        public Action<PreSubmissionPostingEventArgs> PreSubmissionPosting { get; set; }
        public Action<PostSubmissionPostingEventArgs> PostSubmissionPosting { get; set; }
        public Action<PreSubmissionCommentEventArgs> PreSubmissionComment { get; set; }
        public Action<PostSubmissionCommentEventArgs> PostSubmissionComment { get; set; }
    }
}
