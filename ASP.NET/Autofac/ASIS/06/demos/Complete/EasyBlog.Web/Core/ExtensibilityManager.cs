using Autofac;
using EasyBlog.Common;
using EasyBlog.Web.Configuration;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;

namespace EasyBlog.Web.Core
{
    public class ExtensibilityManager : IExtensibilityManager
    {
        public ExtensibilityManager(IConfigurationFactory configurationFactory, ILifetimeScope container)
        {
            _ConfigurationFactory = configurationFactory;
            _Container = container;
        }
        
        IConfigurationFactory _ConfigurationFactory;
        ILifetimeScope _Container;
        ModuleEvents _ModuleEvents;

        public ModuleEvents ModuleEvents
        {
            get { return _ModuleEvents; }
        }

        #region get module events

        ModuleEvents IExtensibilityManager.GetModuleEvents()
        {
            ModuleEvents moduleEvents = new ModuleEvents();

            EasyBlogModulesConfigurationElementCollection modules = _ConfigurationFactory.GetModules();
            if (modules != null)
            {
                foreach (EasyBlogModuleConfigurationElement module in modules)
                {
                    IEasyBlogModule moduleType = _Container.Resolve(Type.GetType(module.Type)) as IEasyBlogModule;
                    if (moduleType != null)
                    {
                        moduleType.Initialize(moduleEvents);
                    }
                }
            }

            _ModuleEvents = moduleEvents;

            return moduleEvents;
        }

        #endregion

        #region invokers

        void IExtensibilityManager.InvokeModuleEvent<T>(Action<T> moduleEvent, T args)
        {
            if (moduleEvent != null)
                moduleEvent(args);
        }

        void IExtensibilityManager.InvokeCancelableModuleEvent<T>(Action<T> moduleEvent, T args)
        {
            if (moduleEvent != null)
            {
                bool cancel = false;
                Delegate[] invocationList = moduleEvent.GetInvocationList();
                foreach (Action<T> eventDelegate in invocationList)
                {
                    if (!cancel)
                    {
                        eventDelegate(args);
                        if (args is CancelEventArgs)
                            cancel = (args as CancelEventArgs).Cancel;
                    }
                }
            }
        }

        #endregion
    }
}
