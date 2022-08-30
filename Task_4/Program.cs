using System.Text.RegularExpressions;

var blocks = new LinkedList<Dictionary<string, string>>();
blocks.AddFirst(new Dictionary<string, string>());

string input;
var answers = new List<string>();

var varVar = new Regex("^([a-z]+)=([a-z]+)$");
var varNum = new Regex("^([a-z]+)=([+-]?[0-9]+)$");
var block = new Regex("^{$");
var endBlock = new Regex("^}$");

var actions = new Dictionary<Regex, Action<Match>>();
actions.Add(varVar, AssignVar);
actions.Add(varNum, AssignNum);
actions.Add(block, (_) => blocks.AddFirst(new Dictionary<string, string>()));
actions.Add(endBlock, (_) => blocks.RemoveFirst());

while (string.IsNullOrEmpty(input = Console.ReadLine()) == false)
{
   foreach (var regex in actions.Keys)
   {
      var match = regex.Match(input);
      if (match.Success) 
         actions[regex].Invoke(match);
   }
}

Console.WriteLine(String.Join(Environment.NewLine, answers));

string GetVariable(string name)
{
   var b = blocks.FirstOrDefault(x => x.ContainsKey(name));
   if (b == null)
      return "0";
   return b[name];
}

void AssignVar(Match match)
{
   var value = GetVariable(match.Groups[2].Value);
   Add(match.Groups[1].Value, value);
}

void Add(string left, string right)
{
   var dictionary = blocks.First.Value;
   if (dictionary.TryAdd(left, right) == false) 
      dictionary[left] = right;
   answers.Add(right);
}

void AssignNum(Match match)
{
   var value = match.Groups[2].Value;
   Add(match.Groups[1].Value, value);
}