using EasyBlog.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EasyBlog.Extensions
{
    public class AdminCommunicationModule : IEasyBlogModule
    {
        void IEasyBlogModule.Initialize(ModuleEvents moduleEvents)
        {
            moduleEvents.PreSubmissionComment += OnPreSubmissionComment;
        }

        void OnPreSubmissionComment(PreSubmissionCommentEventArgs e)
        {
            // read email configuration from the config file
            if (e.BlogComment.CommentBody != e.CommentReplacement)
            {
                // send email with comment info, including replacement comment
                Trace.WriteLine(
                    string.Format("Posting alert: Comment '{0}' was replaced with '{1}'.", e.BlogComment.CommentBody, e.CommentReplacement));
            }
            else
            {
                // send email with comment info, including replacement comment
                System.Diagnostics.Debug.WriteLine(
                    string.Format("Posting info: Comment '{0}' was posted as-is'.", e.BlogComment.CommentBody));
            }
        }
    }
}
