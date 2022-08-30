var input = (Console.ReadLine() ?? throw new ArgumentNullException())
   .Split().Select(int.Parse).ToArray();

var workers = Enumerable.Range(0, input.ElementAt(0)).Select(x => Console.ReadLine() ?? throw new ArgumentNullException()).ToArray();
var queryCount = input.ElementAt(1);
var indexs = new List<int>(queryCount);

for (int i = 0; i < queryCount; i++)
{
   var q = (Console.ReadLine() ?? throw new ArgumentNullException())
      .Split();
   var indexOf = Array.IndexOf(workers, workers
      .Where(x => x.StartsWith(q[1]))
      .OrderBy(x => x)
      .Skip(int.Parse(q[0]) - 1)
      .First()
   );
   indexs.Add(indexOf + 1);
}

Console.WriteLine(string.Join('\n', indexs));
Console.WriteLine();