int n = 3; // 원반의 개수
char from = 'A'; // 출발 기둥
char to = 'C'; // 목적지 기둥
char aux = 'B'; // 보조 기둥

Console.WriteLine("하노이 탑 문제 해결 과정:");
HanoiTower(n, from, to, aux);

static void HanoiTower(int n, char from, char to, char aux)
{
    if (n == 1)
    {
        Console.WriteLine($"원반 1을 {from}에서 {to}로 이동");
        return;
    }

    // n-1개의 원반을 출발 기둥에서 보조 기둥으로 이동
    HanoiTower(n - 1, from, aux, to);

    // 가장 큰 원반을 출발 기둥에서 목적지 기둥으로 이동
    Console.WriteLine($"원반 {n}을 {from}에서 {to}로 이동");

    // n-1개의 원반을 보조 기둥에서 목적지 기둥으로 이동
    HanoiTower(n - 1, aux, to, from);
}
