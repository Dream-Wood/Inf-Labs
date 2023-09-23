using System;

namespace ConsoleApp1;

public class Za1: IProgramModule
{
    public void Run()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        double A = Convert.ToDouble(Console.ReadLine());
        double B = Convert.ToDouble(Console.ReadLine());
        int e = Convert.ToInt32(Console.ReadLine());

        double step = (Math.Abs(A) + B) / (N * 1.0);

        Console.WriteLine($"Step : {step}");
        Console.WriteLine($"|  x  \t|\t\t  f1  \t\t|\t\t  f2  \t\t|\t\t  f3  \t\t|");

        for (double x = A; x < B; x += step)
        {
            Console.WriteLine($"|{Math.Round(x, 5)}\t|\t{F1(x, e)}\t|\t{F2(x, e)}\t|\t{F3(x, e)}\t|");
        }
    }

    double F1(double x, int e)
    {
        //double rad = x * (Math.PI / 180.0);
        return Math.Sinh(x * 1.0);
    }

    double F2(double x, int e)
    {
        double result = x;

        for (int i = 3; i < e; i += 2)
        {
            result += Math.Pow(x, i) / Factorial(Convert.ToInt32(i));
        }

        return result;
    }

    double F3(double x, int e)
    {
        double result = 0;

        for (int i = 0; i < e; i++)
        {
            result += 1.0 / Factorial(2 * i + 1) * Math.Pow(x, 2 * i + 1.0);
        }

        return result;
    }


    int Factorial(int f)
    {
        if (f == 0)
            return 1;
        else
            return f * Factorial(f - 1);
    }
}