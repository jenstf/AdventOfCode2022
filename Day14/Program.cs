string[] input = await File.ReadAllLinesAsync(@"c:\temp\aoc22day14.txt");

Console.WriteLine($"Part 1: {Run(input, 1)}");
Console.WriteLine($"Part 2: {Run(input, 2)}");

static int Run(IEnumerable<string> input, int part)
{
    var map = new HashSet<(int X, int Y)>();

    foreach (string line in input)
    {
        string[] pathPoints = line.Split(" -> ");

        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            var (from, to) = (
                pathPoints[i].Split(',').Select(int.Parse).ToArray(),
                pathPoints[i + 1].Split(',').Select(int.Parse).ToArray()
            );

            var direction = from[0] == to[0] ? (X: 0, Y: Math.Sign(to[1] - from[1])) : (X: Math.Sign(to[0] - from[0]), Y: 0);

            while (from[0] != to[0] || from[1] != to[1])
            {
                map.Add((from[0], from[1]));
                from[0] += direction.X;
                from[1] += direction.Y;
            }
            map.Add((from[0], from[1]));
        }
    }

    var sand = 0;

    var maxY = map.Max(s => s.Y);
    var minX = map.Min(s => s.X);
    var maxX = map.Max(s => s.X);

    if (part == 2)
    {
        maxY += 2;
        for (var x = minX - maxY; x < maxX + maxY; x++) //make sure there's enough floor to catch the falling sand
        {
            map.Add((x, maxY));
        }
    }

    while (true)
    {
        var (sandX, sandY) = (500, 0);

        if (map.Contains((sandX, sandY))) { return sand; }

        while (true)
        {
            if (sandY == maxY) { return sand; }

            if (!map.Contains((sandX, sandY + 1)))
            {
                sandY++;
                continue;
            }

            if (!map.Contains((sandX - 1, sandY + 1)))
            {
                sandX--;
                sandY++;
                continue;
            }

            if (!map.Contains((sandX + 1, sandY + 1)))
            {
                sandX++;
                sandY++;
                continue;
            }

            break;
        }

        map.Add((sandX, sandY));
        sand++;
    }
}