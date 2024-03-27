
using Tutor.Abstract;

var sq = new Square(12);

Console.WriteLine($"square = {sq.GetArea()}");

var o = new DerivedClass();
o.AbstractMethod();
Console.WriteLine($"x = {o.X}, y = {o.Y}");
