string input = await File.ReadAllTextAsync(@"c:\temp\aoc22day11.txt");

for (int part = 1; part <= 2; part++)
{
    Monkey[] monkeys = input.Split("\r\n\r\n").Select(m => new Monkey(m)).ToArray();
    int diversionTest = monkeys.Aggregate(1, (current, monkey) => current * monkey.Test);
    int rounds = part == 1 ? 20 : 10_000;
    for (int i = 0; i < rounds; i++)
    {
        foreach (Monkey monkey in monkeys)
        {
            while (monkey.Items.Count > 0)
            {
                long item = monkey.Items.Dequeue();
                long worry = part == 1 ? monkey.EvaluateOperation(item) / 3 : monkey.EvaluateOperation(item) % diversionTest;
                int receiverIndex = worry % monkey.Test == 0 ? monkey.TestPassing : monkey.TestNotPassing;
                monkeys[receiverIndex].Items.Enqueue(worry);
                monkey.ProcessedItems++;
            }
        }
    }
    Monkey[] topMonkeys = monkeys.OrderByDescending(m => m.ProcessedItems).Take(2).ToArray();
    Console.WriteLine($"Part {part}: {topMonkeys[0].ProcessedItems * topMonkeys[1].ProcessedItems}");
}

class Monkey
{
    public Monkey(string input)
    {
        string[] lines = input.Split("\r\n");
        lines[1].Replace("  Starting items: ", string.Empty).Replace(" ", string.Empty).Split(',').Select(long.Parse).ToList().ForEach(Items.Enqueue);
        Operation = lines[2].Replace("  Operation: new = old ", string.Empty);
        Test = int.Parse(lines[3].Replace("  Test: divisible by ", string.Empty));
        TestPassing = int.Parse(lines[4].Replace("    If true: throw to monkey ", string.Empty));
        TestNotPassing = int.Parse(lines[5].Replace("    If false: throw to monkey ", string.Empty));
    }
    public Queue<long> Items { get; set; } = new();
    public string Operation { get; set; }
    public int Test { get; set; }
    public int TestPassing { get; set; }
    public int TestNotPassing { get; set; }
    public long ProcessedItems { get; set; }
    public long EvaluateOperation(long item)
    {
        string[] op = Operation.Split(' ');
        if (!long.TryParse(op[1], out var val)) { val = item; }
        return op[0] == "*" ? val * item : val + item;
    }
}