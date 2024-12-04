StreamReader file = new StreamReader("/home/aaron/repos/AdventOfCode2024/Day 2/input_2.txt");
var count = File.ReadLines("/home/aaron/repos/AdventOfCode2024/Day 2/input_2.txt").Count();

var safe_reports = count;

for(int i = 0; i < count; i++)
{
    var line = file.ReadLine()?.Split(' ')?.Select(Int32.Parse)?.ToList();
    var safe = true;
    string current_trajectory = "";
    while(safe)
    {
        
        foreach(int num in line)
        {
            var diff = 0;
            
            if(line.IndexOf(num) + 1 < line.Count())
            {
                diff = line[line.IndexOf(num)+1] - num;
                if(line.IndexOf(num) == 0 )
                {
                    if(diff < 0)
                    {
                        current_trajectory = "dec";
                    }
                    else if(diff > 0)
                    {
                        current_trajectory = "inc";
                    }
                    else
                    {
                        safe = false;
                        safe_reports -= 1;
                        break;
                    }
                }
                else
                {
                   if((diff > 0 && current_trajectory == "dec") || (diff < 0 && current_trajectory == "inc"))
                   {
                    safe = false;
                    safe_reports -= 1;
                    break;
                   }
                }
                
            }
            else
            {
                break;
            }
            if(diff > 3 || diff < -3 || diff == 0)
            {
                safe = false;
                safe_reports -= 1;
                break;
            }
            else
            {
                safe = true;
            }
        }
        break;
    }
    
}

Console.WriteLine(safe_reports);


