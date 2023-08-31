
using HanoiTower;

internal class Program
{
    private static void Main()
    {
        // 판 3종 (A, B, C) 초기화
        var start = new PegStatus(Peg.Start); // A
        var end = new PegStatus(Peg.End); // B
        var temp = new PegStatus(Peg.Temp); // C

        // 전체 대상 판의 갯수 (Console.ReadLine() 으로 값을 받는 부분, 데모를 위하여 상수로 설정)
        const int n = 5;

        // 판 묶음 딕셔너리 구성
        var dic = new Dictionary<Peg, PegStatus>
        {
            {Peg.Start, start},
            {Peg.Temp, temp},
            {Peg.End, end}
        };

        // 트리거
        _ = new TowerOfHanoi(dic, n);
    }
}
