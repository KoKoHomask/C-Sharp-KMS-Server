using KMSEmulatorCore;
using KMSEmulatorCore.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AutoKMS
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        ConsoleAndFileLogger log = new ConsoleAndFileLogger();
        protected override void OnStart(string[] args)
        {
            
            //System.Timers.Timer t = new System.Timers.Timer();//定时器  
            //t.Interval = 1000;//设置定时器时间间隔为1000毫秒  
            //t.Elapsed += new System.Timers.ElapsedEventHandler(ChkSrv);//到达时间的时候执行事件（每隔一秒）      
            //t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；      
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；      
            try
            {
                int languageCode = CultureInfo.InstalledUICulture.LCID; // GetSystemDefaultLCID();
                                                                       
                KMSServerSettings kmsSettings = new KMSServerSettings // Set KMS Server Settings
                {
                    KillProcessOnPort = true,
                    GenerateRandomKMSPID = true,
                    DefaultKMSHWID = "364F463A8863D35F"
                };
                
                // Start KMS Server
                KMSServer.Start(log, kmsSettings);
            }
            catch (Exception ex) { log.LogMessage(ex.ToString()); }
        }
        public void ChkSrv(object source, System.Timers.ElapsedEventArgs e)
        {
            int intSecond = e.SignalTime.Second;
            log.LogMessage("running");
        }

        protected override void OnStop()
        {
            log.LogMessage("Stopping KMS Server");
            KMSServer.Stop();
            log.LogMessage("KMS Server han been stoped");


        }
    }
}
