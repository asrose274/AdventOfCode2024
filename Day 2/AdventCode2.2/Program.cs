StreamReader file = new StreamReader("/home/aaron/repos/AdventOfCode2024/Day 2/input_2.txt");
var count = File.ReadLines("/home/aaron/repos/AdventOfCode2024/Day 2/input_2.txt").Count();

var safe_reports = 0;

for(int i = 0; i < count; i++)

{
    var line = file.ReadLine()?.Split(' ')?.Select(Int32.Parse)?.ToList();
    if(IsSafe(line))
    {
        safe_reports++;
    }
    else
    {
        for(int j = 0; j < line.Count; j++)
        {
            var copy = line.ToList();
            copy.RemoveAt(j);
            if(IsSafe(copy))
            {
                safe_reports++;
                break;
            }
        }
    }
};

static bool IsSafe(List<int> line)
{
    var firstDiff = line[1] - line[0];

    if(firstDiff == 0 || Math.Abs(firstDiff) >3)
    {
        return false;
    }

    var currentTrajectory = firstDiff/Math.Abs(firstDiff);

    for(int i = 1; i < line.Count - 1; i++)
    {
        var diff = line[i + 1] - line[i];
        if(diff == 0 || Math.Abs(diff) > 3)
        {
            return false;
        }

        var trajectory = diff/Math.Abs(diff);

        if(trajectory != currentTrajectory)
        {
            return false;
        }
    }
    return true;
}

Console.WriteLine(safe_reports);


