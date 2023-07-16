using System.Linq.Expressions;

namespace J_ObjectInitialize;

public class ListToAsQueryable
{
	public void Run()
	{
		List<int> grades = new()
		{
			78, 92, 100, 37, 81
		};

		IQueryable<int> iquery = grades.AsQueryable();

		Expression tree = iquery.Expression;
		Console.WriteLine(tree.NodeType.ToString());
	}
}
