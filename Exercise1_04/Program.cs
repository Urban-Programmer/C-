// See https://aka.ms/new-console-template for more information
Console.WriteLine("Type a value for a: ");
var a = int.Parse(Console.ReadLine());

Console.Write("New type a value for b: ");
var b = int.Parse(Console.ReadLine());

Console.WriteLine($"The value for a is {a}, and for b is {b}");
Console.WriteLine($"Sum: {a+b}");
Console.WriteLine($"Mul: {a*b}");
Console.WriteLine($"Sub: {a-b}");
Console.WriteLine($"Div: {a/b}");

