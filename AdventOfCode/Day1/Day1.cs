namespace AdventOfCode.Day1;

public class Day1
{
    public void Part1()
    {
        var lines = File.ReadAllLines("Day1/day1_input.txt");
        var leftList = new List<int>();
        var rightList = new List<int>();
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            leftList.Add(int.Parse(numbers[0]));
            rightList.Add(int.Parse(numbers[1]));
        }
        
        leftList.Sort();
        rightList.Sort();

        var sum = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            var distance = Math.Abs(leftList[i] - rightList[i]);
            sum += distance;
        }
        
        Console.WriteLine($"Sum : {sum}");
    }

    public void Part2()
    {
        var lines = File.ReadAllLines("Day1/day1_input_part2.txt");
        var leftList = new List<int>();
        var rightList = new Dictionary<int, int>();
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            leftList.Add(int.Parse(numbers[0]));
            var right = int.Parse(numbers[1]);
            if (!rightList.TryAdd(right, 1))
            {
                rightList[right]++;
            }
        }

        var sum = 0;
        foreach (var item in leftList)
        {
            sum += item * rightList.GetValueOrDefault(item, 0);
        }
        
        Console.WriteLine($"Sum : {sum}");
    }
}