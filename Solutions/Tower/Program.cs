//========== 피라미드 공사 시작 ==========//
// 구현 알고리즘 설명: 
// -> 다양한 층수 구현을 위하여 입력된 층수를 지정
// -> 구현 클래스 라이브러리의, Recurstion (재귀함수)를 이용하여 
// -> 층별 string 을 List<string> 에 저장한 후
// -> 리스트로 부터 취향에 맞게 출력하는 알고리즘
// 피라미드 구현 클래스 인스턴스 생성 //

const int plan = 9;
var tower = new Tower(plan);

// 한줄 모냥내기
Console.WriteLine();

// 촘촘하고 빼죽하면서
// 사이사이 라인이 그러진 피라미드 만들기
Console.WriteLine("== 촘촘하게 ==");
Console.WriteLine();
foreach (var item in tower.lines)
{
    // 왼쪽 공간 수
    int cnt = (((tower.bottom) - item.Length) / 2);
    // 라인 케릭터를 별 케릭어 수와 동일하게 맞추기
    var underLine = new string('-', item.Length);
    // 정 중앙 만들기 위한 왼쪽 공간 수 구하기
    var leftSpace = cnt > 0 ? new String(' ', cnt) : string.Empty;
    // 라인 왼쪽 공간을 구현하기 
    var str = item.Insert(0, leftSpace);
    // 피라미드 별 벽돌 그리기
    Console.WriteLine(str);
    // 피라미드 라인 계단 그리기
    Console.WriteLine(underLine.Insert(0, leftSpace));
}

// 한줄 띄기 (미용파트)
Console.WriteLine();

// 널찍하고 안정감 있게 피라미드 만들기
Console.WriteLine("== 널찍하게 ==");
Console.WriteLine();
foreach (var item in tower.lines)
{
    // 가운데 정렬을 위하여 별수에 따른 왼쪽 공간의 수 구하기
    int cnt = (((tower.bottom) - item.Length) / 2);
    // 왼쪽에 빈 공간을 넣어 삼각형 만들기
    var str = item.Insert(0, cnt > 0 ? new String(' ', cnt) : string.Empty);

    // 별 라인 문자에서 사이 사이에 공간 문자 넣기 표현식
    var rs = System.Text.RegularExpressions.Regex.Replace(str, ".{1}", "$0 ");
    // 피라미드 그리기
    Console.WriteLine(rs);
}

Console.WriteLine();
Console.WriteLine($"참조 => Last Of List -> {tower.lines.Last()}");
Console.WriteLine($"참조 => First Of List => {tower.lines.First()}");
Console.WriteLine();

/// <summary>
/// 피라미드 구현 클래스 라이브러리
/// </summary>
public class Tower
{
    // 층수에 따라 바닥 타일 수 설정 속성
    public int bottom { get; set; }

    // 층별 라인 목록
    public List<string> lines { get; set; }

    public Tower(int floor)
    {
        // 바닥 타일 수 할당
        bottom = Math.Abs(1 - (2 * floor));

        // 층별 라인 목록 변수 초기화 
        lines = new List<string>();

        // 피라미드 만들기
        MakeTower(bottom, '*');
    }

    /// <summary>
    /// Make Tower By Recursition Method
    /// 재귀함수를 이용한 피라미드(타워) 쌓기
    /// </summary>
    /// <param name="number">바닥 별표의 숫자 (층수에서 자동계산)</param>
    /// <param name="draw">바닥을 그릴 char</param>
    private void MakeTower(int number, char draw)
    {
        // base case
        if (number < 1) return;

        // 각 층별로 양짝 줄이면서
        // Call Stack (콜 스택 쌓기)
        MakeTower(number - 2, draw);

        // 다 만들고 나서 콜스택으로 부터 하나썩 꺼내 
        // 각 층별로 별표 찍기 문자열 생성
        // 추가 가공을 위하여 목록에 저장해 놓기
        lines.Add(new string(draw, number));
    }
}

//== 재귀함수가 작동하는, 돌아가는 알고리즘 해석 ==//
// Call Stack Orders , 7층을 기준으로 함.
// 재귀함수가 콜스택에 쌓고(1층이 스택바닥) 빼내는 순서 //
//================================================================================================//
// 1. 층 13개   -> return 6 -> List index 6 : 즉, 리스트 목록에 마지막 인덱스에 바닥 별(*)이 들어가 있음 
// 2. 층 11개   -> return 5 -> List index 5 
// 3. 층 9개    -> return 4 -> List index 4 
// 4. 층 7개    -> return 3 -> List index 3 
// 5. 층 5개    -> return 2 -> List index 2 
// 6. 층 3개    -> return 1 -> List index 1 
// 7. 층 1개    -> return 0 -> List index 0  : 즉, 리스트 목록에 처음 인덱스에 꼭대기 별(*)이 들어가 있음
//================================================================================================//
// 8. -1 층으로 서 bae case 조건 트리거로 재귀 함수 리턴 시작 -> return 0
