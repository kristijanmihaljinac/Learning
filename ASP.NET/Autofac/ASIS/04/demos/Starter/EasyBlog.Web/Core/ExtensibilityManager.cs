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
        #region get module events

        ModuleEvents IExtensibilityManager.GetModuleEvents()
        {
            ModuleEvents moduleEvents = new ModuleEvents();

            EasyBlogConfigurationSection config = ConfigurationManager.GetSection("easyBlog")
                as EasyBlogConfigurationSection;
            if (config != null)
            {
                foreach (EasyBlogModuleConfigurationElement module in config.Modules)
                {
                    IEasyBlogModule moduleType = Activator.CreateInstance(Type.GetType(module.Type)) 
                        as IEasyBlogModule;
                    if (moduleType != null)
                    {
                        moduleType.Initialize(moduleEvents);
                    }
                }
            }
            
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
