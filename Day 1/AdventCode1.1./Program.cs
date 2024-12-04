
StreamReader file = new StreamReader("/home/aaron/repos/AdventOfCode2024/Day 1/input_1.txt");
var linecount = File.ReadLines("/home/aaron/repos/AdventOfCode2024/Day 1/input_1.txt").Count();
List<int> numbers1 = new List<int>();
List<int> numbers2 = new List<int>();

while(file.ReadLine() is string line)
{
 var parts = line.Split("   ");
 
 if (int.TryParse(parts[0], out var number)){
    numbers1.Add(number);
 }
 if(int.TryParse(parts[1], out number)){
    numbers2.Add(number);
 }
}

numbers1.Sort();
numbers2.Sort();

var difference = 0;

for(int i = 0; i < numbers1.Count(); i++){
    difference += Math.Abs(numbers1[i] - numbers2[i]);
}

Console.WriteLine(difference);

