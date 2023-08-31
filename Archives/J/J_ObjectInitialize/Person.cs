
using System.Collections.Generic;
using System.Collections;

namespace J_ObjectInitialize;

public class Person
{
	public readonly string name;
	public readonly int age;

	public Person(string name, int age)
	{
		this.age = age;
		this.name = name;
	}
}

public class PeopleEnum : IEnumerator
{
	public Person[] _people;

	private int position = -1;

	public PeopleEnum(Person[] list)
	{
		_people = list;
	}

	public bool MoveNext()
	{
		position++;
		return position < _people.Length;
	}

	public void Reset()
	{
		position = -1;
	}

	object IEnumerator.Current
	{
		get => Current;
	}

	public Person Current
	{
		get
		{
			try
			{
				return _people[position];
			}
			catch (IndexOutOfRangeException)
			{
				throw new InvalidOperationException();
			}
		}
	}
}

public class People : IEnumerable
{
	private readonly Person[] _people;

	public People(Person[] persons)
	{
		_people = new Person[persons.Length];
		for (int i = 0; i < persons.Length; i++)
		{
			_people[i] = persons[i];
		}
	}

	public IEnumerator GetEnumerator()
	{
		return new PeopleEnum(_people);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
