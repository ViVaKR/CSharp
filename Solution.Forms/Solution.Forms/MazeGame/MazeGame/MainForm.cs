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

                // 패널과 미궁 사이즈 보정
                // 패널 가로세로 과 미궁 벽사이즈를 나머지 연산 후
                // 0 이 아니면 버려지는 소숫점을 보정하고
                // 기본 적으로 미궁그리는 시작점 1과 마지막 덜 그리는 1은 빼줌 (wallSize)
                var modCheck = rectSize % WallSize;
                panel.Width = panel.Height -= modCheck == 0 ? wallSize : wallSize * 2;

                // 패널을 중앙에 위치하기
                PanelSetPosition();

            }
        }

        private readonly int count; // 깊이
        private readonly int rectSize = 1000; // 미궁의 가로 세로 (사이즈 고정을 위해 신설, 500과 동일한 파트)
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

            // (1) 문의에 대한 답변 파트
            // 길의 수로 미로의 복잡도 구성
            count = 50;

            panel.BackColor = Color.Yellow;

            ResizeEnd += (s, e) =>
            {
                PanelSetPosition();
                panel.Invalidate();
            };
            panel.Paint += Panel_Paint;

            Load += (s, e) => // 폼 로드 이벤트로 폼 라이프 사이클과 드로잉 타이밍 조정
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
            if (Maze != null && IsVisited != null) // 단순 널 채크
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
            (nextCol >= 0 && nextCol < count - 1) && // (2)우변과 좌변의 사이즈를 1씩 줄임 
            (nextRow >= 0 && nextRow < count - 1) && // 초기화 때 이미 벽을 만들었으므로 해당 부분은 그대로 두기
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

        // (1)시작 포인트를 0,0 에서 1,1 로 변경함
        private async Task Run() => await Task.Run(()=> GenerateMaze(1, 1));
    }
}