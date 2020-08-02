using System;
using System.Configuration;
using System.Linq;

namespace EasyBlog.Web.Configuration
{
    public class EasyBlogConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("modules")]
        public EasyBlogModulesConfigurationElementCollection Modules
        {
            get { return (EasyBlogModulesConfigurationElementCollection)base["modules"]; }
            set { base["modules"] = value; }
        } 
    }
}
