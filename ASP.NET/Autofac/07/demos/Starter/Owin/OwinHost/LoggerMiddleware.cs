using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace OwinHost
{
    public class LoggerMiddleware : OwinMiddleware
    {
        public LoggerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Inside the 'Invoke' method of the 'LoggerMiddleware' middleware.");
           
            await Next.Invoke(context);
        }
    }
}
