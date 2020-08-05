using EasyBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Extensions
{
    public class UserAuthorizationModule : IEasyBlogModule
    {
        public UserAuthorizationModule()
        {
            _BannedUsers = new List<string>()
                {
                    "nickla@microsoft.com",
                    "brian.noyes@solliance.net",
                    "lenni.lobel@sleektech.com"
                };

            _BannedUsers.Select(item => item = item.ToLower());
        }
        
        List<string> _BannedUsers;

        void IEasyBlogModule.Initialize(ModuleEvents moduleEvents)
        {
            moduleEvents.PreSubmissionComment += OnPreSubmissionComment;
        }

        void OnPreSubmissionComment(PreSubmissionCommentEventArgs e)
        {
            if (_BannedUsers.Contains(e.BlogComment.Email.ToLower()))
                e.Cancel = true;
        }
    }
}
