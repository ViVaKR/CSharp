using System.Text;
namespace Helper;
public class Item
{
    public string Description { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public DateTime? ExpirationDate { get; set; }
    public string Sku { get; set; } = string.Empty;
}

public class ReadCsv
{
    public void Run()
    {
        var pretty = string.Join("", Enumerable.Repeat("-", 100));
        var data = File.ReadAllLines("items.csv", Encoding.UTF8).ToList();
        var lines = new List<Item>(data.Count);
        foreach (var line in data)
        {
            var cols = line.Split(',');
            Item item = new Item();
            item.Description = cols[0];
            item.Sku = cols[1];
            item.Price = cols[2];
            if (cols.Length > 3)
            {
                bool tf = DateTime.TryParse(cols[3], out DateTime date);
                item.ExpirationDate = tf ? date : null;
            }
            lines.Add(item);
        }
        string[] titles = { "Item", "Sku", "Price", "Expires" };
        Console.WriteLine($"\n{string.Join("", Enumerable.Repeat("-", 100))}");
        Console.WriteLine($"{titles[0].PadRight(40)}\t{titles[1].PadLeft(10)}\t{titles[2].PadLeft(10)}\t{titles[3].PadLeft(20)}");
        Console.WriteLine($"{string.Join("", Enumerable.Repeat("-", 100))}");
        foreach (var item in lines)
        {
            Console.WriteLine(
                $"{item.Description.PadRight(40)}\t" +
                $"{item.Sku.PadLeft(10)}\t" +
                $"{item.Price.PadLeft(10)}\t" +
                $"{item.ExpirationDate?.ToString("yyyy-MM-dd").PadLeft(20)}");
        }

        Console.WriteLine(pretty);
        var sum = lines.Select(s => new { 합계 = Convert.ToDouble(s.Price) }).Sum(x => x.합계);
        Console.WriteLine($"합계\t:{string.Empty.PadLeft(57)}{sum:n2}");
        Console.WriteLine(pretty);
    }
}
