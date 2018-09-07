using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakal.AppService
{
    public class LoggerService : ILoggerService
    {
        private readonly string logFilePath = Environment.CurrentDirectory + "\\log.txt";
        public void WriteLogToText(Exception e, string moreInfo)
        {
            string msg = $"---------------------------------------------------------------------------\n" +
                $"{DateTime.Now.ToString()}\n\n" +
                $"{e.StackTrace}\n" +
                $"{moreInfo}" +
                $"\n\n";
            File.AppendAllText(logFilePath, msg);
        }
    }
}
