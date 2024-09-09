namespace ConsoleApp1;

public class Program
{
    private static void Main()
    {
        var place = new Place("Kazan", 99);
        var place2 = new Place("Minsk", 33);

        place.Population = 3000;
        place.Name = "Moscow";
        
        place.Print();
        place2.Print();
        
        Console.WriteLine($"Население в {place} больше чем в {place2} = {place > place2}");
       
        place.Random();
        place.Print();
    }
}
 
public class Place
{
    private string _name;
    private int _population;

    public string Name
    {
        get => _name;
        set
        {
            if (value.Length is 0 or > 32)
            {
                throw new ArgumentException("Name must be between 0 and 32 characters");
            }

            _name = value;
        }
    }

    public int Population
    {
        get => _population;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Population must be a positive number");
            }
            
            _population = value;
        }
    }

    public Place()
    {
        throw new NotImplementedException();
    }

    public Place(string name, int population)
    {
        _name = name;
        _population = population;
    }

    public void Random()
    {
        _population = new Random().Next(0, int.MaxValue);
    }

    public void Print()
    {
        Console.WriteLine($"Name: {Name}, Population: {Population}");
    }

    public static bool operator >(Place a, Place b)
    {
        return a.Population > b.Population;
    }

    public static bool operator <(Place a, Place b)
    {
        return a.Population < b.Population;
    }
    
    public override string ToString()
    {
        return _name;
    }
}
