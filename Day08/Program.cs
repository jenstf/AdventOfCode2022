string[] input = File.ReadAllLines(@"c:\Temp\aoc22day08.txt");

Dictionary<(int x, int y), int> trees = new Dictionary<(int x, int y), int>();
int totalWidth = input[0].Length;
int totalHeight = input.Length;

for (int i = 0; i < input.Length; i++)
{
    string line = input[i];
    for (int j = 0; j < line.Length; j++)
    {
        int t = int.Parse(new ReadOnlySpan<char>(line[j]));
        trees[(i, j)] = t;
    }
}

int visibleTrees = 0;

foreach (KeyValuePair<(int x, int y), int> tree in trees)
{
    if (tree.Key.x == 0 || tree.Key.y == 0)
    {
        visibleTrees++;
    }
    else
    {
        //Fra toppen
        if (trees.Where(t => t.Key.x == tree.Key.x && t.Key.y < tree.Key.y).All(t => t.Value < tree.Value))
        {
            visibleTrees++;
            continue;
        }

        //Fra bunn
        if (trees.Where(t => t.Key.x == tree.Key.x && t.Key.y > tree.Key.y).All(t => t.Value < tree.Value))
        {
            visibleTrees++;
            continue;
        }

        //Fra venstre
        if (trees.Where(t => t.Key.y == tree.Key.y && t.Key.x < tree.Key.x).All(t => t.Value < tree.Value))
        {
            visibleTrees++;
            continue;
        }

        //Fra høyre
        if (trees.Where(t => t.Key.y == tree.Key.y && t.Key.x > tree.Key.x).All(t => t.Value < tree.Value))
        {
            visibleTrees++;
        }
    }
}

Console.WriteLine($"Part 1: {visibleTrees}");

int highestTreeScore = 0;

foreach (KeyValuePair<(int x, int y), int> tree in trees)
{
    int left = 0, right = 0, top = 0, bottom = 0;

    int x = tree.Key.x - 1;
    int y = tree.Key.y;

    while (x >= 0) //se til venstre
    {
        int t = trees[(x, y)];
        left += 1;

        if (t >= tree.Value) break;
        x--;
    }

    x = tree.Key.x + 1;

    while (x < totalWidth) //se til høyre
    {
        int t = trees[(x, y)];
        right += 1;

        if (t >= tree.Value) break;
        x++;
    }

    x = tree.Key.x;
    y = tree.Key.y - 1;

    while (y >= 0) //se opp
    {
        int t = trees[(x, y)];
        top += 1;

        if (t >= tree.Value) break;
        y--;
    }

    y = tree.Key.y + 1;

    while (y < totalHeight) //se ned
    {
        int t = trees[(x, y)];
        bottom += 1;

        if (t >= tree.Value) break;
        y++;
    }

    highestTreeScore = Math.Max(highestTreeScore, left * right * top * bottom);
}

Console.WriteLine($"Part 2: {highestTreeScore}");