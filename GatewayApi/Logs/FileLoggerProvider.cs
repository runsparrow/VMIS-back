using Microsoft.Extensions.Logging;

namespace GatewayApi.Logs
{
    /// <summary>
    /// 
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {

        }
    }
}