using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J_ObjectInitialize;

public class ExAll
{
	public void Run()
	{
		int[] numbers = { 1, 2, 3, 4, 5 };
		var sum = numbers.Aggregate(2000, (a, b) =>  a += b, x=> x += 1000);
		Console.WriteLine($"Sum : {sum}");
	}
}
