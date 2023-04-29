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

        private readonly System.Windows.Forms.Timer timer;

        //* 타이머 오류 처리 *//
        // System.Threading.Timer 사이에 모호한 참조 -> 라인 제거
        //
        //-> System.Windows.Forms.Timer timer;

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
            Btn_StartAdmin.Text = isWatch ? "Stop Watcher" : "Start Watcher";
            // 프로세서 
            ps = new Proc();

            // 타이머
            timer = new Timer { Interval = 1000 }; // 매초
            // timer = new Timer { Interval = 1000 * 60 * 60 }; // 60 분

            timer.Tick += Timer_Tick;
            timer.Start();

            // 손목시계
            watch = new Stopwatch();
        }

        private void SetButtonsWidth()
        {
            Btn_KillProcess.Width = Width / 5;
            Btn_StartAdmin.Width = Width * 2 / 5;
            Btn_StartNormal.Width = Width * 2 / 5;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string message = watch.Elapsed.Seconds == 0
                ? $"{title}\n{proc} Not Runnig..."
                : $"{title}\n{proc} Started... {watch.Elapsed.Seconds} 초 경과";

            Lbl_Status.Text = $"{message}";

            Application.DoEvents();
        }

        #region Admin Privilege Watcher
        private void Btn_Start_Admin_Click(object sender, EventArgs e)
        {
            // 프로세스 시작 및 중지 이벤트
            ps.watcher_start_admin.EventArrived += Watcher_Started_Admin_EventArrived;
            ps.watcher_stop_admin.EventArrived += Watcher_Stopped_Admin_EventArrived;

            // 감시시작
            ps.StartWatch();

            isWatch = !isWatch;

            // 버튼 토글시 감시중지
            if (!isWatch) ps.StopWatch();
            else ps.StartWatch();

            Btn_StartAdmin.Text = isWatch ? "Stop Watcher (Admin)" : "Start Watcher (Admin)";
        }

        private void Watcher_Stopped_Admin_EventArrived(object sender, EventArrivedEventArgs e)
        {
            // 중지된 프로세스가 감시 목록에 있는 것인지 이름으로 확인
            string procName = e.NewEvent.Properties["ProcessName"]?.Value?.ToString();
            if (!procName.Equals(proc)) return;

            //// 맞으면 손목시계 초기화
            watch.Stop();
            watch.Reset();
            SetKillButton(false);
        }

        private void Watcher_Started_Admin_EventArrived(object sender, EventArrivedEventArgs e)
        {
            // 시작된 프로세스가 감시 목록에 있는 것인지 이름으로 확인
            string procName = e.NewEvent.Properties["ProcessName"]?.Value?.ToString();

            if (!procName.Equals(proc)) return;
            watch.Start();

            SetKillButton(true);
        }

        #endregion


        #region Normal Privilege Watcher

        private void Btn_StartNormal_Click(object sender, EventArgs e)
        {
            ps.watcher_start_normal.EventArrived += Watcher_Started_Normal_EventArrived;
            ps.watcher_stop_normal.EventArrived += Watcher_Stopped_Normal_EventArrived;

            isWatch = !isWatch;

            Btn_StartNormal.Text = (isWatch = !isWatch) ? "Stop Watcher (Normal)" : "Start Watcher (Normal)";

            if (!isWatch) ps.StopNormal();
            else ps.StartNormal();
            ps.StartNormal();
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
    }
}
