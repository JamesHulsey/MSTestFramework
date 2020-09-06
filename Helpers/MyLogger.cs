using NLog;
using Logger = NLog.Logger;

namespace MSTestFramework.Helpers
{
    public class MyLogger
    {
        public static Logger Log = LogManager.GetCurrentClassLogger();
    }
}
