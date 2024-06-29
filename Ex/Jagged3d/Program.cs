
int[][][] jagged3d =
[
    [Enumerable.Range(1, 100).Where(x=> x % 2 == 0).ToArray(), [121, 122, 123]],
    [[211], [221, 222, 223, 224], Enumerable.Range(1, 30).ToArray()],
    [[311, 312, 313], [321],[611], [621, 622, 623], [711, 712, 713], [721]],
    [Enumerable.Range(1, 30).Select(i => new Random().Next(1, 100)).ToArray()],
    [[911, 912]],
    [[1011], [1021, 1022, 1023, 1024]],
    [[1411, 1412], [1421, 1422, 1423, 1424]],
    Enumerable.Repeat(Enumerable.Range(1, 10).ToArray(), 5).ToArray(),
    [[3511, 3512], [3521, 3522]],
    [[3611], [3621, 3622, 3623]],
    [[3711, 3712, 371],[3711, 3712, 371]],
    [Enumerable.Range(1,100).Where(x=> IsPrime(x)).ToArray(),
    Enumerable.Range(101,1000).Where(x=> IsPrime(x)).ToArray(),
    Enumerable.Range(1001,10000).Where(x=> IsPrime(x)).ToArray(),]
];

int[][][] ints = [
    [
        [1,2,3],
        [4,5,6]
    ],
    [
        [7,8,9],
        [10,11,12]
    ],
    [
        [13,14,15],
        [16,17,18]
    ]
];

int[][][] ints1 = new int[5][][];

ints1[0] = new int[2][];
ints1[0][0] = [1, 2, 3];
ints1[0][1] = [4, 5, 6];

ints1[1] = new int[2][];
ints1[1][0] = [7, 8, 9];
ints1[1][1] = [10, 11, 12];

ints1[2] = new int[2][];
ints1[2][0] = [13, 14, 15];
ints1[2][1] = [16, 17, 18];

ints1[3] = new int[2][];
ints1[3][0] = [19, 20, 21];
ints1[3][1] = [22, 23, 24];

ints1[4] = new int[2][];
ints1[4][0] = [25, 26, 27];
ints1[4][1] = [28, 29, 30];







static bool IsPrime(int number)
{
    if (number < 2) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;

    return true;
}

foreach (var i in jagged3d)
{
    foreach (var j in i)
    {
        foreach (var k in j)
        {
            Console.Write(k + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

var item = jagged3d[7][3][9];

Console.WriteLine(item);
