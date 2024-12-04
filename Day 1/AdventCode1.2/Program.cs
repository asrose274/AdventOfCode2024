StreamReader file = new StreamReader("/home/aaron/repos/AdventOfCode2024/Day 1/input_1.txt");
List<int> numbers1 = new List<int>();
List<int> numbers2 = new List<int>();

var counts = new Dictionary<int, int>();



while(file.ReadLine() is string line)
{
 var parts = line.Split("   ");
 
 if (int.TryParse(parts[0], out var number))
 {
    numbers1.Add(number);
}

 if(int.TryParse(parts[1], out number)){
    numbers2.Add(number);
    if(counts.ContainsKey(number))
    {
        counts[number]++;
    } 
    else
    {
        counts[number] = 1;
    }
 }
}


var total = 0;
for(int i = 0; i < numbers1.Count(); i++){
    if(counts.ContainsKey(numbers1[i]))
    {
        total += numbers1[i] * counts[numbers1[i]];
    }
    
}

Console.WriteLine(total);

