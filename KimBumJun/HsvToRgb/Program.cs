// See https://aka.ms/new-console-template for more information
// 예시: HSV(240, 1, 1) → RGB(0, 0, 255)

var hsvDict = new Dictionary<string, Tuple<double, double, double>>
        {
            { "Black", Tuple.Create(0.0, 0.0, 0.0) },
            { "White", Tuple.Create(0.0, 0.0, 1.0) },
            { "Red", Tuple.Create(0.0, 1.0, 1.0) },
            { "Lime", Tuple.Create(120.0, 1.0, 1.0) },
            { "Blue", Tuple.Create(240.0, 1.0, 1.0) },
            { "Yellow", Tuple.Create(60.0, 1.0, 1.0) },
            { "Cyan", Tuple.Create(180.0, 1.0, 1.0) },
            { "Magenta", Tuple.Create(300.0, 1.0, 1.0) },
            { "Silver", Tuple.Create(0.0, 0.0, 0.75) },
            { "Gray", Tuple.Create(0.0, 0.0, 0.5) },
            { "Maroon", Tuple.Create(0.0, 1.0, 0.5) },
            { "Olive", Tuple.Create(60.0, 1.0, 0.5) },
            { "Green", Tuple.Create(120.0, 1.0, 0.5) },
            { "Purple", Tuple.Create(300.0, 1.0, 0.5) },
            { "Teal", Tuple.Create(180.0, 1.0, 0.5) },
            { "Navy", Tuple.Create(240.0, 1.0, 0.5) },
        };

Console.WriteLine($"{"Color",-10} {"HSV",-20} {"RGB",-20}");
Console.WriteLine(new string('-', 50));

foreach (var kvp in hsvDict)
{
    var colorName = kvp.Key;
    var hsv = kvp.Value;
    (int r, int g, int b) = HsvToRgb(hsv.Item1, hsv.Item2, hsv.Item3);
    Console.WriteLine($"{colorName,-10} ({hsv.Item1,3}, {hsv.Item2,3}, {hsv.Item3,3}) → ({r,3}, {g,3}, {b,3})");
}

/* //==
List<Tuple<int, double, double>> hsvList = [
    Tuple.Create(0, .0, 0.0),
    Tuple.Create(0, .0, 1.0),
    Tuple.Create(0, 1.0, 1.0),
    Tuple.Create(120, 1.0, 1.0),
    Tuple.Create(240, 1.0, 1.0),
    Tuple.Create(60, 1.0, 1.0),
    Tuple.Create(180, 1.0, 1.0),
    Tuple.Create(300, 1.0, 1.0),
    Tuple.Create(0, .0, 0.75),
    Tuple.Create(0, .0, 0.5),
    Tuple.Create(0, 1.0, 0.5),
    Tuple.Create(60, 1.0, 0.5),
    Tuple.Create(120, 1.0, 0.5),
    Tuple.Create(300, 1.0, 0.5),
    Tuple.Create(180, 1.0, 0.5),
    Tuple.Create(240, 1.0, 0.5),

];

foreach (var hsv in hsvList)
{
    (int r, int g, int b) = HsvToRgb(hsv.Item1, hsv.Item2, hsv.Item3);
    Console.WriteLine($"HSV: ({hsv.Item1}, {hsv.Item2}, {hsv.Item3}) → RGB: ({r}, {g}, {b})");
}
 */
static (int, int, int) HsvToRgb(double h, double s, double v)
{
    double r = 0, g = 0, b = 0;

    int i = (int)(h / 60) % 6;
    double f = (h / 60) - i;
    double p = v * (1 - s);
    double q = v * (1 - f * s);
    double t = v * (1 - (1 - f) * s);

    switch (i)
    {
        case 0:
            r = v;
            g = t;
            b = p;
            break;
        case 1:
            r = q;
            g = v;
            b = p;
            break;
        case 2:
            r = p;
            g = v;
            b = t;
            break;
        case 3:
            r = p;
            g = q;
            b = v;
            break;
        case 4:
            r = t;
            g = p;
            b = v;
            break;
        case 5:
            r = v;
            g = p;
            b = q;
            break;
    }

    // RGB 값을 0-255 범위로 변환
    // 소수점 반올림 추가
    return (RoundToInt(r * 255), RoundToInt(g * 255), RoundToInt(b * 255));
}

static int RoundToInt(double value)
{
    return (int)Math.Round(value, MidpointRounding.AwayFromZero);
}

/*
static (int R, int G, int B) HsvToRgb(double h, double s, double v)
{
    if (s == 0) // 채도가 0이면 무채색
    {
        int gray = (int)(v * 255);
        return (gray, gray, gray);
    }

    h /= 60; // Hue를 60도로 나눔 (섹션 번호 계산)
    int i = (int)Math.Floor(h); // 섹션 번호 (0-5)
    double f = h - i;           // 섹션 내에서의 상대 위치 (0-1)

    double p = v * (1 - s);
    double q = v * (1 - s * f);
    double t = v * (1 - s * (1 - f));

    double r = 0, g = 0, b = 0;
    switch (i % 6)
    {
        case 0:
            r = v; g = t; b = p;
            break;
        case 1:
            r = q; g = v; b = p;
            break;
        case 2:
            r = p; g = v; b = t;
            break;
        case 3:
            r = p; g = q; b = v;
            break;
        case 4:
            r = t; g = p; b = v;
            break;
        case 5:
            r = v; g = p; b = q;
            break;
    }

    // RGB 값을 0-255 범위로 변환
    // 소수점 반올림 추가
    return (RoundToInt(r * 255), RoundToInt(g * 255), RoundToInt(b * 255));
}
 */

/* static int RoundToInt(double value)
{
    return (int)Math.Round(value, MidpointRounding.AwayFromZero);
}
 */
// double h = 300; // Hue (0-360), 색상을 나타냄, 각도로 표현
// double s = 1;   // Saturation (0-1), 채도를 나타냄, 선명도 또는 순도를 나타냄, 0 -> 무채색, 1 -> 채색(가장 선명한 색상)
// double v = 1;   // Value (0-1) , 명도를 나타냄, 밝기를 나타냄, 0 -> 검은색(아무리 채도가 높아도 어두움), 1 -> 흰색 (가장 밝은 색상)
// (int r, int g, int b) = HsvToRgb(h, s, v);
// Console.WriteLine($"RGB: ({r}, {g}, {b})");
// HSV 의 유용성
// - 인간의 시각적 인식 방식과 더 가깝게 동작하기 때문에 디자인, 컴퓨터 그래픿, 이미지 프로세싱에서 많이 사용됨.
/*

0°	빨강, 60°	노랑, 120°	초록, 180°	청록, 240°	파랑, 300°	자주
- 0°과 360°는 빨강색
- 60°은 노랑색
- 120°은 초록색
- 180°은 청록색
- 240°은 파랑색
- 300°은 자주색

- 채도(Saturation)가 0이면 무채색(회색)이 됨,
- 명도(Value)가 0이면 검은색이 됨

 */
