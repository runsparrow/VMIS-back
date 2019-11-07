using Microsoft.Extensions.Logging;

namespace GatewayApi.Logs
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static ILoggerFactory AddFileLogger(this ILoggerFactory factory)
        {
            factory.AddProvider(new FileLoggerProvider());
            return factory;
        }
    }
}