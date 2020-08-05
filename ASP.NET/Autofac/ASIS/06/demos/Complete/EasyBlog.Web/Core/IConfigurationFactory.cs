using EasyBlog.Web.Configuration;
using System;
using System.Linq;

namespace EasyBlog.Web.Core
{
    public interface IConfigurationFactory
    {
        EasyBlogModulesConfigurationElementCollection GetModules();
    }
}
