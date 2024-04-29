using System;
using System.Net;

namespace ConsoleApp1;

public class L1Za1 : IProgramModule
{
    /*У Васи в комнате очень много коробок, которые валяются в разных местах. Васина мама хочет, чтобы
        он прибрался. Свободного места в комнате мало и поэтому Вася решил собрать все коробки и
        составить их одну на другую.
        К сожалению, это может быть невозможно. Например, если на картонную коробку с елочными
    украшениями положить что-то железное и тяжелое, то вероятно следующий Новый год придется
        встречать с новыми игрушками.
        Вася взвесил каждую коробку и оценил максимальный вес, который она может выдержать. Помогите
        ему определить какое наибольшее количество коробок m он сможет составить одну на другую так,
    чтобы для каждой коробки было верно, что суммарный вес коробок сверху не превышает
    максимальный вес, который она может выдержать.
        Входные данные
    Первая строка входного файла содержит целое число n (1 n 105) - количество коробок в комнате.
        Каждая следующая из n строк содержит два целых числа wi и ci (1 wi 105 1 ci 109),
    где wi − это вес коробки с номером i, а ci − это вес который она может выдержать.
        Выходные данные
        В выходной файл выведите одно число − ответ на задачу*/


    class Box
    {
        public int Weight { get; set; }
        public int Capacity { get; set; }

        public Box(int weight, int capacity)
        {
            Weight = weight;
            Capacity = capacity;
        }
    }

    // Функция для нахождения максимального количества коробок, которые можно составить одну на другую
    static int MaxStackBoxes(int n, List<Box> boxes)
    {
        // Сортируем коробки по сумме (Weight + Capacity)
        boxes.Sort((a, b) => (a.Weight + a.Capacity).CompareTo(b.Weight + b.Capacity));

        int maxCount = 0;
        int currentWeight = 0;

        // Проходим по каждой коробке
        foreach (var box in boxes)
        {
            // Если текущий суммарный вес не превышает максимальный вес, который может выдержать коробка
            if (currentWeight <= box.Capacity)
            {
                // Увеличиваем счетчик коробок
                maxCount++;
                // Добавляем вес текущей коробки к суммарному весу
                currentWeight += box.Weight;
            }
        }


        return maxCount;
    }

    void RunTest(int count, List<Box> boxes, int answer)
    {
        Console.WriteLine("Запуск теста");
        Console.WriteLine("Входные данные:");
        Console.WriteLine(count);
        foreach (var box in boxes)
        {
            Console.WriteLine($"{box.Capacity} {box.Weight}");
        }

        int result = 1;

        if (boxes.Count != 0)
        {
            // Вычисляем максимальное количество коробок
            result = MaxStackBoxes(count, boxes);

            Console.WriteLine("Результат:");

            // Выводим результат
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Результат:");

            // Выводим результат
            Console.WriteLine(1);
        }

        Console.WriteLine("Правильный ответ:");

        Console.WriteLine(answer);

        Console.WriteLine(answer == result ? "Тест завешен успешно!" : "Тест не пройден!");
    }

    void ReadTest()
    {
        List<Box> boxes = new List<Box>();

        bool begin = false;
        bool read = false;
        bool end = false;
        int count = 0;
        foreach (var line in File.ReadAllLines("L1Za1.txt"))
        {
            if (begin)
            {
                count = Convert.ToInt32(line);
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
                RunTest(count, boxes, tmp);
                boxes.Clear();
                end = false;
            }

            if (read)
            {
                if (line == "")
                {
                    continue;
                }

                string[] data = line.Split();
                int weight = int.Parse(data[0]);
                int capacity = int.Parse(data[1]);
                boxes.Add(new Box(weight, capacity));
            }
        }
    }

    public void Run()
    {
        Console.WriteLine("Здание 1");

        Console.WriteLine("Ищу тесты");
        while (true)
        {
            if (File.Exists("L1Za1.txt"))
            {
                Console.WriteLine("Тест L1Za1 найден");
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
                    var url = "https://raw.githubusercontent.com/Dream-Wood/Inf-Labs/master/ConsoleApp1/L1/L1Za1.txt";
                    var httpClient = new HttpClient();
                    var response = httpClient.GetAsync(url);

                    if (response.Result.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("404");
                    }
                    
                    var stream = response.Result.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytesAsync("L1Za1.txt", stream.Result);
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

        // Чтение входных данных
        int n = int.Parse(Console.ReadLine());
        List<Box> boxes = new List<Box>();

        for (int i = 0; i < n; i++)
        {
            string rawLine = Console.ReadLine();

            if (rawLine == "")
            {
                Console.WriteLine(1);
                return;
            }

            string[] line = rawLine.Split();
            int weight = int.Parse(line[0]);
            int capacity = int.Parse(line[1]);
            boxes.Add(new Box(weight, capacity));
        }

        // Вычисляем максимальное количество коробок
        int result = MaxStackBoxes(n, boxes);

        // Выводим результат
        Console.WriteLine(result);
    }
}