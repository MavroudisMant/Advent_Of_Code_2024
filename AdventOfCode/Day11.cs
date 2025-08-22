using System.Diagnostics;

namespace AdventOfCode;
//Time to beat : 00:00:01.6496920
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
        var stones = File.ReadAllText("Inputs/day11.txt").Split(" ").Select(long.Parse).ToList();

        var cl = Stopwatch.StartNew();
        var result = AAA(stones, 0);

        cl.Stop();
        Console.WriteLine(cl.Elapsed);
        Console.WriteLine(result);
    }

    private long AAA(List<long> stones, int blink)
    {
        if (stones.Count == 1)
        {
            blink++;
            if (stones[0] == 0)
            {
                return blink == BLINKS ? 1 : AAA([1], blink);
            }

            var digitCount = (int)Math.Floor(Math.Log10(stones[0])) + 1;
            if (digitCount % 2 == 0)
            {
                var firstNum = (int)Math.Floor(stones[0] / Math.Pow(10, digitCount / 2));
                var secondNum = stones[0] % (int)Math.Pow(10, digitCount / 2);

                return blink == BLINKS ? 2 : AAA([firstNum, secondNum], blink);
            }

            return blink == BLINKS ? 1 : AAA([stones[0] * 2024], blink);
        }

        return AAA(stones[..(stones.Count / 2)], blink) + AAA(stones[(stones.Count / 2)..], blink);
    }
}