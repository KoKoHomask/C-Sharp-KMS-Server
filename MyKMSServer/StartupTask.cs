using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using KMSEmulatorCore;
using KMSEmulatorCore.Logging;
using System.Globalization;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace MyKMSServer
{
    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferral;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            deferral = taskInstance.GetDeferral();
            //// 
            //// TODO: Insert code to perform background work
            ////
            //// If you start any asynchronous methods here, prevent the task
            //// from closing prematurely by using BackgroundTaskDeferral as
            //// described in http://aka.ms/backgroundtaskdeferral
            ////
            try
            {
                int languageCode = CultureInfo.InstalledUICulture.LCID; // GetSystemDefaultLCID();
                                                                        // Set KMS Server Settings
                KMSServerSettings kmsSettings = new KMSServerSettings
                {
                    KillProcessOnPort = true,
                    GenerateRandomKMSPID = true,
                    DefaultKMSHWID = "364F463A8863D35F"
                };
                // Console 
                ILogger log = new ConsoleLogger();
                // Start KMS Server
                KMSServer.Start(log, kmsSettings);
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}
