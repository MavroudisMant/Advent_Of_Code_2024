namespace AdventOfCode;

public class Day9
{
    public void Part1()
    {
        var input = File.ReadAllText("Inputs/day9.txt").Select(x => int.Parse(x.ToString())).ToArray();

        var diskMap = new List<int>();
        var id = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < input[i]; j++)
                {
                    diskMap.Add(id);
                }
                id++;
            }
            else
            {
                for (int j = 0; j < input[i]; j++)
                {
                    diskMap.Add(-1);
                }
            }
        }

        var countSpaces = diskMap.Count(x => x == -1);

        var lastSpaceFound = 0;
        for (int i = 0; i < countSpaces; i++)
        {
            var last = diskMap.Last();
            var firstSpace = diskMap.FindIndex(lastSpaceFound, x => x == -1);
            diskMap[firstSpace] = last;
            diskMap.RemoveAt(diskMap.Count - 1);
            lastSpaceFound = firstSpace;
        }

        var checksum = 0L;

        for (int i = 0; i < diskMap.Count; i++)
        {
            checksum += diskMap[i] * i;
        }
        
        Console.WriteLine(checksum);
    }
    
    public void Part2()
    {
        var input = File.ReadAllText("Inputs/day9.txt").Select(x => int.Parse(x.ToString())).ToArray();

        var diskMap = new List<int>();
        var blockList = new List<Block>();
        var id = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                blockList.Add(new Block(false, input[i], diskMap.Count));
                for (int j = 0; j < input[i]; j++)
                {
                    diskMap.Add(id);
                }
                id++;
            }
            else
            {
                blockList.Add(new Block(true, input[i], diskMap.Count));
                for (int j = 0; j < input[i]; j++)
                {
                    diskMap.Add(-1);
                }
            }
        }

        
        for (int i = blockList.Count-1; i >= 0; i-=2)
        {
            var freeSpace = blockList.FindIndex(x => x.IsFreeSpace && x.Size >= blockList[i].Size);
            
            if (freeSpace == -1 || blockList[freeSpace].FirstIndex >= blockList[i].FirstIndex)
            {
                continue;
            }
            
            var take = diskMap.GetRange(blockList[i].FirstIndex, blockList[i].Size);
            for (int j = 0; j < take.Count; j++)
            {
                diskMap[blockList[freeSpace].FirstIndex + j] = take[j];
                diskMap[blockList[i].FirstIndex + j] = -1;
            }
            
            blockList[freeSpace].Size -= blockList[i].Size;
            if (blockList[freeSpace].Size == 0)
            {
                blockList[freeSpace].IsFreeSpace = false;
            }
            else
            {
                blockList[freeSpace].FirstIndex += blockList[i].Size;
            }
        }

        var checksum = 0L;
        
        for (int i = 0; i < diskMap.Count; i++)
        {
            checksum += diskMap[i] != -1 ? diskMap[i] * i : 0;
        }
        Console.WriteLine(checksum);
    }

    private class Block(bool isFreeSpace, int size, int firstIndex)
    {
        public bool IsFreeSpace { get; set; } = isFreeSpace;
        public int Size { get; set; } = size;
        public int FirstIndex { get; set; } = firstIndex;
    }
}


