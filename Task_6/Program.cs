var count = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());

var map = new Dictionary<int, HashSet<int>>();

for (int i = 0; i < count; i++)
{
   var input = (Console.ReadLine() ?? throw new ArgumentNullException())
      .Split()
      .Select(int.Parse)
      .ToArray();

   if (map.ContainsKey(input[0]))
   {
      map[input[0]].Add(input[1]);
   }
   else
   {
      map.Add(input[0], new HashSet<int>() { input[1] });
   }
}

Console.WriteLine(GetLongWay(map, map.Keys.Min()));

int GetLongWay(Dictionary<int, HashSet<int>> graph, int start)
{
   var marked = new HashSet<int>();
   var queue = new Queue<int>();
   var distanceMap = new Dictionary<int, int>();
   
   queue.Enqueue(start);
   distanceMap.Add(start, 1);

   while (queue.Any())
   {
      var point = queue.Dequeue();
      var distanceToPoint = distanceMap[point];
      var connectedPoints = graph.TryGetValue(point, out var p) ? p : Enumerable.Empty<int>().ToHashSet();

      if (connectedPoints.Contains(point)) 
         ++distanceToPoint;

      var distanceToConnectedPoint = distanceToPoint + 1;
      foreach (var connectedPoint in connectedPoints.Where(i => i != point))
      {
         if (marked.Contains(connectedPoint))
         {
            var previousDistanceToConnectedPoints = distanceMap[connectedPoint];
            if (previousDistanceToConnectedPoints < distanceToConnectedPoint)
            {
               marked.Remove(connectedPoint);
               queue.Enqueue(connectedPoint);
               distanceMap[connectedPoint] = distanceToConnectedPoint;
            }
         }
         else
         {
            distanceMap.Add(connectedPoint, distanceToConnectedPoint);
            queue.Enqueue(connectedPoint);
         }
      }

      marked.Add(point);
   }

   return distanceMap.MaxBy(x => x.Value).Key;
}