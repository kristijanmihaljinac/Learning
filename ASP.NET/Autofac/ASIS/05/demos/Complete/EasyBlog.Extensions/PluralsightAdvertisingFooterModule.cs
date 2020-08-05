using EasyBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyBlog.Extensions
{
    public class PluralsightAdvertisingFooterModule : IEasyBlogModule
    {
        void IEasyBlogModule.Initialize(ModuleEvents moduleEvents)
        {
            moduleEvents.PreSubmissionPosting += OnPreSubmissionPosting;
        }

        void OnPreSubmissionPosting(PreSubmissionPostingEventArgs e)
        {
            string header = string.Empty;
            StringBuilder footer = new StringBuilder();

            footer.AppendLine();
            footer.AppendLine("---------------------------------");
            footer.AppendLine("Available Pluralsight courses:");
            footer.AppendLine(" Building End-to-End Multi-Client Service Oriented Applications");
            footer.AppendLine(" Building End-to-End Multi-Client Service Oriented Applications - angular edition");
            footer.AppendLine(" Developing Extensible Software");
            footer.AppendLine(" WCF End-to-End");
            footer.AppendLine(" WCF Power Topics");
            footer.AppendLine();

            e.BlogPost.PostBody += footer.ToString();
        }
    }
}
