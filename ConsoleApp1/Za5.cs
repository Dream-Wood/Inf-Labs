namespace ConsoleApp1;

public class Za5 : IProgramModule
{
    public void Run()
    {
        Console.Write("\nArray Length: ");

        if (int.TryParse(Console.ReadLine(), out var n))
        {
            var arr = new int[n];

            Console.WriteLine("Array Elements: ");
            for (var i = 0; i < arr.Length; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    throw new Exception("Invalid number");
                }
            }


            Console.Write("\nSerial Select: ");
            if (!int.TryParse(Console.ReadLine(), out var select))
            {
                throw new Exception("Invalid number");
            }

            var arrMask = arr.Distinct().ToArray();

            if (select > arrMask.Length)
            {
                foreach (var el in arr)
                {
                    Console.Write(el + " ");
                }
            }
            else
            {
                int last = -1;
                bool isSelect = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == arrMask[select])
                    {
                        Console.Write(arr[i] + " ");
                        last = i;
                        isSelect = true;
                    }

                    if (i - last >= 1 && isSelect)
                    {
                        break;
                    }
                }
            }
        }
    }
}