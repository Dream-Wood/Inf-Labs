namespace ConsoleApp1;

public class L1Za3 : IProgramModule
{
    public void Run()
    {
        Console.Write("Введите размер квадрата (N): ");
        int N = int.Parse(Console.ReadLine());

        // Считываем сетку N×N значений монет
        int[,] grid = new int[N, N];
        Console.WriteLine("Введите номиналы монет (N строк по N чисел):");
        for (int i = 0; i < N; i++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = int.Parse(row[j]);
            }
        }

        // Инициализируем массивы для максимальных и минимальных сумм и путей
        int[,] maxSums = new int[N, N];
        int[,] minSums = new int[N, N];
        string[,] maxPaths = new string[N, N];
        string[,] minPaths = new string[N, N];

        // Устанавливаем начальные значения
        maxSums[0, 0] = grid[0, 0] % 3 == 0 ? grid[0, 0] : 0;
        minSums[0, 0] = maxSums[0, 0]; // Начальная сумма одинакова для обоих случаев
        maxPaths[0, 0] = "";
        minPaths[0, 0] = "";

        // Вычисляем максимальные и минимальные суммы и пути
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                // Пропускаем начальную клетку
                if (i == 0 && j == 0) continue;

                int coinValue = grid[i, j];
                int coin = coinValue % 3 == 0 ? coinValue : 0;

                // Вычисление максимальной суммы и пути
                if (i > 0)
                {
                    int down = maxSums[i - 1, j] + coin;
                    if (down > maxSums[i, j])
                    {
                        maxSums[i, j] = down;
                        maxPaths[i, j] = maxPaths[i - 1, j] + "D";
                    }
                }

                if (j > 0)
                {
                    int right = maxSums[i, j - 1] + coin;
                    if (right > maxSums[i, j])
                    {
                        maxSums[i, j] = right;
                        maxPaths[i, j] = maxPaths[i, j - 1] + "R";
                    }
                }

                // Вычисление минимальной суммы и пути
                if (i > 0)
                {
                    int down = minSums[i - 1, j] + coin;
                    if (down < minSums[i, j] || minSums[i, j] == 0)
                    {
                        minSums[i, j] = down;
                        minPaths[i, j] = minPaths[i - 1, j] + "D";
                    }
                }

                if (j > 0)
                {
                    int right = minSums[i, j - 1] + coin;
                    if (right < minSums[i, j] || minSums[i, j] == 0)
                    {
                        minSums[i, j] = right;
                        minPaths[i, j] = minPaths[i, j - 1] + "R";
                    }
                }
            }
        }


        // Выводим результаты
        Console.WriteLine($"Максимальная сумма: {maxSums[N - 1, N - 1]}");
        Console.WriteLine($"Путь для максимальной суммы: {maxPaths[N - 1, N - 1]}");
        Console.WriteLine($"Минимальная сумма: {minSums[N - 1, N - 1]}");
        Console.WriteLine($"Путь для минимальной суммы: {minPaths[N - 1, N - 1]}");
    }
}