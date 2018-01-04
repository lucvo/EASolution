using System;

namespace EASolution.Infrastructure.Service.Proxy
{
    public class FlexableServiceFactory
    {
        private static void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public static T Create<T>(T service)
        {
            var dynamicProxy = new FlexableDynamicProxy<T>(service);
            dynamicProxy.BeforeExecute += (s, e) => Log(
                "Before executing '{0}'", e.MethodName);
            dynamicProxy.AfterExecute += (s, e) => Log(
                "After executing '{0}'", e.MethodName);
            dynamicProxy.ErrorExecuting += (s, e) => Log(
                "Error executing '{0}'", e.MethodName);
            dynamicProxy.Filter = m => !m.Name.StartsWith("Get");
            return (T)dynamicProxy.GetTransparentProxy();
        }
    }
}