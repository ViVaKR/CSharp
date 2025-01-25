using System.Text;

string inputPath = "orgin.txt";
var contents = File.ReadAllText(inputPath);
Console.WriteLine("원본 텍스트:");
Console.WriteLine(contents);

TransposeRowsToColumns(contents);

string[] matrix = contents.Split("\n");


var rs = ConvertBoxChars(matrix);
Console.WriteLine(string.Join("\n", rs));
// ...existing code...
static string[] ConvertBoxChars(string[] lines)
{
    lines = [.. lines.Skip(1).Select(line => line.Trim())];
    for (int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];

        // 한 줄 모두 '.'이면 가로선 (─)으로 변환
        if (line.All(ch => ch == '.'))
        {
            lines[i] = new string('─', line.Length);
        }
        else
        {
            // 일부만 '.'이면 세로선 (│)으로 치환
            char[] chars = line.ToCharArray();
            for (int j = 0; j < chars.Length; j++)
            {
                if (chars[j] == '.')
                {
                    chars[j] = '│';
                }
            }
            lines[i] = new string(chars);
        }
    }
    return lines;
}

// ...existing code...
static void TransposeRowsToColumns(string rowString)
{
    string[] rows = rowString.Split("\n");
    var modifiled = rows.Skip(1).Select(row => row.Trim()).ToArray();
    Console.WriteLine(string.Join("\n", modifiled));

    int maxLen = modifiled.Max(row => row.Length);
    char[,] matrix = new char[maxLen, modifiled.Length];

    for (int i = 0; i < maxLen; i++)
    {
        for (int j = 0; j < modifiled.Length; j++)
        {
            if (i < modifiled[j].Length)
                matrix[i, j] = modifiled[j][i];
            else
                matrix[i, j] = ' ';
        }
    }


    StringBuilder sb = new StringBuilder();
    Enumerable.Range(0, matrix.GetLength(0))
        .Select(row =>
            string.Join(" ", Enumerable.Range(0, matrix.GetLength(1))
                .Select(col => matrix[row, col])))
        .ToList()
        .ForEach(line => sb.AppendLine(line));

    Console.WriteLine(sb.ToString());
}

// // ...existing code...
// static void TransposeRowsToColumns(string rowString)
// {
//     string[] rows = rowString.Split("\n");
//     var modifiled = rows.Skip(1).Select(row => row.Trim()).ToArray();

//     // 원본에서 '.' -> '─' 또는 '│' 처리
//     modifiled = ConvertDots(modifiled);

//     int maxLen = modifiled.Max(row => row.Length);
//     char[,] matrix = new char[maxLen, modifiled.Length];

//     for (int i = 0; i < maxLen; i++)
//     {
//         for (int j = 0; j < modifiled.Length; j++)
//         {
//             matrix[i, j] = (i < modifiled[j].Length) ? modifiled[j][i] : ' ';
//         }
//     }

//     // 회전시킨 결과를 문자열 배열로
//     var transposedLines = Enumerable.Range(0, matrix.GetLength(0))
//         .Select(row => new string(
//             Enumerable.Range(0, matrix.GetLength(1))
//                 .Select(col => matrix[row, col])
//                 .ToArray()))
//         .ToArray();

//     // 회전된 결과도 '.' -> '─' 또는 '│' 처리
//     transposedLines = ConvertDots(transposedLines);

//     Console.WriteLine("원본 변환 결과:");
//     Console.WriteLine(string.Join("\n", modifiled));
//     Console.WriteLine("\n회전 변환 결과:");
//     Console.WriteLine(string.Join("\n", transposedLines));
// }

// // '.'을 가로선(U+2500) 또는 세로선(U+2502)로 변환
// static string[] ConvertDots(string[] lines)
// {
//     for (int i = 0; i < lines.Length; i++)
//     {
//         // 모두 '.'이면 가로선
//         if (lines[i].All(ch => ch == '.'))
//         {
//             lines[i] = new string('─', lines[i].Length);
//         }
//         else
//         {
//             char[] chars = lines[i].ToCharArray();
//             // 첫 글자 또는 마지막 글자가 '.'이면 세로선
//             if (chars.Length > 0 && chars[0] == '.') chars[0] = '│';
//             if (chars.Length > 0 && chars[chars.Length - 1] == '.') chars[chars.Length - 1] = '│';
//             lines[i] = new string(chars);
//         }
//     }
//     return lines;
// }
// // ...existing code...

// ...existing code...
// static void TransposeRowsToColumns(string rowString)
// {
//     // 그대로 유니코드를 유지한 상태로 행렬에 담는다
//     string[] lines = rowString.Split('\n');

//     int maxLen = lines.Max(line => line.Length);
//     char[,] matrix = new char[maxLen, lines.Length];

//     // 행렬에 저장 (세로 인덱스=줄, 가로 인덱스=열)
//     for (int row = 0; row < lines.Length; row++)
//     {
//         for (int col = 0; col < lines[row].Length; col++)
//         {
//             matrix[col, row] = lines[row][col];
//         }
//     }
// }

//     // 행렬을 회전한 결과를 다시 문자열로
//     StringBuilder sb = new StringBuilder();
//     for (int col = 0; col < maxLen; col++)
//     {
//         for (int row = 0; row < lines.Length; row++)
//         {
//             sb.Append(matrix[col, row]);
//         }
//         sb.AppendLine();
//     }

//     Console.WriteLine(sb.ToString());
// }
// // ...existing code...
