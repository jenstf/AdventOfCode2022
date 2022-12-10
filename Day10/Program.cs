string[] day10Input = File.ReadAllLines(@"c:\Temp\aoc22day10.txt");

const int rowLength = 40;
int x = 1;
int signalStrength = 0;
int signalCheckIndex = 20;
int cycle = 0;
int pixelPosition = 0;
(int a, int b) sprite = (1, 3);

foreach (var line in day10Input)
{
    IncrementCycle();
    
    string[] cmd = line.Split(' ');
    switch (cmd[0])
    {
        case "noop": continue;
        case "addx":
        {
            IncrementCycle();
            x += int.Parse(cmd[1]);
            sprite = (x, x + 2);
            break;
        }
    }

    void IncrementCycle()
    {
        cycle++;
        pixelPosition++;

        if (cycle == signalCheckIndex)
        {
            signalStrength += x * cycle;
            signalCheckIndex += 40;
        }

        Console.Write(pixelPosition >= sprite.a && pixelPosition <= sprite.b ? "#" : ".");

        if (pixelPosition == rowLength)
        {
            Console.WriteLine();
            pixelPosition = 0;
        }
    }
}

Console.WriteLine();
Console.WriteLine($"Part 1: {signalStrength}");