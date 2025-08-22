using System.Diagnostics;

namespace AdventOfCode;

public class Day11
{
    public void Part1()
    {
        var stones = File.ReadAllText("Inputs/day11.txt").Split(" ").Select(long.Parse).ToList();

        var cl = Stopwatch.StartNew();
        var blinks = 75;

        for (int i = 0; i < blinks; i++)
        {
            for (int j = 0; j < stones.Count; j++)
            {
                if (stones[j] == 0)
                {
                    stones[j] = 1;
                    continue;
                }

                var digitCount = (int)Math.Floor(Math.Log10(stones[j])) + 1;
                if (digitCount % 2 == 0)
                {
                    var firstNum = (int)Math.Floor(stones[j] / Math.Pow(10, digitCount / 2));
                    var secondNum = stones[j] % (int)Math.Pow(10, digitCount / 2);
                    stones[j] = firstNum;
                    stones.Insert(j + 1, secondNum);
                    j++;
                    continue;
                }
                // var stingValue = stones[j].ToString();
                // if (stingValue.Length % 2 == 0)
                // {
                //     var firstStone = stingValue[..(stingValue.Length / 2)];
                //     var secondStone = stingValue[(stingValue.Length / 2)..];
                //     stones[j] = long.Parse(firstStone);
                //
                //     stones.Insert(j+1, long.Parse(secondStone));
                //     j++;
                //     continue;
                // }

                stones[j] *= 2024;

            }
        }

        cl.Stop();
        Console.WriteLine(cl.Elapsed);
        Console.WriteLine(stones.Count);
        // Console.WriteLine(string.Join(" ", stones));
    }

    private const int BLINKS = 75;
    public void Part2()
    {
        var stones = File.ReadAllText("Inputs/day11.txt").Split(" ").ToList();

        var cl = Stopwatch.StartNew();
        var result = stones.Sum(x => CountStoneSplits(x, 0));

        cl.Stop();
        Console.WriteLine(cl.Elapsed);
        Console.WriteLine(result);
    }

    private static readonly Dictionary<int, Dictionary<string, long>> Cache = new();

    private static long CountStoneSplits(string stone, int blink)
    {
        if (Cache.TryGetValue(blink, out var stones) && stones.TryGetValue(stone, out var value))
        {
            return value;
        }
        if (blink == BLINKS)
        {
            return 1;
        }
        string[] values;
        if (stone == "0")
        {
            values = ["1"];
        }
        else if (stone.Length % 2 == 0)
        {
            var firstStone = stone[..(stone.Length / 2)];
            var secondStone = stone[(stone.Length / 2)..];

            values = [firstStone, long.Parse(secondStone).ToString()];
        }
        else
        {
            values = [(long.Parse(stone) * 2024).ToString()];
        }

        var sum = values.Sum(x => CountStoneSplits(x, blink + 1));
        if (!Cache.TryAdd(blink, new Dictionary<string, long> { { stone, sum } }))
        {
            Cache[blink].Add(stone, sum);
        }

        return sum;
    }
}