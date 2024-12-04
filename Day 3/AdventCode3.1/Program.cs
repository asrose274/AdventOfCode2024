using System.Text.RegularExpressions;

StreamReader file = new StreamReader("/home/aaron/repos/AdventOfCode2024/Day 3/input_3.txt");
var instructions = file.ReadToEnd();

string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

Regex regex = new Regex(pattern);
MatchCollection matches = regex.Matches(instructions);

int total = 0;

foreach(Match match in matches)
{
    int x = int.Parse(match.Groups[1].Value);
    int y = int.Parse(match.Groups[2].Value);

    total += x*y;
}

Console.Write(total);