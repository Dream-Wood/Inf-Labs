using ConsoleApp1;

IProgramModule module = new Za1();

while (true)
{
    Console.WriteLine($"Выберите задание: (1,2,3) ЛР2 и (4,5,6) ЛР 3");
    
    if (!int.TryParse(Console.ReadLine(), out int num)) break;
    
    switch (num)
    {
        case 1:
            module = new Za1(); break;
        case 2:
            module = new Za2(); break;
        case 3:
            module = new Za3(); break;
        case 4:
            module = new Za4(); break;
        case 5:
            module = new Za5(); break;
        case 6:
            module = new Za6(); break;
        default:
            Console.WriteLine("Нет такого номера!");
            continue;
    }

    module.Run();
}