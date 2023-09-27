namespace ConsoleApp1;

public class Za7: IProgramModule
{
    public void Run()
    {

        double a = double.Parse(Console.ReadLine() ?? string.Empty);
        double b = double.Parse(Console.ReadLine() ?? string.Empty);
        double r = double.Parse(Console.ReadLine() ?? string.Empty);
        double d = double.Parse(Console.ReadLine() ?? string.Empty);
        double e = double.Parse(Console.ReadLine() ?? string.Empty);

        // (x-a)^2 + (y-b)^2 = r^2
        // y = dx + e

        double core = 2 * Math.Sqrt(-2*a*d*e + 2*a*d*b - Math.Pow(e, 2) - Math.Pow(b, 2) + 2*e*b + Math.Pow(r,2) - Math.Pow(d,2) * Math.Pow(a,2) + Math.Pow(d,2)*Math.Pow(r,2));
        double x1 = (2*a-2*d*e+2*d*b + core) / (2+2*Math.Pow(d,2));
        double x2 = (2*a-2*d*e+2*d*b - core) / (2+2*Math.Pow(d,2));

        double y1 = d * x1 + e;
        double y2 = d * x2 + e;

        if (double.IsNaN(x1))
        {
            Console.WriteLine("Не пересекаются");
        }
        else if (Math.Abs(x1 - x2) < 0.1)
        {
            Console.WriteLine(x1 + " " + y1);
        }
        else
        {
            Console.WriteLine(x1 + " " + y1);
            Console.WriteLine(x2 + " " + y2);
        }

    }
}