using System;
using System.IO;
using System.Reflection;

namespace KMSEmulatorCore.Logging
{
    public class ConsoleAndFileLogger : ILogger
    {
        private string _path;

        public void LogMessage(string message, bool timestamp = false)
        {
            if (_path == null)
                _path = GetExePath() + "\\KMSEmulator.log";

            if (timestamp)
            {
                Console.WriteLine(DateTime.Now.ToString("s") + "\t" + message);
                File.AppendAllText(_path, DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:fff ") + message + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(message);
                File.AppendAllText(_path, message + Environment.NewLine);
            }
        }

        private static string GetExePath()
        {
            string fullPath = Assembly.GetEntryAssembly().Location;
            return fullPath.Substring(0, fullPath.LastIndexOf('\\'));
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message, bool timestamp = false)
        {
            if (timestamp)
            {
                Console.WriteLine(DateTime.Now.ToString("s") + "\t" + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
