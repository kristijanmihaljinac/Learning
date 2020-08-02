using EasyBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Extensions
{
    public class ProfanityCheckerModule : IEasyBlogModule
    {
        public ProfanityCheckerModule()
        {
            _BadWords = new List<string>()
            {
                "filth",
                "flarn"
            };
        }

        string _ProfanityReplacement = "$#%$&$#";
        List<string> _BadWords;

        void IEasyBlogModule.Initialize(ModuleEvents moduleEvents)
        {
            moduleEvents.PreSubmissionPosting += OnPreSubmissionPosting;
            moduleEvents.PreSubmissionComment += OnPreSubmissionComment;
        }

        void OnPreSubmissionPosting(PreSubmissionPostingEventArgs e)
        {
            // since postings are done by admin, no sense using another "replacement" property
            e.BlogPost.PostSubject = ReplaceProfanity(e.BlogPost.PostSubject);
            e.BlogPost.PostBody = ReplaceProfanity(e.BlogPost.PostBody);
        }

        void OnPreSubmissionComment(PreSubmissionCommentEventArgs e)
        {
            // "replacement" property allows another module to communicate before & after to admin
            e.CommentReplacement = ReplaceProfanity(e.BlogComment.CommentBody);
        }

        string ReplaceProfanity(string text)
        {
            foreach (string badWord in _BadWords)
                text = text.Replace(badWord, _ProfanityReplacement);

            return text;
        }
    }
}
