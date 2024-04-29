using System;

namespace ConsoleApp1;

public class L1Za1: IProgramModule
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

     void RunOnTest()
    {
        
    }
    
    public void Run()
    {
        Console.WriteLine("Здание 1");
        
        Console.WriteLine("Ищу тесты");
        if (File.Exists("L1Za1.txt"))
        {
            Console.WriteLine("Тест L1Za1 найден");
            Console.WriteLine("Использовать тест (Y/N)");

            if (Console.ReadLine().Trim() == "Y")
            {
                RunOnTest();
            }
        }
        else
        {
            Console.WriteLine("Тест не найден");   
            Console.WriteLine("Ищу в интеренете...");
            
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