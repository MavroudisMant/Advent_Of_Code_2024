namespace AdventOfCode.Day5;

public class Day5
{
    public void Part1()
    {
        var file = File.ReadAllLines("Day5/day5_rules.txt");
        var dict = new Dictionary<int, List<int>>();
        foreach (var line in file)
        {
            var l = line.Split('|');
            var key = Int32.Parse(l[0]);
            var value = Int32.Parse(l[1]);
            if (dict.ContainsKey(key))
            {
                dict[key].Add(value);
            }
            else
            {
                dict.Add(key, [value]);
            }
        }

        var lines = File.ReadAllLines("Day5/day5_input.txt");
        
        var sortedSum = 0;
        
        foreach (var line in lines)
        {
            var input = line.Split(',').Select(int.Parse).ToArray();
            var isInOrder = true;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                var current = input[i];
                for (int j = 0; j < i; j++)
                {
                    if (dict.ContainsKey(current) && dict[current].Contains(input[j]))
                    {
                        isInOrder = false;
                        break;
                    }
                }

                if (!isInOrder)
                {
                    break;
                }
            }

            if (isInOrder)
            {
                var middle = input[input.Length / 2];
                sortedSum += middle;
            }
        }

        Console.WriteLine(sortedSum);
    }

    public void Part2()
    {
        var file = File.ReadAllLines("Day5/day5_rules.txt");
        var dict = new Dictionary<int, List<int>>();
        foreach (var line in file)
        {
            var l = line.Split('|');
            var key = Int32.Parse(l[0]);
            var value = Int32.Parse(l[1]);
            if (dict.ContainsKey(key))
            {
                dict[key].Add(value);
            }
            else
            {
                dict.Add(key, [value]);
            }
        }
        
        var sortedSum = 0;
        var notSortedSum = 0;

        var lines = File.ReadAllLines("Day5/day5_input.txt");

        foreach (var line in lines)
        {
            var input = line.Split(',').Select(int.Parse).ToArray();
            var isInOrder = true;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                var current = input[i];
                for (int j = 0; j < i; j++)
                {
                    if (dict.ContainsKey(current) && dict[current].Contains(input[j]))
                    {
                        isInOrder = false;
                        break;
                    }
                }

                if (!isInOrder)
                {
                    break;
                }
            }

            if (isInOrder)
            {
                var middle = input[input.Length / 2];
                sortedSum += middle;
            }
            else
            {
                do
                {
                    isInOrder = true;
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        var current = input[i];
                        for (int j = 0; j < i; j++)
                        {
                            if (dict.ContainsKey(current) && dict[current].Contains(input[j]))
                            {
                                isInOrder = false;
                                input[i] = input[j];
                                input[j] = current;
                                break;
                            }
                        }

                        if (!isInOrder)
                        {
                            break;
                        }
                    }
                } while (!isInOrder);

                var middle = input[input.Length / 2];
                notSortedSum += middle;
            }
        }


        Console.WriteLine($"Sorted sum : {sortedSum}");
        Console.WriteLine($"Not Sorted sum : {notSortedSum}");
    }
}