namespace AdventOfCode.Day2;

public class Day2
{
    public void Part1()
    {
        var lines  = File.ReadLines("Day2/day2_part1.txt");
        var safeCount = 0;
        foreach (var report in lines)
        {
            var levels = report.Split(' ').Select(int.Parse).ToArray();
            var isSafe = IsSafe(levels);

            if (isSafe)
            {
                safeCount++;
            }
        }
        
        Console.WriteLine(safeCount);
    }

    public void Part2()
    {
        var lines  = File.ReadLines("Day2/day2_part1.txt");
        var safeCount = 0;
        foreach (var report in lines)
        {
            var levels = report.Split(' ').Select(int.Parse).ToList();
            var isSafe = IsSafeWithDampener(levels);

            if (isSafe)
            {
                safeCount++;
            }
        }
        
        Console.WriteLine(safeCount);
    }

    private static bool IsSafe(int[] levels)
    {
        var prevDiff = 0;
        var isSafe = true;
        for (int i = 0; i < levels.Length - 1; i++)
        {
            var diff = levels[i] - levels[i + 1];
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3 || diff * prevDiff < 0)
            {
                isSafe = false;
                break;
            }
            prevDiff = diff;
        }

        return isSafe;
    }
    
    private static bool IsSafeWithDampener(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var cur = levels.ToList();
            cur.RemoveAt(i);
            if (IsSafe(cur.ToArray()))
            {
                return true;
            }
        }
        return true;
    }
}