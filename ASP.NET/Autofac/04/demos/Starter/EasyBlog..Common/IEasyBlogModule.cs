using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Common
{
    public interface IEasyBlogModule
    {
        void Initialize(ModuleEvents moduleEvents);
    }
}
