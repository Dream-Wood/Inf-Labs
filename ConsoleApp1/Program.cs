namespace ConsoleApp1;

public class Program
{
    private static void Main()
    {
        List<Place> places = new List<Place>();
        
        const string filePath = "places.txt";
        var lines = File.ReadAllLines(filePath);
        if (File.Exists(filePath))
        {
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

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
                }
            }
        }
        else
        {
            Console.WriteLine("Файл не найден.");
            return;
        }
        
        foreach (Place place in places)
        {
            place.Description();
            place.Info();
            Console.WriteLine();
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

        public override void Description()
        {
            Console.WriteLine($"{Name} - это мегаполис с населением {Population}, мэром {Mayor} и {NumberOfDistricts} районами.");
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
            Owner = owner;
        }

        public override void Description()
        {
            Console.WriteLine($"{Name} - это хутор с населением {Population}. Владельцем является {Owner}, староста: {Elder}.");
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Владелец хутора: {Owner}");
        }
    }