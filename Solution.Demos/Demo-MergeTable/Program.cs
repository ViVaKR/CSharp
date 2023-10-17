
using System.Data;

DemoMergeTable();

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
    PrintValues(table1, "Original");

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
    PrintValues(table1, "Merged With table1, schema added");
}

static void PrintValues(DataTable table, string label)
{
    // Display the values in the supplied DataTable:
    Console.WriteLine(label);
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
        {
            Console.Write($"\t {row[col]}");
        }
        Console.WriteLine();
    }
}
