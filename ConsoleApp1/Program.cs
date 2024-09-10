namespace ConsoleApp1;

public class InvalidPlaceDataException : Exception
{
    public InvalidPlaceDataException(string message) : base(message)
    {
    }
}

public class Program
{
    static void Main()
    {
        List<Place> places = new List<Place>();
        var filePath = "places.txt";
        var logFilePath = "error_log.txt";

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                try
                {
                    switch (parts[0])
                    {
                        case "City":
                            if (parts.Length > 3)
                            {
                                places.Add(new City(parts[1], int.Parse(parts[2]), parts[3]));   
                            }
                            else
                            {
                                places.Add(new City(parts[1], int.Parse(parts[2])));   
                            }
                            break;
                        case "Megapolis":
                            if (parts.Length > 4)
                            {
                                places.Add(new Megapolis(parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4])));
                            }
                            else
                            {
                                places.Add(new Megapolis(parts[1], int.Parse(parts[2]), parts[3])); 
                            }
                            break;
                        case "Village":
                            if (parts.Length > 3)
                            {
                                places.Add(new Village(parts[1], int.Parse(parts[2]), parts[3]));
                            }
                            else
                            {
                                places.Add(new Village(parts[1], int.Parse(parts[2])));
                            }
                            break;
                        case "Farmstead":
                            if (parts.Length > 3)
                            {
                                places.Add(new Farmstead(parts[1], int.Parse(parts[2]), parts[3])); 
                            }
                            else
                            {
                                places.Add(new Farmstead(parts[1], int.Parse(parts[2])));
                            }
                            break;
                        default:
                            throw new InvalidPlaceDataException($"Неизвестный тип места: {parts[0]}");
                    }
                }
                catch (ArgumentException ex)
                {
                    LogError(logFilePath, $"Ошибка данных: {ex.Message} - строка: {line}");
                }
                catch (InvalidPlaceDataException ex)
                {
                    LogError(logFilePath, $"Некорректные данные: {ex.Message} - строка: {line}");
                }
            }

            foreach (var place in places)
            {
                place.Description();
                place.Info();
                Console.WriteLine();
            }
        }
        catch (FileNotFoundException ex)
        {
            LogError(logFilePath, $"Файл не найден: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            LogError(logFilePath, $"Нет доступа к файлу: {ex.Message}");
        }
    }

    static void LogError(string logFilePath, string message)
    {
        try
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не удалось записать в лог: {ex.Message}");
        }
    }
}

class City : Place
{
    public string Mayor { get; set; }

    public City(string name, int population, string mayor) : base(name, population)
    {
        Mayor = mayor;
    }

    public City(string name, int population) : base(name, population)
    {
    }

    public override void Description()
    {
        Console.WriteLine($"{Name} - это город с населением {Population} и мэром {Mayor}.");
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Мэр города: {Mayor}");
    }
}

class Megapolis : City
{
    public int NumberOfDistricts { get; set; }

    public Megapolis(string name, int population, string mayor, int numberOfDistricts)
        : base(name, population, mayor)
    {
        NumberOfDistricts = numberOfDistricts;
    }

    public Megapolis(string name, int population, string mayor)
        : base(name, population, mayor)
    {
    }

    public override void Description()
    {
        Console.WriteLine(
            $"{Name} - это мегаполис с населением {Population}, мэром {Mayor} и {NumberOfDistricts} районами.");
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Количество районов: {NumberOfDistricts}");
    }
}

class Village : Place
{
    public string Elder { get; set; }

    public Village(string name, int population, string elder) : base(name, population)
    {
        if (string.IsNullOrWhiteSpace(elder))
        {
            throw new InvalidPlaceDataException("Имя старосты не может быть пустым.");
        }

        Elder = elder;
    }
    
    public Village(string name, int population) : base(name, population)
    {
    }

    public override void Description()
    {
        Console.WriteLine($"{Name} - это село с населением {Population}. Староста: {Elder}.");
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Староста села: {Elder}");
    }
}

class Farmstead : Place
{
    public string Owner { get; set; }

    public Farmstead(string name, int population, string owner)
        : base(name, population)
    {
        Owner = owner;
    }

    public Farmstead(string name, int population) : base(name, population)
    {
    }

    public override void Description()
    {
        Console.WriteLine(
            $"{Name} - это хутор с населением {Population}. Владельцем является {Owner}.");
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Владелец хутора: {Owner}");
    }
}