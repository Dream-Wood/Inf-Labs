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

    public Place(string name, int population)
    {
        _name = name;
        _population = population;
    }

    public void Random()
    {
        _population = new Random().Next(0, int.MaxValue);
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