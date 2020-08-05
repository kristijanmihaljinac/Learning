using EasyBlog.Common;
using System;
using System.Linq;

namespace EasyBlog.Web.Core
{
    public interface IExtensibilityManager
    {
        ModuleEvents GetModuleEvents();
        void InvokeModuleEvent<T>(Action<T> moduleEvent, T args);
        void InvokeCancelableModuleEvent<T>(Action<T> moduleEvent, T args);
    }
}
