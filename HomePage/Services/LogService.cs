using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HomePage.Services
{
    public class LogService
    {   
        public enum Level
        {
            Debug,
            Error,
        }

        public LogService()
        {
        }

        public void Debug(string msg, 
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(Level.Debug, memberName, sourceFilePath, sourceLineNumber, msg);
        }

        public void Error(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Print(Level.Error, memberName, sourceFilePath, sourceLineNumber, msg);
        }

        public void Print(Level type, string member, string file, int line, string msg)
        {
            string prefix = "";
            switch (type)
            {
                case Level.Debug:
                default:
                    prefix = "Debug";
                    break;
            
                case Level.Error:
                    prefix = "Error";
                    break;
            }

#if DEBUG
            Console.WriteLine(string.Format("{0}: ({1}, {2}, {3}) => {4}", prefix, member, file, line, msg));
#else
            if(type == Level.Error)
            {
                Console.WriteLine(string.Format("{0} has been encountered at {1} on line {2}", prefix, DateTime.UtcNow.ToString(), line));
            }
#endif
        }
    }
}