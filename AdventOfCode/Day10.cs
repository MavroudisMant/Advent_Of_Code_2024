namespace AdventOfCode;

public class Day10
{
    public void BothParts()
    {
        var input = File.ReadAllLines("Inputs/day10.txt").Select(x => x.ToArray().Select(s => int.TryParse(s.ToString(), out var num) ? num : -1).ToArray()).ToArray();

        var rows = input.Length;
        var cols = input[0].Length;

        var sum = 0;
        var sumRating = 0;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (input[i][j] == 0)
                {
                    var visitedTops = new HashSet<(int Row, int Col)>();
                    sumRating += CountPaths(input, i, j, visitedTops);
                    sum += visitedTops.Count;
                }
            }
        }

        Console.WriteLine("Unique tops : {0}",sum);
        Console.WriteLine("Rating : {0}", sumRating);
    }

    private static int CountPaths(int[][] trail, int row, int col, HashSet<(int Row, int Col)> visitedTops)
    {
        if (trail[row][col] == 9)
        {
            visitedTops.Add((row, col));
            return 1;
        }

        var countPaths = 0;

        if (row - 1 >= 0)
        {
            if (trail[row - 1][col] == trail[row][col] + 1)
            {
                countPaths += CountPaths(trail, row - 1, col, visitedTops);
            }
        }

        if (row + 1 < trail.Length)
        {
            if (trail[row + 1][col] == trail[row][col] + 1)
            {
                countPaths += CountPaths(trail, row + 1, col, visitedTops);
            }
        }

        if (col - 1 >= 0)
        {
            if (trail[row][col - 1] == trail[row][col] + 1)
            {
                countPaths += CountPaths(trail, row, col - 1, visitedTops);
            }
        }

        if (col + 1 < trail[row].Length)
        {
            if (trail[row][col + 1] == trail[row][col] + 1)
            {
                countPaths += CountPaths(trail, row, col + 1, visitedTops);
            }
        }

        return countPaths;
    }
}