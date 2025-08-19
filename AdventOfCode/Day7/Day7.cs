using System.Text;

namespace AdventOfCode.Day7;

public class Day7
{
    public void Part1()
    {
        var input = File.ReadAllLines("Day7/day7.txt");

        var sum = 0L;
        
        foreach (var eq in input)
        {
            var parts = eq.Split(":");
            var result = long.Parse(parts[0]);
            var nums = parts[1].TrimStart().TrimEnd().Split(' ').Select(long.Parse).ToArray();
            // 0 == +
            // 1 == *
            var operatorsCount = nums.Length - 1;
            var possibleCombinations = Math.Pow(2, operatorsCount);

            for (int i = 0; i < possibleCombinations; i++)
            {
                var bitString = Convert.ToString(i, 2).PadLeft(operatorsCount, '0');

                var num = nums[0];
                for (int j = 0; j < bitString.Length; j++)
                {
                    if (bitString[j] == '0')
                    {
                        num += nums[j + 1];
                    }
                    else
                    {
                        num *= nums[j + 1];
                    }
                }

                if (num == result)
                {
                    sum += num;
                    break;
                }
            }
        }
        
        Console.WriteLine(sum);
    }
    
    public void Part2()
    {
        var input = File.ReadAllLines("Day7/day7.txt");

        var sum = 0L;
        
        foreach (var eq in input)
        {
            var parts = eq.Split(":");
            var result = long.Parse(parts[0]);
            var nums = parts[1].TrimStart().TrimEnd().Split(' ').Select(long.Parse).ToArray();
            // 0 == +
            // 1 == *
            // 2 == ||
            var operatorsCount = nums.Length - 1;
            var possibleCombinations = Math.Pow(3, operatorsCount);

            for (int i = 0; i < possibleCombinations; i++)
            {
                var bitString = ConvertToBase3(i).PadLeft(operatorsCount, '0');

                var num = nums[0];
                for (int j = 0; j < bitString.Length; j++)
                {
                    if (bitString[j] == '0')
                    {
                        num += nums[j + 1];
                    }
                    else if (bitString[j] == '1')
                    {
                        num *= nums[j + 1];
                    }
                    else
                    {
                        num = long.Parse($"{num}{nums[j + 1]}");
                    }
                }

                if (num == result)
                {
                    sum += num;
                    break;
                }
            }
        }
        
        Console.WriteLine(sum);
    }
    
    static string ConvertToBase3(int number)
    {
        if (number == 0) return "0";

        StringBuilder result = new StringBuilder();
        int current = number;

        while (current > 0)
        {
            int remainder = current % 3;
            result.Insert(0, remainder);
            current /= 3;
        }
        return result.ToString();
    }
}