namespace AdventOfCode.Day8;

public class Day8
{
    public void Part1()
    {
        var input = File.ReadAllLines("Day8/day8.txt").Select(x => x.ToArray()).ToArray();

        var rows = input.Length;
        var cols = input[0].Length;

        var antennas = new Dictionary<char, List<Point>>();
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (input[i][j] != '.')
                {
                    if (antennas.ContainsKey(input[i][j]))
                    {
                        antennas[input[i][j]].Add(new Point(i,j));
                    }
                    else
                    {
                        antennas.Add(input[i][j], [new Point(i, j)]);
                    }
                }
            }
        }
        
        var antinodes = new HashSet<(int, int)>();

        foreach (var ant in antennas)
        {
            var points = ant.Value;


            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var rowDiff = points[i].Row - points[j].Row;
                    var colDiff = points[i].Col - points[j].Col;

                    var currentRow = points[i].Row + rowDiff;
                    var currentCol = points[i].Col + colDiff;
                    while (currentRow < rows && currentCol < cols && currentRow >= 0 && currentCol >= 0)
                    {
                        var iDistance = Math.Sqrt(Math.Pow(points[i].Row - currentRow, 2) + Math.Pow(points[i].Col - currentCol, 2));
                        var jDistance = Math.Sqrt(Math.Pow(points[j].Row - currentRow, 2) + Math.Pow(points[j].Col - currentCol, 2));

                        if (iDistance == 2 * jDistance || jDistance == 2 * iDistance)
                        {
                            antinodes.Add((currentRow, currentCol));
                        }

                        currentRow += rowDiff;
                        currentCol += colDiff;
                    }
                    
                    currentRow = points[i].Row - rowDiff;
                    currentCol = points[i].Col - colDiff;
                    while (currentRow < rows && currentCol < cols && currentRow >= 0 && currentCol >= 0)
                    {
                        var iDistance = Math.Sqrt(Math.Pow(points[i].Row - currentRow, 2) + Math.Pow(points[i].Col - currentCol, 2));
                        var jDistance = Math.Sqrt(Math.Pow(points[j].Row - currentRow, 2) + Math.Pow(points[j].Col - currentCol, 2));

                        if (iDistance == 2 * jDistance || jDistance == 2 * iDistance)
                        {
                            antinodes.Add((currentRow, currentCol));
                        }

                        currentRow -= rowDiff;
                        currentCol -= colDiff;
                    }
                }
            }

        }
        
        Console.WriteLine(antinodes.Count);
    }
    
    public void Part2()
    {
        var input = File.ReadAllLines("Day8/day8.txt").Select(x => x.ToArray()).ToArray();

        var rows = input.Length;
        var cols = input[0].Length;

        var antennas = new Dictionary<char, List<Point>>();
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (input[i][j] != '.')
                {
                    if (antennas.ContainsKey(input[i][j]))
                    {
                        antennas[input[i][j]].Add(new Point(i,j));
                    }
                    else
                    {
                        antennas.Add(input[i][j], [new Point(i, j)]);
                    }
                }
            }
        }
        
        var antinodes = new HashSet<(int, int)>();

        foreach (var ant in antennas)
        {
            var points = ant.Value;


            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var rowDiff = points[i].Row - points[j].Row;
                    var colDiff = points[i].Col - points[j].Col;

                    var currentRow = points[i].Row;
                    var currentCol = points[i].Col;
                    while (currentRow < rows && currentCol < cols && currentRow >= 0 && currentCol >= 0)
                    {
                        
                        antinodes.Add((currentRow, currentCol));

                        currentRow += rowDiff;
                        currentCol += colDiff;
                    }
                    
                    currentRow = points[i].Row - rowDiff;
                    currentCol = points[i].Col - colDiff;
                    while (currentRow < rows && currentCol < cols && currentRow >= 0 && currentCol >= 0)
                    {
                        antinodes.Add((currentRow, currentCol));

                        currentRow -= rowDiff;
                        currentCol -= colDiff;
                    }
                }
            }

        }
        
        Console.WriteLine(antinodes.Count);
    }
    
    private readonly struct Point(int row, int col)
    {
        public int Row { get; } = row;
        public int Col { get; } = col;
    }
}