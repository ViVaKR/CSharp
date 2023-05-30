using System;
using System.Drawing;
using System.Windows.Forms;

namespace J_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            textBox1.Text = $"안녕하세요 반갑습니다.{Environment.NewLine}Hello World{Environment.NewLine}Fine Thanks And You!";

            Load += MainForm_Load;

            Shown += (s, e) =>
            {
                textBox1.Text = $"{Width} - {Height}\r\n$\"안녕하세요 반갑습니다.{{Environment.NewLine}}Hello World{{Environment.NewLine}}Fine Thanks And You!\";";
            };
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            float ratio = 1.5f;

            SizeF scale = new SizeF(w / (w * ratio), h / (h * ratio));

            Scale(scale);

            foreach (Control control in this.Controls)
                control.Font = new Font(@"빙그레 따옴체", 15.5f, FontStyle.Regular);
        }
    }
}
