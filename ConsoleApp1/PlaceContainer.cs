namespace ConsoleApp1;

public class PlaceContainer
{
    private readonly LinkedList<Place> _place = new LinkedList<Place>();
    
    public void Add(Place person)
    {
        _place.AddLast(person);
    }
    
    public void Remove(Place person)
    {
        _place.Remove(person);
    }
    
    public Place GetFirst()
    {
        return _place.First?.Value;
    }
    
    public Place GetLast()
    {
        return _place.Last?.Value;
    }
    
    public bool Contains(Place person)
    {
        return _place.Contains(person);
    }
    
    public void Clear()
    {
        _place.Clear();
    }

    public void PrintAll()
    {
        foreach (var person in _place)
        {
            Console.WriteLine(person);
        }
    }
}