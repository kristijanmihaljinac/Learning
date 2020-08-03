using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyBlog.Web.Core
{
    public class ComponentLocator : IComponentLocator
    {
        private readonly ILifetimeScope _lifetimeScope;
        public ComponentLocator(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public T ResolveComponent<T>()
        {
            return _lifetimeScope.Resolve<T>();
        }
    }


    public interface IComponentLocator
    {
        T ResolveComponent<T>();
    }
}