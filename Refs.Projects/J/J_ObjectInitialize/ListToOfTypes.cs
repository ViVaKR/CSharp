using System.Collections;

namespace J_ObjectInitialize;

public class ListToOfTypes
{
	public void Run()
	{
		ArrayList fruits = new(4)
		{
			"Mango",
			"Orange",
			"Apple",
			"127",
			4567,
			"Banana"
		};

		IEnumerable<int> query
		= fruits.OfType<int>();
		foreach (var item in query)
		{
			Console.WriteLine($"{item}");
		}
	}
}

