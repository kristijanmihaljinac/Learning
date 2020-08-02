using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyBlog.Data;

namespace EasyBlog.Web.Core
{
    public class RepositoryRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BlogPostRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .As(t => t.GetInterfaces()?.FirstOrDefault(
                    i => i.Name == "I" + t.Name))
                .InstancePerRequest()
                .WithParameter(new TypedParameter(typeof(string), "easyBlog"));
        }
    }
}