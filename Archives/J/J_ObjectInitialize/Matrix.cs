using System.Linq;

namespace J_ObjectInitialize;
public class Matrix
{
	private readonly double[,] points = new double[4, 4];

	public double this[int row, int column]
	{
		get => points[row, column];
		set => points[row, column] = value;
	}

	public void Print()
	{
		for (int i = 0; i < points.GetLength(0); i++)
		{
			for (int j = 0; j < points.GetLength(1); j++)
			{
				Console.WriteLine($"{points[i, j]}");
			}
		}
	}
}
