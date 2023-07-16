using J_ObjectInitialize;

var matrix = new Matrix
{
	[0, 0] = 1.3,
	[0, 1] = 0.2,
	[0, 2] = 0.5,
	[0, 3] = 0.75,

	[1, 0] = 1.1,
	[1, 1] = 1.2,
	[1, 2] = 1.3,
	[1, 3] = 1.4,

	[2, 0] = 2.2,
	[2, 1] = 2.3,
	[2, 2] = 2.4,
	[2, 3] = 2.5,

	[3, 0] = 3.1,
	[3, 1] = 3.3,
	[3, 2] = 3.4,
	[3, 3] = 4.5
};

matrix.Print();

//
var ex = new Examples
{
	"John", "Doe", "Jang", "Gil", "Hello", "World"
};

foreach (var item in ex)
{
	Console.WriteLine(item);

}

Person[] peopleArray = new Person[3]
{
	new Person ("John", 35),
	new Person ("Jim", 49),
	new Person ("Sue", 27)
};

People peopleList = new(peopleArray);
foreach (Person item in peopleList)
{
	Console.WriteLine($"{item.name} {item.age}");
}

var query = new ListToAsQueryable();
query.Run();

var list = new ListToOfTypes();
list.Run();

var all = new ExAll();
all.Run();
