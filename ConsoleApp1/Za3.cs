namespace ConsoleApp1;

public class Za3: IProgramModule
{
    public void Run()
    {
        int max = 0, max2 = 0, max3 = 0, max6 = 0;
        List<int> data = new List<int>();

        while (true)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int segment))
            {
                break;
            }

            if (input == "0")
            {
                break;
            }
            
            data.Add(segment);
            
            if (segment > max)
            {
                max = segment;
            }
            
            if (segment % 6 == 0 && segment > max6)
            {
                max6 = segment;
            }
            else if (segment % 3 == 0 && segment > max3)
            {
                max3 = segment;
            }
            else if (segment % 2 == 0 && segment > max2)
            {
                max2 = segment;
            }
        }
        
        
        int control = int.Parse(Console.ReadLine());

        Console.WriteLine($"Получено {data.Count} чисел");
        Console.WriteLine($"Получено контрольное значени: {control}");

        int sum = max6 * max <= max2 * max3 ? max2 * max3 : max6 * max;
        
        Console.WriteLine($"Вычисленное контрольное значени: {sum}");

        if (sum == control)
        {
            Console.WriteLine($"Контроль пройден.");
        }
        else
        {
            Console.WriteLine($"Контроль не пройден.");
        }
    }
}