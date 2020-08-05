using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyBlog.Web.Core
{
    public class ComponentLocator : IComponentLocator
    {
        public ComponentLocator(ILifetimeScope container)
        {
            _Container = container;
        }

        ILifetimeScope _Container;

        T IComponentLocator.ResolveComponent<T>()
        {
            return _Container.Resolve<T>();
        }
    }



    public interface IComponentLocator
    {
        T ResolveComponent<T>();
    }
}