using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace VivProcess
{
    public partial class MainForm : Form
    {
        // 감시할 프로세스 이름 : 확장자 포함
        private readonly string proc = "notepad.exe";

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
            Btn_KillProcess.Enabled = false;
            isWatch = false;
            Btn_Start.Text = isWatch ? "Stop Watcher" : "Start Watcher";
            // 프로세서 
            ps = new Proc();

            // 타이머
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            timer.Start();

            // 손목시계
            watch = new Stopwatch();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string message = watch.Elapsed.Seconds == 0 ? $"{proc} Not Runnig..." : $"{proc} Started... {watch.Elapsed.Seconds} 초 경과";
            Message(message);
            Application.DoEvents();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            // 프로세스 시작 및 중지 이벤트
            ps.startWatcher.EventArrived += StartWatch_EventArrived;
            ps.stopWatcher.EventArrived += StopWatch_EventArrived;

            // 감시시작
            ps.StartWatch();

            isWatch = !isWatch;

            // 버튼 토글시 감시중지
            if (!isWatch) ps.StopWatch();

            Btn_Start.Text = isWatch ? "Stop Watcher" : "Start Watcher";

        }

        private void Message(string message) => Lbl_Status.Text = $"{message}";

        /// <summary>
        /// 모든 프로세스 중지 감지 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopWatch_EventArrived(object sender, System.Management.EventArrivedEventArgs e)
        {
            // 중지된 프로세스가 감시 목록에 있는 것인지 이름으로 확인
            string procName = e.NewEvent.Properties["ProcessName"]?.Value?.ToString();
            if (!procName.Equals(proc)) return;

            //// 맞으면 손목시계 초기화
            watch.Stop();
            watch.Reset();
            SetKillButton(false);
        }

        /// <summary>
        /// 모든 프로세스 시작 감지 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartWatch_EventArrived(object sender, System.Management.EventArrivedEventArgs e)
        {
            // 시작된 프로세스가 감시 목록에 있는 것인지 이름으로 확인
            string procName = e.NewEvent.Properties["ProcessName"]?.Value?.ToString();

            if (!procName.Equals(proc)) return;
            watch.Start();

            SetKillButton(true);

        }

        private void SetKillButton(bool tf)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                Btn_KillProcess.Enabled = tf;

                Btn_KillProcess.Text = tf ? $"Kill -> {proc}" : "Watching...";
            });
        }

        /// <summary>
        /// 프로세스 이름으로 죽이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_KillProcess_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(proc)))
            {
                process.Kill();
            }
        }
    }
}
