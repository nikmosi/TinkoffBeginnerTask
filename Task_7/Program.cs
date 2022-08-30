var word = Console.ReadLine()?.ToArray() ?? throw new ArgumentNullException();
var segmentCount = int.TryParse(Console.ReadLine(), out var n) ? n : throw new ArgumentNullException();
var segments = new List<ArraySegment<char>>();

for (int i = 0; i < segmentCount; i++)
{
   var input = Console.ReadLine()?.Split()
      .Select(int.Parse)
      .ToArray() 
                 ?? throw new ArgumentNullException();
   
   var from = input[0];
   var to = input[1];
   var segment = new ArraySegment<char>(word, from - 1, to - from + 1);
   
   segments.Add(segment);
}

var answers = segments.Select(s => GetTypeTwoActionCount(s));
Console.WriteLine(String.Join(Environment.NewLine, answers));

int GetTypeTwoActionCount(ArraySegment<char> chars)
{
   var count = 0;
   var pointer = 0;
   var order = chars.OrderBy(x => x).ToArray();

   var runner = 0;
   while (pointer < order.Length)
   {
      if (order[pointer] == chars[runner])
      {
         ++pointer;
         if (pointer >= order.Length)
            break;
      }

      count++;
      runner++;
      
      runner %= chars.Count;
   }

   return count;
}