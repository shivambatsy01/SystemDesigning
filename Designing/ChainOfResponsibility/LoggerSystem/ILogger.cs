using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSystem
{
    public enum LogLevel
    {
        Error,
        Debug,
        Info,
        None
    }

    internal abstract class ILogger
    {
        ILogger nextLogger;
        protected ILogger(ILogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public virtual void Log(string message, LogLevel logLevel)
        {
            if(nextLogger != null)
            {
                nextLogger.Log(message, logLevel);
            }
            else
            {
                Console.WriteLine("No logger available for Level : " + logLevel.ToString() + "\n");
            }
        }
    }


    internal class InfoLogger : ILogger
    {
        public InfoLogger(ILogger nextLogger) : base(nextLogger)
        {

        }

        public override void Log(string message, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Info)
            {
                Console.WriteLine("Logging Info: " + message + "\n");
            }
            else
            {
                Console.WriteLine("Logger is Info but msg is " + logLevel.ToString() + ". Passing to nextLogger");
                base.Log(message, logLevel);
            }
        }
    }

    internal class DebugLogger : ILogger
    {
        public DebugLogger(ILogger nextLogger) : base(nextLogger)
        {
        }

        public override void Log(string message, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Debug)
            {
                Console.WriteLine("Logging Debug: " + message + "\n");
            }
            else
            {
                Console.WriteLine("Logger is debug but msg is "+ logLevel.ToString() + ". Passing to nextLogger");
                base.Log(message, logLevel);
            }
        }
    }

    internal class ErrorLogger : ILogger
    {
        public ErrorLogger(ILogger nextlogger) : base(nextlogger)
        {

        }

        public override void Log(string message, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Error) //can handle request
            {
                Console.WriteLine("Logging Error: " + message + "\n");
            }
            else
            {
                Console.WriteLine("Logger is Error but msg is " + logLevel.ToString() + ". Passing to nextLogger");
                base.Log(message, logLevel);
            }
        }
    }
}
