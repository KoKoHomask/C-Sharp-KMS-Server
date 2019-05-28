using System;
using System.Collections.Generic;
using System.Text;

namespace KMSEmulatorCore.Logging
{
    public interface ILogger
    {
        void LogMessage(string message, bool timestamp = true);
    }
}
