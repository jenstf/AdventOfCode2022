string[] day06Input = File.ReadAllLines(@"c:\temp\aoc22day06.txt");
string text = day06Input[0];

char[] c = text.ToArray();
int answer1 = 0;
for (int i = 0; i < c.Count() - 3; i++)
{
    char[] tempc = new char[4] { c[i], c[i + 1], c[i + 2], c[i + 3] };
    if (tempc.Distinct().Count() == 4)
    {
        answer1 = i + 3;
        break;
    }
}

int answer2 = 0;
for (int i = answer1; i < c.Count() - 13; i++)
{
    char[] temp = new char[14];
    for (int j = 0; j < 14; j++)
    {
        temp[j] = c[i + j];
    }
    if (temp.Distinct().Count() == 14)
    {
        answer2 = i + 13;
        break;
    }
}

Console.WriteLine("First start-of-packet marker detected at: " + (answer1 + 1));
Console.WriteLine("First start-of-message marker detected at: " + (answer2 + 1));

