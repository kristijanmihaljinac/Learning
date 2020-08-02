using System;
using System.Configuration;
using System.Linq;

namespace EasyBlog.Web.Configuration
{
    public class EasyBlogModuleConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("type")]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }
    }
}
