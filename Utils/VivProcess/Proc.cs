using System.Management;

namespace VivProcess
{
    public class Proc
    {
        public ManagementEventWatcher startWatcher;
        public ManagementEventWatcher stopWatcher;

        public Proc()
        {
            startWatcher
                = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));

            stopWatcher
                = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
        }

        public void StartWatch()
        {
            startWatcher.Start();
            stopWatcher.Start();
        }

        public void StopWatch()
        {
            startWatcher.Stop();
            stopWatcher.Stop();
        }
    }
}
