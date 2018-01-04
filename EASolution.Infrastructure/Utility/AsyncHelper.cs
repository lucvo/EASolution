using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EASolution.Infrastructure.Utility
{
    public class AsyncHelper
    {
        private static AsyncCallback callback = new AsyncCallback(EndWrapperInvoke);
        private static DelegateWrapper wrapperInstance = new DelegateWrapper(InvokeWrappedDelegate);

        private static void EndWrapperInvoke(IAsyncResult ar)
        {
            wrapperInstance.EndInvoke(ar);
            ar.AsyncWaitHandle.Close();
        }

        public static void FireAndForget(Delegate d, params object[] args)
        {
            wrapperInstance.BeginInvoke(d, args, callback, null);
        }

        private static void InvokeWrappedDelegate(Delegate d, object[] args)
        {
            d.DynamicInvoke(args);
        }

        private delegate void DelegateWrapper(Delegate d, object[] args);

        public delegate void LogDelegate(string msg, object arg = null);
        public static void PerformLog(string msg, object arg = null)
        {
            Serilog.Log.Information(msg, arg);
        }

        public delegate void InsertOrUpdateDelegate(string connectionString, string storedProcName, object[] parms);
        public static void PerformInsertOrUpdate(string connectionString, string storedProcName, object[] parms)
        {
            SqlHelper.ExecuteNonQuery(connectionString, storedProcName, parms);
        }
    }
}
