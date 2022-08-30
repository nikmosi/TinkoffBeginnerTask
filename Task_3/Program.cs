var count = Console.ReadLine() ?? throw new ArgumentNullException(); 
var input = Console.ReadLine() ?? throw new ArgumentNullException();

var data = input.Split().Select(int.Parse);

var enumerable = data as int[] ?? data.ToArray();
if (enumerable.ToArray().Length != Int32.Parse(count))
   throw new ArgumentOutOfRangeException();

var index = 0;
var sum = 0;
var minmax = new int[4];
minmax[0] = minmax[2] = int.MaxValue;

foreach (var i in enumerable)
{
   var offset = index * 2;
   minmax[0 + offset] = Math.Min(minmax[0 + offset], i); 
   minmax[1 + offset] = Math.Max(minmax[1 + offset], i); 

   sum += i * (index == 0 ? 1 : -1);
   index++;
   index %= 2;
}

Console.WriteLine(sum + (minmax[3] - minmax[0]) * 2);