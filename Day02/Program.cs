string[] day02Input = File.ReadAllLines(@"c:\Temp\aoc22day02.txt");
int score = 0;
int score2 = 0;

foreach (string line in day02Input)
{
    switch(line)
    {
        case "A X":
            score += 4;
            score2 += 3;
            break;
        case "A Y":
            score += 8;
            score2 += 4;
            break;
        case "A Z":
            score += 3;
            score2 += 8;
            break;
        case "B X":
            score += 1;
            score2 += 1;
            break;
        case "B Y":
            score += 5;
            score2 += 5;
            break;
        case "B Z":
            score += 9;
            score2 += 9;
            break;
        case "C X":
            score += 7;
            score2 += 2;
            break;
        case "C Y":
            score += 2;
            score2 += 6;
            break;
        case "C Z":
            score += 6;
            score2 += 7;
            break;
    }
}

Console.WriteLine($"Total score on part 1 is {score}");
Console.WriteLine($"Total score on part 2 is {score2}");