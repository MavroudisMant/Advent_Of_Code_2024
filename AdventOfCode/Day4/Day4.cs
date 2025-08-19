namespace AdventOfCode.Day4;

public class Day4
{
    public void Part1()
    {
        var input = File.ReadAllLines("Day4/day4.txt").Select(x => x.ToArray()).ToArray();

        var rows = input.Length;
        var cols = input[0].Length;
        
        var sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (input[i][j] is 'X')
                {
                    //Forward
                    if (j + 3 < cols && input[i][j+1] is 'M' && input[i][j+2] is 'A' && input[i][j+3] is 'S')
                    {
                        sum++;
                    }
                    
                    //Backward
                    if (j - 3 >= 0 && input[i][j-1] is 'M' && input[i][j-2] is 'A' && input[i][j-3] is 'S')
                    {
                        sum++;
                    }
                    
                    //Up
                    if (i - 3 >= 0 && input[i-1][j] is 'M' && input[i-2][j] is 'A' && input[i-3][j] is 'S')
                    {
                        sum++;
                    }
                    
                    //Down
                    if (i + 3 < rows && input[i+1][j] is 'M' && input[i+2][j] is 'A' && input[i+3][j] is 'S')
                    {
                        sum++;
                    }
                    
                    //Forward - Down
                    if (i + 3 < rows && j + 3 < cols && input[i+1][j+1] is 'M' && input[i+2][j+2] is 'A' && input[i+3][j+3] is 'S')
                    {
                        sum++;
                    }
                    
                    
                    //Forward - Up
                    if (i - 3 >= 0 && j + 3 < cols && input[i-1][j+1] is 'M' && input[i-2][j+2] is 'A' && input[i-3][j+3] is 'S')
                    {
                        sum++;
                    }
                    
                    //Backward - Up
                    if (i - 3 >= 0 && j - 3 >= 0 && input[i-1][j-1] is 'M' && input[i-2][j-2] is 'A' && input[i-3][j-3] is 'S')
                    {
                        sum++;
                    }
                    
                    
                    //Backward - Down
                    if (i + 3 < rows && j - 3 >= 0 && input[i+1][j-1] is 'M' && input[i+2][j-2] is 'A' && input[i+3][j-3] is 'S')
                    {
                        sum++;
                    }
                }
            }
        }
        
        Console.WriteLine(sum);
    }
    
    public void Part2()
    {
        var input = File.ReadAllLines("Day4/day4.txt").Select(x => x.ToArray()).ToArray();

        var rows = input.Length;
        var cols = input[0].Length;
        
        var sum = 0;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (input[i][j] is 'M')
                {
                    
                    if (i + 2 < rows && j + 2 < cols && input[i+1][j+1] is 'A' && input[i+2][j+2] is 'S')
                    {
                        if ((input[i][j + 2] is 'M' && input[i + 2][j] is 'S') || (input[i][j + 2] is 'S' && input[i + 2][j] is 'M'))
                        {
                            sum++;
                        }
                    }
                }
                
                if (input[i][j] is 'S')
                {
                    
                    if (i + 2 < rows && j + 2 < cols && input[i+1][j+1] is 'A' && input[i+2][j+2] is 'M')
                    {
                        if ((input[i][j + 2] is 'M' && input[i + 2][j] is 'S') || (input[i][j + 2] is 'S' && input[i + 2][j] is 'M'))
                        {
                            sum++;
                        }
                    }
                }
            }
        }
        
        Console.WriteLine(sum);
    }
}