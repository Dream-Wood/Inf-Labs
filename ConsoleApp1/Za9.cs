namespace ConsoleApp1;

public class Za9: IProgramModule
{
    // Lb 4 Zd 1
    public void Run()
    {
        List<Char> mask = new List<char> {'X', 'Y', 'Z'};
        string[] rawData = File.ReadAllLines("Z9_DataSet.dat");

        int max = 0;
        
        foreach (var strings in rawData)
        {
            int count = 0;
            foreach (var c in strings)
            {
                bool chain = false;
                chain = (c is 'X' or 'Y' or 'Z') && (!chain);

                if (chain)
                {
                    var index = mask.BinarySearch(c);
                    
                    if (c == 'X' && index == 0)
                    {
                        count++;
                    }
                    else
                    if (c == 'Y' && index == 1)
                    {
                        count++;
                    }
                    else
                    if (c == 'Z' && index == 2)
                    {
                        count++;
                    }
                }
                else
                {
                    if (max < count)
                    {
                        max = count;
                    }
                }
            }
        }
        
        Console.WriteLine(max);
    }
}