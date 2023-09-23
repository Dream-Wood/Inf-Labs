namespace ConsoleApp1;

public class Za2: IProgramModule
{
    public void Run()
    {
        string? result = null;
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int num)) break;
            if (num % 7 == 1 || num % 7 == 2 || num % 7 == 5)
            {
                result += num + " ";
            }
        }
        
        Console.WriteLine(result);
    }
}