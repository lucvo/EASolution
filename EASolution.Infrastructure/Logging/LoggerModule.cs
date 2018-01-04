using Autofac;
using AutofacSerilogIntegration;
using Castle.DynamicProxy;
using Serilog;

namespace EASolution.Infrastructure.Logging
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register the Log Interceptor, which will log out to the console of the application. Anything registered with 'log-calls' will be intercepted
            builder.RegisterType(typeof(Interceptor.LogInterceptor))
                .As<IInterceptor>()
                .Named<IInterceptor>("log-calls");
            builder.RegisterType(typeof(Interceptor.LogInterceptorAsyncBehavior))
                .As<IInterceptor>()
                .Named<IInterceptor>("a-sync-log-calls");
            builder.RegisterLogger();
        }
    }
}
