using System.Text;

namespace HanoiTower
{
    public class TowerOfHanoi
    {
        private int Count = 0; // 총 횟수
        private readonly int padding = 24; // A, B, C 판 사이의 패딩
        private readonly int level; // 판의 갯수

        // 각 장면 마다 콘솔 색상 변경하기 : 콘솔 색상의 총 갯수 = 16개
        private readonly ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

        // 각 핀의 판 (Peg) 상태 저장, 값을 판의 넓이 자체를 넣어둠
        private readonly Dictionary<int, string> pegA;
        private readonly Dictionary<int, string> pegB;
        private readonly Dictionary<int, string> pegC;

        public Dictionary<Peg, PegStatus> pegs;

        /// <summary>
        /// 생성자 파트
        /// </summary>
        /// <param name="dic">판이 디동할 판 딕셔너리</param>
        /// <param name="n">판의 갯수</param>
        public TowerOfHanoi(Dictionary<Peg, PegStatus> dic, int n)
        {
            level = n; // 판의 갯수

            pegs = dic; // 이동 할 바닥 판 

            // 각각의 바닥판에 상태 저장용 딕셔너리
            pegA = new();
            pegB = new();
            pegC = new();

            // 최초 시작판 초기화 (Start, A 바닥판)
            for (int i = 0; i < level; i++)
            {
                var pan = string.Join(string.Empty.PadRight(2), Enumerable.Repeat('\u23AF', Math.Abs(i - level)));
                pegA.Add(i, pan);
            }
            Console.Clear();
            DrawPeg(n, null, null);

            // 1. Caller
            MoveTowers(n, pegs[Peg.Start], pegs[Peg.Temp], pegs[Peg.End]);
        }

        /// <summary>
        /// Recursive Fuction
        /// </summary>
        /// <param name="n">판의 수</param>
        /// <param name="start">A - 출발지</param>
        /// <param name="temp">B - 경유지</param>/// 
        /// <param name="end">C - 목적지</param>
        public void MoveTowers(int n, PegStatus start, PegStatus temp, PegStatus end)
        {                                   //!   (A)              (B)           (c)
            if (n > 0)
            {
                //!                (A)   (C)   (B)
                MoveTowers(n - 1, start, end, temp);

                SetPegs(n, start.Peg, end.Peg); // 판이동

                //!                (B)   (A)   (C)
                MoveTowers(n - 1, temp, start, end);
            }
        }

        /// <summary>
        /// 콘솔에 판 이동 상황 출력하기
        /// </summary>
        /// <param name="b">빼는 판</param>
        /// <param name="c">넣는 판</param>
        private void SetPegs(int n, Peg? b, Peg? c)
        {
            string peg = string.Empty;

            // 판 빼기 로직
            switch (b)
            {
                case Peg.Start:
                    {
                        if (pegA.Any())
                        {
                            peg = pegA.Last().Value;
                            pegA.Remove(pegA.Keys.Last());
                        }

                    }; break;
                case Peg.Temp:
                    {
                        if (pegB.Any())
                        {
                            peg = pegB.Last().Value;
                            pegB.Remove(pegB.Keys.Last());
                        }
                    }; break;
                case Peg.End:
                    {
                        if (pegC.Any())
                        {
                            peg = pegC.Last().Value;
                            pegC.Remove(pegC.Keys.Last());
                        }
                    }; break;
            }

            // 판 넣기 로직
            switch (c)
            {
                case Peg.Start: pegA.Add(pegA.Count, peg); break;
                case Peg.Temp: pegB.Add(pegB.Count, peg); break;
                case Peg.End: pegC.Add(pegC.Count, peg); break;
            }
            DrawPeg(n, b, c);
        }

        /// <summary>
        /// 판 그리기
        /// </summary>
        private void DrawPeg(int n, Peg? from, Peg? to)
        {
            Console.Clear();
            var title = $"[{Count++}] Peg {n} : {from} -> {to}"; // 횟수 카운팅
            Console.WriteLine(string.Join(string.Empty, Enumerable.Repeat("=", title.Length)));
            Console.WriteLine(title);
            Console.WriteLine(string.Join(string.Empty, Enumerable.Repeat("=", title.Length)));

            // 세개의 딕셔너리에서 동일 인덱스의 판 을 라인별로 저장해 두기
            StringBuilder sb = new();

            for (int i = level - 1; i >= 0; i--)
            {
                pegA.TryGetValue(i, out string? peg_a); // 판 A, Start
                pegB.TryGetValue(i, out string? peg_b); // 판 B, Temp
                pegC.TryGetValue(i, out string? peg_c); // 판 C, End

                // 한 라인 구성
                sb.Append(peg_a?.PadRight(padding) ?? string.Empty.PadRight(padding));
                sb.Append(peg_b?.PadRight(padding) ?? string.Empty.PadRight(padding));
                sb.AppendLine(peg_c ?? string.Empty);
            }
            Console.Write(sb?.ToString());
            string line = string.Join(string.Empty, Enumerable.Repeat('=', 7));
            Console.WriteLine($"{line} A {line}\t{line} B {line}\t{line} C {line}\n");

            do
            {
                SetColor(new Random().Next(0, colors.Length));
            } while (Console.ForegroundColor == Console.BackgroundColor);

            // Thread.Sleep(3000);

            Console.WriteLine("`Q` 키를 제외한 모든 키를 누르시면 계속 진행합니다....");
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Q)
            {
                Console.WriteLine("\n하노이 타워를 종료합니다.");
                Environment.Exit(0);
            }
        }

        private void SetColor(int number) => Console.ForegroundColor = colors[number];
    }
}
