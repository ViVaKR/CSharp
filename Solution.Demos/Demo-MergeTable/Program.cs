
using System.Data;

// DemoMergeTable();

/* 
static void DemoMergeTable()
{
    var table1 = new DataTable("Items");

    // Add columns
    var id = new DataColumn("Id", typeof(int));
    var item = new DataColumn("Item", typeof(int));
    table1.Columns.Add(id);
    table1.Columns.Add(item);
    table1.PrimaryKey = new DataColumn[] { id };

    // Add RowChanged event handler for the table.
    table1.RowChanged += (s, e) =>
    {
        Console.WriteLine($"Row Changed {e.Action} {e.Row.ItemArray[0]}");
    };
    Console.WriteLine("\nBegin Rows Add");
    DataRow row;
    for (int i = 0; i < 10; i++)
    {
        row = table1.NewRow();
        row["Id"] = i;
        row["Item"] = i;
        table1.Rows.Add(row);
    }
    Console.WriteLine("\nBegin AcceptChanges");
    table1.AcceptChanges();
    PrintRecords(table1, "Original");

    // 첫번째와 동일한 두번째 데이 테이블을 만듦
    var table2 = table1.Clone();
    table2.Columns.Add("Memo", typeof(string));
    for (int i = 0; i < 3; i++)
    {
        row = table2.NewRow();
        row["Id"] = i + 100;
        row["Item"] = i + 200;
        row["Memo"] = $"New Column {i}";
        table2.Rows.Add(row);
    }

    Console.WriteLine("Merging");
    table1.Merge(table2, false, MissingSchemaAction.Add);
    PrintRecords(table1, "Merged With table1, schema added");
}
 */

// 1. 호출 
DemoDataSet();
/// <summary>
/// 3. 출력 테스트
/// </summary>
/// <param name="table"></param>
/// <param name="label"></param>
static void PrintRecords(DataTable table, string title)
{
    Console.WriteLine(title);
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
        {
            Console.Write($"\t{row[col]}");
        }
        Console.WriteLine();
    }
}

/// <summary>
/// 2. 데이터 셋 선언 후 테이블 생성하기
/// </summary>
static void DemoDataSet()
{
    // 데이터 셋 선언
    DataSet dataSet = new("MyDataSet");

    // 타겟 테이블 생성 -> 이름 지정 -> 타겟
    DataTable target = dataSet.Tables.Add("Target");

    // 타겟 테이블 컬럼 생성 (컬럼명, 컬럼 데이터 타입)
    DataColumn Id = target.Columns.Add("Id", typeof(Int32));
    target.Columns.Add("Qty", typeof(Int32));
    target.Columns.Add("Name", typeof(string));
    // 타겟 테이블 -> 기본 키 지정 (필수)
    target.PrimaryKey = new DataColumn[] { Id };

    // 타켓 테이블에 테스트용 레코드 추가하기
    DataRow row;
    for (int i = 0; i < 5; i++)
    {
        row = target.NewRow();
        row["Id"] = i + 1;
        row["Qty"] = i + 100;
        row["Name"] = $"My Name = {i + 201}";
        target.Rows.Add(row);
    }

    // 가로 구분선
    Console.WriteLine($"{string.Join(string.Empty, Enumerable.Repeat("-", Console.WindowWidth))}");

    // 타켓 테이블을 클론하여 소스 테이블을 똑같이 복제하여 만들기
    DataTable source = target.Copy();

    // 테이블 이름 변경하기
    source.TableName = "Source";

    // 데이터 셋에 추가하기
    dataSet.Tables.Add(source);

    // 소스 테이블에 컬럼 추가 및 
    // 테스트 레코드 추가하기 5개 (메모 컬럼이 늘어난 상태)
    source.Columns.Add("Memo", typeof(string));
    for (int i = 0; i < 5; i++)
    {
        row = source.NewRow();
        row["Id"] = i + 1000;
        row["Qty"] = i + 200;
        row["Name"] = $"My Name = {i + 501}";
        row["Memo"] = $"I am form source {i + 1234}"; // 추가된 컬럼
        source.Rows.Add(row);
    }


    var beforeTarget = dataSet.Tables[nameof(target)];
    if (beforeTarget == null) return;
    PrintRecords(beforeTarget, "머지 전 타겟?");

    // 가로 구분선
    Console.WriteLine($"{string.Join(string.Empty, Enumerable.Repeat("-", Console.WindowWidth))}");

    var beforeSource = dataSet.Tables[nameof(source)];
    if (beforeSource == null) return;
    PrintRecords(beforeSource, "머지 전 소스");

    // 가로 구분선
    Console.WriteLine($"{string.Join(string.Empty, Enumerable.Repeat("-", Console.WindowWidth))}");
    // 문이에 대한 참조용 답 부분
    target.Merge(source, false, MissingSchemaAction.Add);

    // 머지 출력 테스트
    var afterTarget = dataSet.Tables[nameof(target)];
    if (afterTarget == null) return;
    PrintRecords(afterTarget, "머지 후 타겟?");
}
