using Castle.DynamicProxy;
using EASolution.Infrastructure.Utility;
using EASolution.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.Infrastructure.Logging.Interceptor
{
    
    public class LogInterceptor : IInterceptor
    {
        readonly ILogger _log;
        
        public LogInterceptor(ILogger log)
        {
            _log = log;
        }

        #region IInterceptor Members

        //The interceptor will log the beginning and end of the method call.
        public void Intercept(IInvocation invocation)
        {
            
            if (!invocation.Method.Name.StartsWith("Get", System.StringComparison.Ordinal))
            {
                //This happens before the method call
                AsyncHelper.FireAndForget(new AsyncHelper.LogDelegate(LogParameter), "Calling method {0} with parameters {1}", invocation);
            }

            //Actual method call begins
            invocation.Proceed();

            if (!invocation.Method.Name.StartsWith("Get", System.StringComparison.Ordinal))
            {
                AsyncHelper.FireAndForget(new AsyncHelper.LogDelegate(AsyncHelper.PerformLog), "Done: result was {0}.", invocation.ReturnValue);
            }
        }

        #endregion

        private void LogParameter(string msg, object arg = null)
        {
            var invocation = arg as IInvocation;
            _log.LogFunction(msg,
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a =>  (a ?? "").ToString()).ToArray()));
        }

        
    }
}
