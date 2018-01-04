using Castle.DynamicProxy;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.Infrastructure.Logging.Interceptor
{
    public class TransactionInterceptor : IInterceptor
    {
        readonly ILogger _log;

        public TransactionInterceptor(ILogger log)
        {
            _log = log;
        }

        public void Intercept(IInvocation invocation)
        {
            _log.Information("Begin Transaction on: {0}", invocation.Method.Name);
        }
    }
}
