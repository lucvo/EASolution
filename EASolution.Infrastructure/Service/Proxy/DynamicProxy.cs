using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;

namespace EASolution.Infrastructure.Service.Proxy
{
    class DynamicProxy<T> : RealProxy
    {
        private readonly T _decorated;
        public DynamicProxy(T decorated)
            : base(typeof(T))
        {
            _decorated = decorated;
        }
        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            Log("In Dynamic Proxy - Before executing '{0}'",
              methodCall.MethodName);
            try
            {
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                Log("In Dynamic Proxy - After executing '{0}' ",
                  methodCall.MethodName);
                return new ReturnMessage(result, null, 0,
                  methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Log(string.Format(
                  "In Dynamic Proxy- Exception {0} executing '{1}'", e),
                  methodCall.MethodName);
                return new ReturnMessage(e, methodCall);
            }
        }
    }

    class FlexableDynamicProxy<T> : RealProxy
    {
        private readonly T _decorated;
        private Predicate<MethodInfo> _filter;
        public event EventHandler<IMethodCallMessage> BeforeExecute;
        public event EventHandler<IMethodCallMessage> AfterExecute;
        public event EventHandler<IMethodCallMessage> ErrorExecuting;
        public FlexableDynamicProxy(T decorated)
            : base(typeof(T))
        {
            _decorated = decorated;
            Filter = m => true;
        }
        public Predicate<MethodInfo> Filter
        {
            get { return _filter; }
            set
            {
                if (value == null)
                    _filter = m => true;
                else
                    _filter = value;
            }
        }
        private void OnBeforeExecute(IMethodCallMessage methodCall)
        {
            if (BeforeExecute != null)
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;
                if (_filter(methodInfo))
                    BeforeExecute(this, methodCall);
            }
        }
        private void OnAfterExecute(IMethodCallMessage methodCall)
        {
            if (AfterExecute != null)
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;
                if (_filter(methodInfo))
                    AfterExecute(this, methodCall);
            }
        }
        private void OnErrorExecuting(IMethodCallMessage methodCall)
        {
            if (ErrorExecuting != null)
            {
                var methodInfo = methodCall.MethodBase as MethodInfo;
                if (_filter(methodInfo))
                    ErrorExecuting(this, methodCall);
            }
        }
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            OnBeforeExecute(methodCall);
            try
            {
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                OnAfterExecute(methodCall);
                return new ReturnMessage(
                  result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                OnErrorExecuting(methodCall);
                return new ReturnMessage(e, methodCall);
            }
        }
    }
}
