using System.Reflection;

namespace ConsoleApp1;

public class Za6 : IProgramModule
{
    public void Run()
    {
        string[] rawData = File.ReadAllLines("Z6_DataSet.dat");
        int[] data = new int[rawData.Length];
        int[] Y = new int[rawData.Length];
        int[] Z = new int[rawData.Length];
        int[] W = new int[rawData.Length];

        for (int i = 0; i < rawData.Length; i++)
        {
            int.TryParse(rawData[i], out data[i]);
        }

        int iter = 0;

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = i + 1; j < data.Length; j++)
            {
                if (Math.Abs(data[i] - data[j]) == 2)
                {
                    Y[iter] = data[i];
                    Y[iter + 1] = data[j];
                    iter += 2;
                }
            }
        }

        iter = 0;
        int iter2 = 0;

        Y = Y.Distinct().ToArray();

        foreach (var el in Y)
        {
            if (GetNumberCount(el) == 2)
            {
                Z[iter] = el;
                iter++;
            }

            if (GetNumberCount(el) == 3)
            {
                W[iter2] = el;
                iter2++;
            }
        }

        Z = Z.Distinct().ToArray();
        W = W.Distinct().ToArray();

        for (int i = 0; i < Y.Length; i++)
        {
            Console.Write(Y[i] + " ");
            Console.Write(Z[i] + " ");
            Console.Write(W[i] + " ");
        }
        
        foreach (var i in Y)
        {
            Console.Write(i + " ");
        }

        Console.Write("\n");
        foreach (var i in Z)
        {
            Console.Write(i + " ");
        }

        Console.Write("\n");
        foreach (var i in W)
        {
            Console.Write(i + " ");
        }
    }

    int GetNumberCount(int x)
    {
        return x.ToString().Length;
    }

    bool IsSimple(int n)
    {
        if (n < 2)
            return false;
        for (int i = 2; i <= n / 2; i++)
            if (n % i == 0)
                return false;
        return true;
    }
}