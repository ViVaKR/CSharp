using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms; // 타이머


namespace VivProcess
{
    public partial class MainForm : Form
    {
        // 감시할 프로세스 이름 : 확장자 포함
        private const string proc = "notepad.exe";
        private string title = string.Empty;
        private const string started = "**** Started *****";
        private const string stopped = "**** Stopped *****";

        private readonly Timer timer;

        private readonly Stopwatch watch;
        private readonly Proc ps;
        private bool isWatch;

        public MainForm()
        {
            InitializeComponent();

            Width = 1024;
            Height = 768;
            StartPosition = FormStartPosition.CenterScreen;

            // 버튼폭 조절 (폼크기 변경시)
            ResizeEnd += (s, e) => SetButtonsWidth();

            Btn_KillProcess.Enabled = false;
            isWatch = false;
            Btn_StartAdmin.Text = isWatch ? "Stop Watcher (Admin)" : "Start Watcher (Admin)";
            // 프로세서 
            ps = new Proc();

            // 타이머
            timer = new Timer { Interval = 1000 }; // 매초

            timer.Tick += Timer_Tick;
            timer.Start();

            // 손목시계
            watch = new Stopwatch();

            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AutoStartWithNormal();
        }

        private void SetButtonsWidth()
        {
            Btn_KillProcess.Width = Width / 5;
            Btn_StartAdmin.Width = Width * 2 / 5;
            Btn_StartNormal.Width = Width * 2 / 5;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int elapsed = watch.Elapsed.Seconds;

            string message = $"{title}\n{proc} Started... {elapsed} 초 경과";

            if (elapsed == 3600) // 60분 = 3600
            {
                timer.Stop();
                watch.Stop();
                ShowMessage(elapsed);

                timer.Start();
                watch.Start();
            }

            Lbl_Status.Text = message;
        }

        private void ShowMessage(int elaspsed)
        {
            MessageBox.Show($"({elaspsed / 60 / 60}) 시간 다 되었습니다. 먼가 합시다. 초시계 초기화 합니다.");
            watch.Reset();
        }

        #region Normal Privilege Watcher

        private void Btn_StartNormal_Click(object sender, EventArgs e)
        {
            AutoStartWithNormal();
        }

        private void AutoStartWithNormal()
        {
            isWatch = !isWatch;
            if (!isWatch)
            {
                ps.watcher_start_normal.EventArrived -= Watcher_Started_Normal_EventArrived;
                ps.watcher_stop_normal.EventArrived -= Watcher_Stopped_Normal_EventArrived;
                ps.StopNormal();
                watch.Stop();
                watch.Reset();
            }
            else
            {
                ps.watcher_start_normal.EventArrived += Watcher_Started_Normal_EventArrived;
                ps.watcher_stop_normal.EventArrived += Watcher_Stopped_Normal_EventArrived;
                ps.StartNormal();
            };
            SetButton(isWatch);

        }

        private void Watcher_Stopped_Normal_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
            string processName = targetInstance.Properties["Caption"].Value?.ToString();
            if (!processName.Equals(proc)) return;

            uint processId = (uint)targetInstance.Properties["ProcessId"].Value;
            uint parentProcessId = (uint)targetInstance.Properties["ParentProcessId"].Value;
            string path = targetInstance.Properties["ExecutablePath"].Value?.ToString();

            title = $"{stopped}\n{processName}\n- Process ID: {processId}\n- Parent ID: {parentProcessId}\n- File Path: {path}\n";
            // 초기화
            watch.Stop();
            watch.Reset();

            SetKillButton(false);
        }

        private void Watcher_Started_Normal_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
            string processName = targetInstance.Properties["Caption"].Value?.ToString();
            if (!processName.Equals(proc)) return;
            watch.Start();


            uint processId = (uint)targetInstance.Properties["ProcessId"].Value;
            uint parentProcessId = (uint)targetInstance.Properties["ParentProcessId"].Value;
            string path = targetInstance.Properties["ExecutablePath"].Value?.ToString();

            // 풍부한 정보 제공용
            title = $"{started}\n{processName}\n- Process ID: {processId}\n- Parent ID: {parentProcessId}\n- File Path: {path}\n";

            SetKillButton(true);
        }

        private void SetButton(bool tf)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                Btn_StartNormal.Text = tf ? "Stop Watcher (Normal)" : "Start Watcher (Normal)";
            });
        }

        #endregion

        #region Kill Process
        private void SetKillButton(bool tf)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                Btn_KillProcess.Enabled = tf;
                Btn_KillProcess.Text = tf ? $"Kill -> {proc}" : "Watching...";
            });
        }

        private void Btn_KillProcess_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(proc)))
            {
                process.Kill();
            }
        }
        #endregion

        #region Admin Privilege Watcher
        private void Btn_Start_Admin_Click(object sender, EventArgs e)
        {
            // 프로세스 시작 및 중지 이벤트

            Btn_StartAdmin.Text = (isWatch = !isWatch) ? "Stop Watcher (Admin)" : "Start Watcher (Admin)";

            // 버튼 토글시 감시중지
            if (!isWatch)
            {
                ps.watcher_start_admin.EventArrived -= Watcher_Started_Admin_EventArrived;
                ps.watcher_stop_admin.EventArrived -= Watcher_Stopped_Admin_EventArrived;
                ps.StopWatch();
                watch.Stop();
                watch.Reset();
            }
            else
            {
                ps.watcher_start_admin.EventArrived += Watcher_Started_Admin_EventArrived;
                ps.watcher_stop_admin.EventArrived += Watcher_Stopped_Admin_EventArrived;
                ps.StartWatch();
                watch.Restart();
            }
        }

        private void Watcher_Stopped_Admin_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string procName = e.NewEvent.Properties["ProcessName"]?.Value?.ToString();
            if (!procName.Equals(proc)) return;
            watch.Stop();
            watch.Reset();
            SetKillButton(false);
        }

        private void Watcher_Started_Admin_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string procName = e.NewEvent.Properties["ProcessName"]?.Value?.ToString();
            if (!procName.Equals(proc)) return;
            watch.Start();
            SetKillButton(true);
        }

        #endregion
    }
}
