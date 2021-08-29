using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FrachatBot
{
    class ChattyHeartBeat
    {
        private const string ChattyExeFullPath = "C:\\Program Files (x86)\\Chatty\\Chatty.exe";
        private const int DefaultPulse = 60 * 1000;

        private int pulseMilliseconds;
        private string exeName;
        private string exePath;
        private Timer heartBeatTimer;

        public ChattyHeartBeat(int pulseSeconds = DefaultPulse)
        {
            this.pulseMilliseconds = pulseSeconds;
            this.exePath = ChattyExeFullPath;
            this.exeName = Path.GetFileNameWithoutExtension(this.exePath).ToLower();
            OnHeartBeat(null, null);
            ScheduleHeartBeat();
        }

        private void ScheduleHeartBeat()
        {
            DateTime nextHeartbeat = DateTime.Now.AddSeconds(this.pulseMilliseconds);
            this.heartBeatTimer = new Timer(this.pulseMilliseconds);
            this.heartBeatTimer.Start();
            this.heartBeatTimer.Elapsed += OnHeartBeat;
        }

        private bool IsExeRunning()
        {
            Process[] processes = Process.GetProcessesByName(this.exeName);
            return processes.Length > 0;
        }

        private void RunExe()
        {
            Process.Start(this.exePath);
        }

        private void OnHeartBeat(object sender, ElapsedEventArgs eventArgs)
        {
            if (!IsExeRunning())
            {
                RunExe();
            }
        }
    }
}
