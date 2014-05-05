using log4net.Config;

namespace FirstWebApp.WebApp.Logger
{
    using log4net;

    public static class LoggerFactory
    {
        static LoggerFactory()
        {
            XmlConfigurator.Configure();
        }

        public static ILog GetLogger(string type)
        {
            return LogManager.GetLogger(type);
        }
    }
}