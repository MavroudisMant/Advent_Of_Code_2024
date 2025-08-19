namespace AdventOfCode.Day6;

public class Day6
{
    public (HashSet<(int row, int col)> visited, int startingRow, int startingColumn, char[][] map) Part1()
    {
        var input = File.ReadAllLines("Day6/day6.txt").Select(x => x.ToArray()).ToArray();

        var rows = input.Length;
        var cols = input[0].Length;
        var visited = new HashSet<(int row, int col)>();

        var startingRow = 0;
        var startingCol = 0;
        var posFound = false;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (input[i][j] is '^')
                {
                    startingRow = i;
                    startingCol = j;
                    posFound = true;
                    break;
                }
            }

            if (posFound)
            {
                break;
            }
        }

        var rowDirection = -1;
        var colDirection = 0;
        
        var currentRow = startingRow;
        var currentCol = startingCol;

        while (currentRow >= 0 && currentCol >= 0 && currentRow < rows && currentCol < cols)
        {
            if (input[currentRow][currentCol] is '#')
            {
                switch (rowDiraction: rowDirection, colDiraction: colDirection)
                {
                    case (-1, 0): //Up
                        currentRow -= rowDirection;
                        rowDirection = 0;
                        colDirection = 1;
                        break;
                    case (1, 0): //Down
                        currentRow -= rowDirection;
                        rowDirection = 0;
                        colDirection = -1;
                        break;
                    case (0, 1): //Right
                        currentCol -= colDirection;
                        rowDirection = 1;
                        colDirection = 0;
                        break;
                    case (0, -1): //Left
                        currentCol -= colDirection;
                        rowDirection = -1;
                        colDirection = 0;
                        break;
                }
            }
            
            visited.Add((currentRow, currentCol));
            currentRow += rowDirection;
            currentCol += colDirection;
        }
        
        Console.WriteLine(visited.Count);

        return (visited, startingRow, startingCol, input);
    }

    public void Part2()
    {
        var (path, startingRow, startingCol, map) = Part1();
        var sum = 0;
        foreach (var step in path)
        {
            sum += CausesLoop(startingRow, startingCol, step.row, step.col, map) ? 1 : 0;
        }
        Console.WriteLine(sum);
    }

    private bool CausesLoop(int startingRow, int startingCol, int obstacleRow, int obstacleCol, char[][] map)
    {
        var causesLoop = false;
        var visited = new HashSet<(int row, int col, int rowDirection, int colDirection)>();

        var rows = map.Length;
        var cols = map[0].Length;
        
        map[obstacleRow][obstacleCol] = '#';
        
        var rowDirection = -1;
        var colDirection = 0;
        
        var currentRow = startingRow;
        var currentCol = startingCol;

        while (currentRow >= 0 && currentCol >= 0 && currentRow < rows && currentCol < cols)
        {
            if (!visited.Add((currentRow, currentCol, rowDirection, colDirection)))
            {
                causesLoop = true;
                break;
            }

            if (map[currentRow][currentCol] is '#')
            {
                switch (rowDiraction: rowDirection, colDiraction: colDirection)
                {
                    case (-1, 0): //Up
                        currentRow -= rowDirection;
                        rowDirection = 0;
                        colDirection = 1;
                        break;
                    case (1, 0): //Down
                        currentRow -= rowDirection;
                        rowDirection = 0;
                        colDirection = -1;
                        break;
                    case (0, 1): //Right
                        currentCol -= colDirection;
                        rowDirection = 1;
                        colDirection = 0;
                        break;
                    case (0, -1): //Left
                        currentCol -= colDirection;
                        rowDirection = -1;
                        colDirection = 0;
                        break;
                }
            }
            
            currentRow += rowDirection;
            currentCol += colDirection;
        }
        
        map[obstacleRow][obstacleCol] = '.';

        return causesLoop;
    }
}