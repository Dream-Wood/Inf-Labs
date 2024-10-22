namespace ConsoleApp1;

public class InvalidPlaceDataException : Exception
{
    public InvalidPlaceDataException(string message) : base(message) { }
}

public class FundsComparer : IComparer<Place>
{
    public int Compare(Place? x, Place? y)
    {
        if (x == null || y == null) return 0;
        return -x.Funds.CompareTo(y.Funds);
    }
}   

public class Program
{
    static void Main()
    {
        List<Place> places = new List<Place>();
        
        places.Add(new City("New York", 3500000, 900000,"Joy"));
        places.Add(new City("Владивосток", 65000, 123456,"Владик"));
        places.Add(new City("Тверь", 120065, 35000,"Иван"));
        places.Add(new City("Архангельск", 1678765,45920, "Никита"));
        places.Add(new Village("Никель", 20000, 250000,"Захар"));
        
        foreach (var p in places)
        {
            p.Info();
        }
        
        Console.WriteLine();
        places.Sort();
        Console.WriteLine("Сортировка по названию");
        
        foreach (var p in places)
        {
            p.Info();
        }

        Console.WriteLine();
        places.Sort(new FundsComparer());
        Console.WriteLine("Сортировка по кол-ву средств");

        foreach (var p in places)
        {
            p.Info();
        }

        Stack<string> st = new Stack<string>();
        
        
        st.Push("Слава");
        st.Push("Владислав");
        st.Push("Никта");

        foreach (var i in st)
        {
            Console.WriteLine(i);
        }
        
        Console.WriteLine($"{st.Peek()} на первом месте");
        
        var tmp = st.Pop();
        
        Console.WriteLine($"{tmp} на достали");
        
        st.Push("Захар");
        
        Console.WriteLine($" добавили Захара и он {st.Peek()} на первом месте");
        
        
        Console.WriteLine("-----");
        
        PlaceContainer container = new PlaceContainer();
        container.Add(new City("New York", 3500000, 900000,"Joy"));
        container.Add(new City("Владивосток", 65000, 123456,"Владик"));
        container.Add(new City("Тверь", 120065, 35000,"Иван"));
        container.Add(new City("Архангельск", 1678765,45920, "Никита"));
        container.Add(new Village("Никель", 20000, 250000,"Захар"));

        // Печать всех элементов
        Console.WriteLine("Все элементы в контейнере:");
        container.PrintAll();

        // Получение первого и последнего элемента
        Console.WriteLine($"\nПервый элемент: {container.GetFirst()}");
        Console.WriteLine($"Последний элемент: {container.GetLast()}");

        // Проверка удаления элемента
        Place del = new City("Архангельск", 1678765,45920, "Никита");
        container.Remove(del);
        container.PrintAll();
        
        // Проверка наличия элемента
        Place searchPerson = new City("Тверь", 120065, 35000, "Иван");
        Console.WriteLine($"\nКонтейнер содержит {searchPerson.Name}? {container.Contains(searchPerson)}");

        // Очистка контейнера
        container.Clear();
        Console.WriteLine("\nКонтейнер после очистки:");
        container.PrintAll(); 
    }
    
}

class City : Place
{
    public string Mayor { get; set; }

    public City(string name, int population, int funds, string mayor) : base(name, population, funds)
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
    
}

class Megapolis : City
{
    public int NumberOfDistricts { get; set; }

    public Megapolis(string name, int population, int funds, string mayor, int numberOfDistricts)
        : base(name, population, funds,mayor)
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
    
}

class Village : Place
{
    public string Elder { get; set; }

    public Village(string name, int population, int funds, string elder) : base(name, population, funds)
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
    
}

class Farmstead : Village
{
    public string Owner { get; set; }

    public Farmstead(string name, int population,int funds, string elder, string owner)
        : base(name, population, funds,elder)
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
    
}