using System.Text;

namespace HanoiTower
{
    public class TowerOfHanoi
    {
        private int Count = 0; // 총 횟수
        private readonly int padding = 16; // A, B, C 판 사이의 패딩
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
                var pan = string.Join(string.Empty, Enumerable.Repeat("-", Math.Abs(i - level)));
                pegA.Add(i, pan);
            }

            // 최초 판 레이아웃 그리기
            DrawPeg();

            // 시작 키보드 입력 받기
            Console.WriteLine("하노이탑을 시작합니다. 엔터키를 누르세요 ... ");
            Console.ReadLine();

            // 판 움직임 시작 트리거
            MoveTowers(n, pegs[Peg.Start], pegs[Peg.End], pegs[Peg.Temp]);
        }

        public void MoveTowers(int n, PegStatus startPeg, PegStatus endPeg, PegStatus tempPeg)
        {
            if (n > 0)
            {
                MoveTowers(n - 1, startPeg, tempPeg, endPeg);
                Console.WriteLine($"Peg {startPeg.Alias} 를 {endPeg.Alias} 로 이동합니다.");

                // 문의에 대한 답변
                SetPegs(startPeg.Peg, endPeg.Peg);

                MoveTowers(n - 1, tempPeg, endPeg, startPeg);
            }
        }

        /// <summary>
        /// 콘솔에 판 이동 상황 출력하기
        /// </summary>
        /// <param name="b">빼는 판</param>
        /// <param name="c">넣는 판</param>
        private void SetPegs(Peg b, Peg c)
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
            DrawPeg();
        }

        /// <summary>
        /// 판 그리기
        /// </summary>
        private void DrawPeg()
        {
            var title = $"Count = {Count++}"; // 횟수 카운팅

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

            Console.WriteLine("-----A-----\t-----B-----\t-----C-----\n");

            do
            {
                SetColor(new Random().Next(0, colors.Length));
            } while (Console.ForegroundColor == Console.BackgroundColor);

            Thread.Sleep(3000);

        }

        private void SetColor(int number) => Console.ForegroundColor = colors[number];

    }
}
