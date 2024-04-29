using System.Net;

namespace ConsoleApp1;

public class L1Za2 : IProgramModule
{
    /*Васин дедушка построил забор на даче из того, что попалось под руку. Забор представляет собой
        ряд из N досок ширины 10 см, но, возможно, различной высоты.
        Теперь Вася хочет покрасить забор таким способом. Он выбирает 5 произвольных подряд идущих
        досок и красит их в один цвет. Затем он выбирает 5 любых еще не покрашенных идущих подряд
    досок и красит их в другой цвет. И так продолжает до тех пор, пока может выбрать 5 подряд
        идущих не покрашенных досок.
        Требуется определить, какую наибольшую площадь забора он сможет покрасить таким способом.
        Входные данные
        В первой строке входного файла вводится одно число N - количество досок.
        Во второй строке входного файла вводятся N чисел - высоты 1-й, 2-й, ..., N-й досок забора в
    сантиметрах.
        Все числа натуральные и не превосходят 100.
    Выходные данные
    Выведите одно число: наибольшую покрашенную площадь в квадратных сантиметрах.*/

    public void Run()
    {
        
        Console.WriteLine("Здание 2");

        Console.WriteLine("Ищу тесты");
        while (true)
        {
            if (File.Exists("L1Za2.txt"))
            {
                Console.WriteLine("Тест L1Za2 найден");
                Console.WriteLine("Использовать тест (Y/N)");

                if (Console.ReadLine()?.Trim() == "Y")
                {
                    ReadTest();
                    return;
                }

                break;
            }
            else
            {
                Console.WriteLine("Тест не найден");
                Console.WriteLine("Ищу в интеренете...");

                try
                {
                    var url = "https://raw.githubusercontent.com/Dream-Wood/Inf-Labs/master/ConsoleApp1/L1/L1Za2.txt";
                    var httpClient = new HttpClient();
                    var response = httpClient.GetAsync(url);
                    
                    if (response.Result.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("404");
                    }
                    
                    var stream = response.Result.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytesAsync("L1Za2.txt", stream.Result);
                    Console.WriteLine("Файл загружен!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("В интеренете только котики");
                    break;
                }
            }
        }

        Console.WriteLine("Ввод данных вручную");
        
        // Считываем количество досок
        int n = int.Parse(Console.ReadLine());

        // Считываем высоты досок
        int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // Проверяем, достаточно ли досок для покраски
        if (n < 5)
        {
            Console.WriteLine(0);
            return;
        }

        // Инициализируем массив для динамического программирования
        int[] dp = new int[n];

        // Заполняем массив dp
        for (int i = 4; i < n; i++)
        {
            // Вычисляем площадь покрашенных досок
            int area = 0;
            for (int j = i - 4; j <= i; j++)
            {
                area += heights[j];
            }

            // Сравниваем текущую максимальную площадь с ранее рассчитанным значением dp
            dp[i] = area + (i >= 5 ? dp[i - 5] : 0);

            // Обновляем dp[i] как максимум между текущей площадью и dp[i - 1]
            if (i > 4)
            {
                dp[i] = Math.Max(dp[i], dp[i - 1]);
            }
        }

        // Выводим максимальную покрашенную площадь
        Console.WriteLine(dp[n - 1] * 10);
    }

    private void ReadTest()
    {
        // Считываем количество досок
        int n = 0;

        // Считываем высоты досок
        List<int> heights = new List<int>();
        
        bool begin = false;
        bool read = false;
        bool end = false;

        foreach (var line in File.ReadAllLines("L1Za1.txt"))
        {
            if (begin)
            {
                n = Convert.ToInt32(line);
                begin = false;
                read = true;
                continue;
            }

            if (line.Trim() == "IN")
            {
                begin = true;
                continue;
            }

            if (line.Trim() == "OUT")
            {
                read = false;
                end = true;
                continue;
            }

            if (end)
            {
                int tmp = Convert.ToInt32(line);
                RunTest(n, heights, tmp);
                heights.Clear();
                end = false;
            }

            if (read)
            {
                if (line == "")
                {
                    continue;
                }
                
                heights = Array.ConvertAll(line.Split(), int.Parse).ToList();
            }
        }
    }

    private void RunTest(int n, List<int> heights, int answer)
    {
        Console.WriteLine("Запуск теста");
        Console.WriteLine("Входные данные:");
        Console.WriteLine(n);
        foreach (var i in heights)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
        
        // Проверяем, достаточно ли досок для покраски
        if (n < 5)
        {
            Console.WriteLine(0);
            return;
        }

        // Инициализируем массив для динамического программирования
        int[] dp = new int[n];

        // Заполняем массив dp
        for (int i = 4; i < n; i++)
        {
            // Вычисляем площадь покрашенных досок
            int area = 0;
            for (int j = i - 4; j <= i; j++)
            {
                area += heights[j];
            }

            // Сравниваем текущую максимальную площадь с ранее рассчитанным значением dp
            dp[i] = area + (i >= 5 ? dp[i - 5] : 0);

            // Обновляем dp[i] как максимум между текущей площадью и dp[i - 1]
            if (i > 4)
            {
                dp[i] = Math.Max(dp[i], dp[i - 1]);
            }
        }

        Console.WriteLine("Результат:");

        var result = dp[n - 1] * 10;
        
        // Выводим максимальную покрашенную площадь
        Console.WriteLine(result);

        Console.WriteLine("Правильный ответ:");

        Console.WriteLine(answer);

        Console.WriteLine(answer == result ? "Тест завешен успешно!" : "Тест не пройден!");
    }
}