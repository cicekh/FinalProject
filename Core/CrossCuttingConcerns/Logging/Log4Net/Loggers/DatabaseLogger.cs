using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using log4net;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {

        }
    }
}
