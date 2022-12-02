string[] day01Input = File.ReadAllLines(@"c:\Temp\aoc22day01.txt");
int caloriesGroup = 0;
List<int> caloriesGroups = new List<int>();

//part 1
foreach (string day in day01Input)
{
    int calories;
    bool notBlank = Int32.TryParse(day, out calories);

    if (notBlank == true)
    {
        caloriesGroup += calories;
    }
    else
    {
        caloriesGroups.Add(caloriesGroup);
        caloriesGroup = 0;
    }
}

int indexOfMax = caloriesGroups.IndexOf(caloriesGroups.Max());
Console.WriteLine($"Elf number {indexOfMax} carries most calories, {caloriesGroups[indexOfMax]}");

// part 2
caloriesGroups.Sort();
caloriesGroups.Reverse();
int topElves = caloriesGroups[0] + caloriesGroups[1] + caloriesGroups[2];
Console.WriteLine($"The top 3 elves carry {topElves} calories");