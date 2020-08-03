using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EasyBlog.Data;
using EasyBlog.Web.Controllers;
using EasyBlog.Web.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EasyBlog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //IExtensibilityManager extensibilityManager = new ExtensibilityManager();

           


            ContainerBuilder builder = new ContainerBuilder();
            IDependencyResolver dependencyResolver = DependencyResolver.Current;
            if (dependencyResolver.GetType() != typeof(AutofacDependencyResolver))
            {
                //builder.RegisterType<HomeController>();

                //registracija svih mvc controllera
                builder.RegisterControllers(typeof(MvcApplication).Assembly)
                    .InstancePerRequest()
                    .PropertiesAutowired();

                builder.RegisterApiControllers(typeof(MvcApplication).Assembly).InstancePerRequest();


                //builder.RegisterModule<RepositoryRegistrationModule>();

                //builder.RegisterType<Tester>().As<ITester>().SingleInstance();
                //builder.RegisterType<ExtensibilityManager>().As<IExtensibilityManager>().SingleInstance();



                //repozitoriji jedan po jedan
                //builder.RegisterType<BlogPostRepository>().As<IBlogPostRepository>()
                //       .WithParameter(new TypedParameter(typeof(string), "easyBog"));
                //.WithParameter(new NamedParameter("connectionStringName", "easyBog"));


                IConfigurationBuilder config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");

                ConfigurationModule configurationModule = new ConfigurationModule(config.Build());

                builder.RegisterModule(configurationModule);
                IContainer container = builder.Build();
                //resolvanje dependencija
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

                IExtensibilityManager extensibilityManager = container.Resolve<IExtensibilityManager>();
                
                //if (Application["ModuleEvents"] == null)
                 extensibilityManager.GetModuleEvents();
            }


        }
    }


    public interface ITester
    {
        int Test();
    }


    public class Tester : ITester
    {
        int _counter = 0;

        public int Test()
        {
            _counter++;
            return _counter;
        }
    }
}
