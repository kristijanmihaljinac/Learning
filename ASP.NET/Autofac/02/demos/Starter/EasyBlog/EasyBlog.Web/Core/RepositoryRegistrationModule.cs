using Autofac;
using EasyBlog.Data;
using System.Linq;

namespace EasyBlog.Web.Core
{
    public class RepositoryRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BlogPostRepository).Assembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .As(t => t.GetInterfaces()?
             .FirstOrDefault(i => i.Name == "I" + t.Name))
             .InstancePerRequest()
             .WithParameter(new TypedParameter(typeof(string), "easyBog"));
        }
    }
}