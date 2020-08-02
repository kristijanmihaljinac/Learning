using System;
using System.Configuration;
using System.Linq;

namespace EasyBlog.Web.Configuration
{
    public class EasyBlogModulesConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EasyBlogModuleConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EasyBlogModuleConfigurationElement)element).Name;
        }
    }
}
