using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public class Day3
{
    public void Part1()
    {
        var input = File.ReadAllText("Day3/day3_part1.txt");
        var regex = @"mul\(([0-9]{1,3},[0-9]{1,3})\)";
        var matches = Regex.Matches(input, regex);

        var sum = 0;
        foreach (Match item in matches)
        {
            // Console.WriteLine(item.Value[4..^1]);
            var nums = item.Value[4..^1].Split(',');
            var num1 = int.Parse(nums[0]);
            var num2 = int.Parse(nums[1]);
            sum += num1 * num2;
        }

        Console.WriteLine(sum);
    }

    public void Part2()
    {
        var input = File.ReadAllText("Day3/day3_part1.txt");
        var mulRegex = @"mul\(([0-9]{1,3},[0-9]{1,3})\)";
        var matches = Regex.Matches(input, mulRegex);
        var doRegex = @"do\(\)";
        var doMathes = Regex.Matches(input, doRegex);
        var doIndexes = doMathes.Select(x => x.Index);
        var doNotRegex = @"don't\(\)";
        var doNotMathes = Regex.Matches(input, doNotRegex);
        var doNotIndexes = doNotMathes.Select(x => x.Index);

        var sum = 0;
        foreach (Match item in matches)
        {
            // Console.WriteLine(item.Value[4..^1]);
            var lastDo = doIndexes.LastOrDefault(x => x < item.Index);
            var lastDont = doNotIndexes.LastOrDefault(x => x < item.Index);
            if (lastDo >= lastDont)
            {
                var nums = item.Value[4..^1].Split(',');
                var num1 = int.Parse(nums[0]);
                var num2 = int.Parse(nums[1]);
                sum += num1 * num2;
            }
        }

        Console.WriteLine(sum);
    }
}