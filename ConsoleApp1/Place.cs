namespace ConsoleApp1;

public abstract class Place
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
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Название места не может быть пустым или null.");
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
                throw new ArgumentException("Население не может быть отрицательным.");
            }
            
            _population = value;
        }
    }

    public Place(string name, int population)
    {
        Name = name;
        Population = population;
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
    
    public abstract void Description();
    
    public virtual void Info()
    {
        Console.WriteLine($"Место: {Name}, Население: {Population}");
    }
}