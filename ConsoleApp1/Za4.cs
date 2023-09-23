namespace ConsoleApp1;

public class Za4 : IProgramModule
{
    public void Run()
    {
        int[] a = { 1, 2, 3, 2, 3, 4, 9 };
        
        string? result = null;

        for (int x = 0; x < a.Length; x++)
        {
            bool isCorrect = true;

            for (int y = 0; y < a.Length; y++)
            {
                if (x == y) continue;
                if (a[x] == a[y])
                {
                    isCorrect = false;
                }
            }

            if (isCorrect)
            {
                result += a[x] + " ";
            }
        }

        Console.WriteLine(result);
    }
}