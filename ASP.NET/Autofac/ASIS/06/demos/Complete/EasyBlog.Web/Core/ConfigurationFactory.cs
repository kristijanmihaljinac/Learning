using EasyBlog.Web.Configuration;
using System;
using System.Configuration;
using System.Linq;

namespace EasyBlog.Web.Core
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        EasyBlogModulesConfigurationElementCollection IConfigurationFactory.GetModules()
        {
            EasyBlogConfigurationSection config = ConfigurationManager.GetSection("easyBlog")
                as EasyBlogConfigurationSection;

            if (config != null)
                return config.Modules;
            else
                return null;
        }
    }
}
