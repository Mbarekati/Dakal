using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dakal.AppService
{
    public interface ILoggerService
    {
        void WriteLogToText(Exception e, String moreInfo = null);
    }
}
