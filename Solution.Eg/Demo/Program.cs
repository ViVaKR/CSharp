using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

AppContext.SetData("GCHeapHardLimit", (ulong)100 * 1_024 * 1_024);
GC.RefreshMemoryLimit();
Console.WriteLine($"{DateTime.Now}");

List<int> list = [];

for (int i = 0; i < 20; i++)
{
    list.Add(i + 1);
}
int a = 10;
int b = 25;
int sum = a + b;
list.ForEach(x => Console.WriteLine($"{x}"));

JArray array =
[
    "Manul test",
    new DateTime(2000, 5, 23)
];

JObject o = new()
{
    ["MyArray"] = array
};

Console.WriteLine($"{o} {a} {b}");




JsonSerializer.Serialize<ReadOnlyMemory<byte>>(new byte[] { 1, 2, 3 });

JsonSerializer.Serialize<Memory<int>>(new int[] { 1, 2, 3 });
