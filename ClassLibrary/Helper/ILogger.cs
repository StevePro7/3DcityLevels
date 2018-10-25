using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace ClassLibrary.Helper
{
    public class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Logger));

        public void Initialize()
        {
            // https://stackify.com/making-log4net-net-core-work
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("AppToCSV.dll.config"));
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }
        public void Error(string message)
        {
            Log.Error(message);
        }
        public void Fatal(string message)
        {
            Log.Fatal(message);
        }
        public void Info(string message)
        {
            Log.Info(message);
        }
        public void Warn(string message)
        {
            Log.Warn(message);
        }

    }
}
