using System.Text.RegularExpressions;

var firstInput = Console.ReadLine() ?? throw new ArgumentNullException();
var secondInput = Console.ReadLine() ?? throw new ArgumentNullException();

Validate(firstInput);
Validate(secondInput);

var f = firstInput.Split().Select(int.Parse).ToArray();
var s= secondInput.Split().Select(int.Parse).ToArray();

var x = Math.Max(Math.Abs(f[0] - s[2]), Math.Abs(s[0] - f[2]));
var y = Math.Max(Math.Abs(f[1] - s[3]), Math.Abs(s[1] - f[3]));

var max = Math.Max(x, y);

Console.WriteLine(max * max);

void Validate(string input)
{
   if (Regex.Matches(input, "[^0-9\\s]").Count > 0) 
      throw new ArgumentOutOfRangeException();
}