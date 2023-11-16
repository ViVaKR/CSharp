using System.Diagnostics;

namespace MazeGame
{
    public partial class MainForm : Form
    {
        private int[,]? Maze { get; set; }

        private bool[,]? IsVisited { get; set; }

        private readonly Point[] directions;
        private readonly Panel panel;

        private int wallSize;
        private int WallSize
        {
            get => wallSize;
            set
            {
                wallSize = value;

                // �гΰ� �̱� ������ ����
                // �г� ���μ��� �� �̱� ������� ������ ���� ��
                // 0 �� �ƴϸ� �������� �Ҽ����� �����ϰ�
                // �⺻ ������ �̱ñ׸��� ������ 1�� ������ �� �׸��� 1�� ���� (wallSize)
                var modCheck = rectSize % WallSize;
                panel.Width = panel.Height -= modCheck == 0 ? wallSize : wallSize * 2;

                // �г��� �߾ӿ� ��ġ�ϱ�
                PanelSetPosition();

            }
        }

        private readonly int count; // ����
        private readonly int rectSize = 1000; // �̱��� ���� ���� (������ ������ ���� �ż�, 500�� ������ ��Ʈ)
        private readonly Padding padding = new(0);
        private Random? random; // = new(Guid.NewGuid().GetHashCode());

        public MainForm()
        {
            InitializeComponent();

            #region MainForm
            Padding = padding;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            Controls.Add(panel = new Panel { Location = new Point(0, 0), Width = rectSize, Height = rectSize });
            #endregion

            directions = new[] { new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) };

            // (1) ���ǿ� ���� �亯 ��Ʈ
            // ���� ���� �̷��� ���⵵ ����
            count = 50;

            panel.BackColor = Color.Yellow;

            ResizeEnd += (s, e) =>
            {
                PanelSetPosition();
                panel.Invalidate();
            };
            panel.Paint += Panel_Paint;

            Load += (s, e) => // �� �ε� �̺�Ʈ�� �� ������ ����Ŭ�� ����� Ÿ�̹� ����
            {
                WindowState = FormWindowState.Maximized;
                panel.Resize += Panel_Resize;
                Thread.Sleep(1);
                WallSize = Convert.ToInt32(Math.Floor(rectSize / (decimal)count));
                IsVisited = new bool[count, count];
                Maze = new int[count, count];
                InitiallizeMaze();
                Run();
            };
        }

        private void Panel_Resize(object? sender, EventArgs e)
        {
            panel.Invalidate(true);
        }

        private void PanelSetPosition()
        {
            panel.Left = (Width - panel.Width) / 2;
            panel.Top = (Height - panel.Height) / 2;
            panel.Invalidate(true);
        }
        public static Rectangle GetBounds(Control control) => Screen.FromControl(control).Bounds;

        private void InitiallizeMaze()
        {
            if (Maze != null && IsVisited != null) // �ܼ� �� äũ
            {
                for (int col = 0; col < count; col++)
                {
                    for (int row = 0; row < count; row++)
                    {
                        IsVisited[col, row] = false;
                        Maze[col, row] = 1;
                    }
                }
            }
        }

        private void Panel_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int col = 0; col < count - 1; col++)
            {
                for (int row = 0; row < count - 1; row++)
                {
                    if (Maze != null && Maze[col, row] == 1)
                        g.FillRectangle(Brushes.Black, WallSize * col, WallSize * row, WallSize, WallSize);
                }
            }
        }

        private List<T> ShuffleList<T>(List<T> dirs)
        {
            random = new(Guid.NewGuid().GetHashCode());
            
            for (int i = 0; i < dirs.Count; i++)
            {
                int j = random.Next(i, dirs.Count);
                (dirs[j], dirs[i]) = (dirs[i], dirs[j]);
            }
            return dirs;
        }

        private bool ToBeOrNotToBeThatIsQnQ(int nextCol, int nextRow)
        {
            return
            (nextCol >= 0 && nextCol < count - 1) && // (2)�캯�� �º��� ����� 1�� ���� 
            (nextRow >= 0 && nextRow < count - 1) && // �ʱ�ȭ �� �̹� ���� ��������Ƿ� �ش� �κ��� �״�� �α�
            (IsVisited != null &&
            !IsVisited[nextCol, nextRow]);
        }

        private void GenerateMaze(int col, int row)
        {
            if (IsVisited == null || Maze == null) return;
            IsVisited[col, row] = true;
            Maze[col, row] = 0;
            var directions = ShuffleList(new List<int> { 0, 1, 2, 3 });
            foreach (int direction in directions)
            {
                int nextCol = col + this.directions[direction].X * 2;
                int nextRow = row + this.directions[direction].Y * 2;
                if (ToBeOrNotToBeThatIsQnQ(nextCol, nextRow))
                {
                    var dx = col + this.directions[direction].X;
                    var dy = row + this.directions[direction].Y;
                    Maze[dx, dy] = 0;
                    GenerateMaze(nextCol, nextRow);
                }
            }
        }

        // (1)���� ����Ʈ�� 0,0 ���� 1,1 �� ������
        private async Task Run() => await Task.Run(()=> GenerateMaze(1, 1));
    }
}