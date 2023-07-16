using System;
using System.Management;

namespace VivProcess
{
    public class Proc
    {
        // 관리자권한으로 실행 
        public ManagementEventWatcher watcher_start_admin;
        public ManagementEventWatcher watcher_stop_admin;

        // 일반권한으로 실행
        public ManagementEventWatcher watcher_start_normal;
        public ManagementEventWatcher watcher_stop_normal;

        public Proc()
        {
            // Admin Privileges
            watcher_start_admin
                = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            watcher_stop_admin
                = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));

            // Normal Privileges
            WqlEventQuery query
                = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1), "TargetInstance isa \"Win32_Process\"");
            watcher_start_normal = new ManagementEventWatcher { Query = query };

            WqlEventQuery query_deleted
                = new WqlEventQuery("__InstanceDeletionEvent", new TimeSpan(0, 0, 1), "TargetInstance isa \"Win32_Process\"");
            watcher_stop_normal = new ManagementEventWatcher { Query = query_deleted };
        }

        #region Admin
        public void StartWatch()
        {
            watcher_start_admin.Start();
            watcher_stop_admin.Start();
        }

        public void StopWatch()
        {
            watcher_start_admin.Stop();
            watcher_stop_admin.Stop();
        }
        #endregion

        #region Normal
        public void StartNormal()
        {
            watcher_start_normal.Start();
            watcher_stop_normal.Start();
        }

        public void StopNormal()
        {
            watcher_start_normal.Stop();
            watcher_stop_normal.Stop();
        }
        #endregion
    }
}