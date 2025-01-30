// 원본 파일 경로를 설정합니다.
string inputFile = Path.Combine(AppContext.BaseDirectory, "input.txt");

// 결과 파일 경로를 설정합니다.
string outputFile = Path.Combine(AppContext.BaseDirectory, "output.txt");

// 제거할 문자열을 설정합니다.
string targetString = "data";

// 파일 읽기
// inputFile에서 모든 줄을 읽어와 배열로 저장합니다. 처음 5줄은 제외합니다.
string[] lines = [.. File.ReadAllLines(inputFile).Skip(5)];

// 각 줄에서 targetString과 ":"를 제거하고, 앞뒤 공백을 제거합니다.
lines = [.. lines.Select(line => line.Trim().Replace(targetString, string.Empty).Replace(":", string.Empty))];

// lines 배열에서 가장 긴 줄의 길이를 구합니다.
int maxLen = lines.Max(line => line.Length);

// 회전된 텍스트를 저장할 배열을 생성합니다.
string[] rotatedLines = new string[maxLen];

// 텍스트를 90도 회전합니다.
for (int i = 0; i < maxLen; i++)
{
    // 각 줄을 회전하여 새로운 줄을 생성합니다.
    rotatedLines[i] = new string([.. Enumerable.Range(0, lines.Length)
        .Select(j => (i < lines[j].Length) ? lines[j][i] : ' ')  // 각 문자를 선택합니다. 길이가 짧으면 공백을 추가합니다.
        .Reverse()]);  // 배열로 변환하여 문자열로 만듭니다.
}

// 결과 파일에 회전된 텍스트를 씁니다.
File.WriteAllLines(outputFile, rotatedLines);

// 결과 파일이 저장되었음을 콘솔에 출력합니다.
Console.WriteLine($"회전된 텍스트가 '{outputFile}'에 저장되었습니다.");
