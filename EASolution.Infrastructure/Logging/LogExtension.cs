using Castle.DynamicProxy;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Linq;
using System.Text;

namespace EASolution.Infrastructure.Logging
{
    public static class LogExtension
    {
        public static void LogRequestReceived(this ILogger logger, string methodName, object functionParameters = null)
        {
            string strFunctionParameters = "";
            if (functionParameters != null)
                strFunctionParameters = JsonConvert.SerializeObject(functionParameters);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}   Client request received for {1}.", DateTime.Now.ToString(), methodName, Environment.NewLine);

            if (!string.IsNullOrEmpty(strFunctionParameters))
                sb.AppendFormat("Input Parameters : {0}", strFunctionParameters);

            logger.Debug(sb.ToString());
        }

        public static void LogFunction(this ILogger logger, string message, string methodName = "", string param="", string logLevel = "Info")
        {
            switch (logLevel)
            {
                case "Info": logger.Information(message, methodName, param); break;
                case "Request": logger.Information(string.Format("{0}  Client request received for {1}({2}).", DateTime.Now.ToString(), methodName, param)); break;
                case "Debug": logger.Debug(string.Format("{0}  Debug Info {1}({2}).", DateTime.Now.ToString(), methodName, param)); break;
                case "Warn": logger.Warning(string.Format("{0}  Warn Info {1}({2}).", DateTime.Now.ToString(), methodName, param)); break;
            }
        }

        public static void LogException(this ILogger logger, string methodName, string param, Exception exp)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Method Name: {0} {1}({2})", methodName,param, Environment.NewLine);
            sb.AppendFormat("Exception : {0}{1}", exp.Message, Environment.NewLine);
            sb.AppendFormat("Exception Source: {0} {1}", exp.Source, Environment.NewLine);
            sb.AppendFormat("Exception Details: {0} {1}", exp.InnerException != null ? exp.InnerException.ToString() : "No details available.", Environment.NewLine);
            sb.AppendFormat("Exception Stack Trace : {0}", exp.StackTrace);

            logger.Error(sb.ToString());
        }
        
    }
}
