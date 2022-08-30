var count = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());

var map = new Dictionary<int, int>();
for (int i = 0; i < count; i++)
{
   var input = Console.ReadLine() ?? throw new ArgumentNullException();
   var hash = 0;
   unchecked
   {
      foreach (var s in input.Split())
      {
         hash += s.GetHashCode();
      }
   }

   if (map.TryAdd(hash, 1) == false) ++map[hash];
}

Console.WriteLine(map.Values.Max());