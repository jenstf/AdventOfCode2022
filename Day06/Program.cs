string[] day06Input = File.ReadAllLines(@"c:\temp\aoc22day06.txt");
string text = day06Input[0];

char[] c = text.ToArray();
int answer = 0;
for (int i = 0; i < c.Count() - 3; i++)
{
    char[] tempc = new char[4] { c[i], c[i + 1], c[i + 2], c[i + 3] };
    if (tempc.Distinct().Count() == 4)
    {
        answer = i + 3;
        break;
    }
}

int answer2 = 0;
for (int i = answer; i < c.Count() - 13; i++)
{
    char[] tempc = new char[14];
    for (int j = 0; j < 14; j++)
    {
        tempc[j] = c[i + j];
    }
    if (tempc.Distinct().Count() == 14)
    {
        answer2 = i + 13;
        break;
    }
}

Console.WriteLine((c[answer - 3]) + "," + (c[answer - 2]) + "," + (c[answer - 1]) + "," + (c[answer])); //Write Part 1 Characters
Console.WriteLine(answer + 1); //Part 1 Answer

for (int i = 14; i > 0; i--)
{
    Console.Write(c[answer2 + 1 - i]);
    if (i != 1) { Console.Write(", "); }

    Console.WriteLine();
    Console.WriteLine(answer2 + 1);
}

