namespace ConsoleApp1;

public class InvalidPlaceDataException : Exception
{
    public InvalidPlaceDataException(string message) : base(message) { }
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
                            places.Add(new City(parts[1], int.Parse(parts[2]), parts[3]));
                            break;
                        case "Megapolis":
                            places.Add(new Megapolis(parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4])));
                            break;
                        case "Village":
                            places.Add(new Village(parts[1], int.Parse(parts[2]), parts[3]));
                            break;
                        case "Farmstead":
                            places.Add(new Farmstead(parts[1], int.Parse(parts[2]), parts[3], parts[4]));
                            break;
                        default:
                            throw new InvalidPlaceDataException($"Неизвестный тип места: {parts[0]}");
                    }
                }
                catch (ArgumentException ex)
                {
                    LogError(logFilePath, ex.ToString());
                }
                catch (InvalidPlaceDataException ex)
                {
                    LogError(logFilePath, ex.ToString());
                }
                catch (NullReferenceException ex)
                {
                    LogError(logFilePath, ex.ToString());
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
            LogError(logFilePath, ex.ToString());
        }
        catch (Exception ex)
        {
            LogError(logFilePath, ex.ToString());
        }
    }
    
    static void LogError(string logFilePath, string message)
    {
        Console.WriteLine("-------------------");
        Console.WriteLine(message);
        Console.WriteLine("-------------------");

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
        if (string.IsNullOrWhiteSpace(mayor))
        {
            throw new InvalidPlaceDataException("Имя мэра не может быть пустым.");
        }

        Mayor = mayor;
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
        if (numberOfDistricts <= 0)
        {
            throw new ArgumentException("Количество районов должно быть положительным.");
        }

        NumberOfDistricts = numberOfDistricts;
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

class Farmstead : Village
{
    public string Owner { get; set; }

    public Farmstead(string name, int population, string elder, string owner)
        : base(name, population, elder)
    {
        if (string.IsNullOrWhiteSpace(owner))
        {
            throw new InvalidPlaceDataException("Имя владельца не может быть пустым.");
        }

        Owner = owner;
    }

    public override void Description()
    {
        Console.WriteLine(
            $"{Name} - это хутор с населением {Population}. Владельцем является {Owner}, староста: {Elder}.");
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine($"Владелец хутора: {Owner}");
    }
}