using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace J_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            textBox1.Text = string.Empty;

            Load += MainForm_Load;

            Shown += (s, e) =>
            {
                string result = GetProcess("notepad");
                if (string.IsNullOrEmpty(result)) return;
                textBox1.Text = result;
            };
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            float ratio = 1.5f;

            SizeF scale = new SizeF(w / (w * ratio), h / (h * ratio));

            Scale(scale);
            textBox1.Text = "Hello World";
            foreach (Control control in this.Controls)
                control.Font = new Font(@"빙그레 따옴체", 15.5f, FontStyle.Regular);



            //Process process = new Process();
            //process.StartInfo.FileName = @"%windir%\notepad.exe";
            //process.Start();
            //string name = PerformanceCounterInstanceName(process);
            //textBox1.Text += name;
        }

        public static string GetProcess(string procName)
        {
            Process[] processes = Process.GetProcesses();
            if (!processes.Any(x => Path.GetFileNameWithoutExtension(x.ProcessName).Contains(procName))) return "-";
            Process process = processes.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x.ProcessName).Contains(procName));

            Func<string, bool> matchesProcessId = new Func<string, bool>(instanceName =>
            {
                using (PerformanceCounter pc = new PerformanceCounter("Process", "ID Process", instanceName, true))
                {
                    if ((int)pc.RawValue == process.Id)
                    {
                        return true;
                    }

                }

                return false;
            });

            string processName = Path.GetFileNameWithoutExtension(process.ProcessName);

            PerformanceCounterCategory p = new PerformanceCounterCategory("Process");
            InstanceDataCollectionCollection r = p.ReadCategory();

            return new PerformanceCounterCategory("Process")
               .GetInstanceNames()
               .AsParallel()
               .FirstOrDefault(instanceName => instanceName.StartsWith(processName)
                                               && matchesProcessId(instanceName));
        }

        public void Demo()
        {

        }
    }


}
