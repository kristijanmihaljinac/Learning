using System;
using System.Diagnostics;
using System.Linq;

namespace EasyBlog.Web.Core
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class TraceLogger : ILogger
    {
        void ILogger.Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}