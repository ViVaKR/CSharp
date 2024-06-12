using Microsoft.Data.SqlClient;
namespace AdoNetEx;

public class ColorTable
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string HexCode { get; set; }
    public required string DecimalCode { get; set; }
}

public class Utility
{
    public static async Task<List<ColorTable>?> GetColorTableAsync()
    {
        using SqlConnection connection = new("connectionString");
        await connection.OpenAsync(); // 비동기로 연결 열기
        using var command = connection.CreateCommand(); // 명령 객체 생성
        command.CommandText = "SELECT * FROM ColorTables;"; // SQL 명령 설정
        using var reader = await command.ExecuteReaderAsync(); // 데이터 읽기
        List<ColorTable> tables = []; // 데이터 테이블 목록 생성
        while (await reader.ReadAsync())
        {
            ColorTable table = new()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader["Name"]?.ToString() ?? string.Empty,
                HexCode = reader["HexCode"]?.ToString() ?? string.Empty,
                DecimalCode = reader["DecimalCode"]?.ToString() ?? string.Empty
            };
            tables.Add(table);
        }
        return tables;
    }
}
