using Castle.DynamicProxy;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.Infrastructure.Logging.Interceptor
{
    public class LogInterceptorAsyncBehavior : IInterceptor
    {
        readonly ILogger _log;

        public LogInterceptorAsyncBehavior(ILogger log)
        {
            _log = log;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodReference = Guid.NewGuid();
            _log.Information("Calling {0}.{1} : {2}", invocation.Method.DeclaringType.Name, invocation.Method.Name, methodReference);

            invocation.Proceed();
            invocation.ReturnValue = WatchAsync(methodReference, (Task)invocation.ReturnValue);
        }

        private async Task WatchAsync(Guid methodReference, Task methodExecution)
        {
            try
            {
                await methodExecution.ConfigureAwait(false);
            }
            finally
            {
                _log.Information("Done: result was {0}.", methodExecution);
            }
        }
    }
}
