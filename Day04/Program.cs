string[] day03Input = File.ReadAllLines(@"c:\temp\aoc22day04.txt");
int firstFrom;
int firstTo;
int secondFrom;
int secondTo;
int sum = 0;
int sum2 = 0;

foreach (string line in day03Input)
{
    firstFrom = Int32.Parse(line.Substring(0, line.IndexOf("-")));
    firstTo = Int32.Parse(line.Substring(line.IndexOf("-") + 1,line.IndexOf(",") - line.IndexOf("-") - 1));
    secondFrom = Int32.Parse(line.Substring(line.IndexOf(",") + 1,line.LastIndexOf("-") - line.IndexOf(",") - 1));
    secondTo = Int32.Parse(line.Split("-").Last());
    if(secondFrom >= firstFrom && secondTo <= firstTo)
    {
        sum++;
    }
    else if(firstFrom >= secondFrom && firstTo <= secondTo)
    {
        sum++;  
    }
    if (firstFrom <= secondTo && secondFrom <= firstTo)
    {
        sum2++;
    }
}
Console.WriteLine($"{sum} assignment pairs fully contain the other");
Console.WriteLine($"{sum2} assignment pairs overlap");