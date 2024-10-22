namespace ConsoleApp1;

public abstract class Place: IComparable<Place>
{
    private string _name;
    private int _population;
    private int _funds;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullReferenceException("Название места не может быть пустым или null.");
            }
            
            if (value.Length is 0 or > 32)
            {
                throw new ArgumentException("Name must be between 0 and 32 characters");
            }

            _name = value;
        }
    }

    public int Funds
    {
        get => _funds;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Население не может быть отрицательным.");
            }
            
            _funds = value;
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

    public Place(string name, int population, int funds = 0)
    {
        Name = name;
        Population = population;
        Funds = funds;
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

    public override bool Equals(object? obj)
    {
        return _name == obj.ToString();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_name, _population, _funds);
    }

    public abstract void Description();
    
    public virtual void Info()
    {
        Console.WriteLine($"Место: {Name}, Население: {Population}, Средства: {Funds}");
    }

    public int CompareTo(Place? other)
    {
        if (other is null) return 1;
        return String.Compare(_name, other._name, StringComparison.Ordinal);
    }
}