string[] day09Input = File.ReadAllLines(@"c:\Temp\aoc22day09.txt");
List <string> input = new List<string>();
foreach (string line in day09Input) input.Add(line);

const int KNOTS = 10;
(int X, int Y)[] tails = new (int X, int Y)[KNOTS];
var visited = new Dictionary<(int X, int Y), bool>();
var visited10 = new Dictionary<(int X, int Y), bool>();

for (int i = 0; i < input.Count; i++)
{
    var cmd = input[i].Split(' ');
    int move = int.Parse(cmd[1]);
    for (int j = 0; j < move; j++)
    {
        switch (cmd[0])
        {
            case "U":
                tails[0].Y -= 1;
                break;
            case "R":
                tails[0].X += 1;
                break;
            case "D":
                tails[0].Y += 1;
                break;
            case "L":
                tails[0].X -= 1;
                break;
        }
        for (int k = 1; k < KNOTS; k++)
        {
            if (Math.Abs(tails[k - 1].X - tails[k].X) > 1 || Math.Abs(tails[k - 1].Y - tails[k].Y) > 1)
            {
                tails[k].X += Math.Min(Math.Max(-1, tails[k - 1].X - tails[k].X), 1);
                tails[k].Y += Math.Min(Math.Max(-1, tails[k - 1].Y - tails[k].Y), 1);
            }
        }
        visited[tails[1]] = true;
        visited10[tails[KNOTS - 1]] = true;
    }
}

Console.WriteLine(visited.Count);
Console.WriteLine(visited10.Count);