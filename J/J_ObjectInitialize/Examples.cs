using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J_ObjectInitialize;

public class Examples : IEnumerable<string>
{
	private readonly List<string> list = new();
	public IEnumerator<string> GetEnumerator()
	=> list.GetEnumerator();


	IEnumerator IEnumerable.GetEnumerator()
	=> list.GetEnumerator();

	public void Add(string item)
	=> list.Add(item);
}
