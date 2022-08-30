using System.Text.RegularExpressions;

var input = Console.ReadLine()?.Split().Select(int.Parse).ToArray()
   ?? throw new ArgumentNullException();

var domainCount = input[0];
var requestCount = input[1];

var domains = Enumerable.Range(0, domainCount)
   .Select(x => Console.ReadLine() ?? String.Empty).ToArray();
var requests = Enumerable.Range(0, requestCount)
   .Select(x => $"^{GetRequest()}$").ToArray();

foreach (var request in requests)
{
   var matchCount = domains.Count(s => Regex.IsMatch(s, request));
   Console.WriteLine(matchCount);
}

string GetRequest()
{
   return Console.ReadLine()?.Replace(" ", ".+") ?? string.Empty;
}