string[] day03Input = File.ReadAllLines(@"c:\temp\aoc22day03.txt");
string alfabet = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
int lettervalue;
int sum = 0;
int sum2 =0;

foreach (string item in day03Input)
{
    string first = item.Substring(0, (int)(item.Length / 2));
    string second = item.Substring((int)(item.Length / 2), (int)(item.Length / 2));

    foreach (char letter in first)
    {
        if (second.Contains(letter))
        {
            lettervalue = alfabet.IndexOf(letter);
            sum += lettervalue;
            break;
        }
    }

}

for (int i = 0; i<day03Input.Count(); i=i+3)
{
    foreach (char letter in day03Input[i])
    {
        if (day03Input[i+1].Contains(letter) && day03Input[i+2].Contains(letter))
        {
            lettervalue = alfabet.IndexOf(letter);
            sum2 += lettervalue;
            break;
        }
    }

}

Console.WriteLine($"The sum of priorities for part 1 are {sum}");
Console.WriteLine($"The sum of priorities for part 2 are {sum2}");