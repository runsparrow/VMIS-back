using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GatewayApi.Logs
{
    /// <summary>
    /// 
    /// </summary>
    public class FileLogger : ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public FileLogger(string name)
        {
            _name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!_name.StartsWith("LoggingStudy"))
                return;
            //获取日志信息
            var message = formatter?.Invoke(state, exception);
            //日志写入文件
            LogToFile(logLevel, message);
            //Console.WriteLine("from ayxLog " + message);
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        private void LogToFile(LogLevel level, string message)
        {
            var filename = GetFilename();
            var logContent = GetLogContent(level, message);
            File.AppendAllLines(filename, new List<string> { logContent }, Encoding.UTF8);
        }
        /// <summary>
        /// 获取日志内容
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private string GetLogContent(LogLevel level, string message)
        {
            return $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.h3")}]{level}|{_name}|{message}";
        }
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <returns></returns>
        private static string GetFilename()
        {
            var dir = "C:\\Log";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            var result = $"{dir}\\AyxFileLog-{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            return result;
        }
    }

}