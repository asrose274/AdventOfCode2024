using System.Text.RegularExpressions;

StreamReader file = new StreamReader("/home/aaron/repos/AdventOfCode2024/Day 3/input_3.txt");
var instructions = file.ReadToEnd();

string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
string doPattern =@"(do\(\))";
string dontPattern = @"don't\(\)";

Regex regex = new Regex(pattern);
Regex doRegex = new Regex(doPattern);
Regex dontRegex = new Regex(dontPattern);
var matches = regex.Matches(instructions);
var dos = doRegex.Matches(instructions);
var donts = dontRegex.Matches(instructions);

var doIndexes = dos.Select(d => d.Index).ToList();
var dontIndexes = donts.Select(d => d.Index).ToList();

var allIndexes = doIndexes.Concat(dontIndexes).OrderBy(i => i).ToArray();
var isEnabled = true;
int total = 0;
int nextIndex = 0;

foreach(Match match in matches)
{
    int matchIndex = match.Index;
    if(nextIndex < allIndexes.Length && matchIndex > allIndexes[nextIndex])
    {
        var isDo = doIndexes.Contains(allIndexes[nextIndex]);
        isEnabled = isDo;
        nextIndex++;
    }
    if(isEnabled)
    {
        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);

        total += x*y;
    }
    
}


Console.Write(total);