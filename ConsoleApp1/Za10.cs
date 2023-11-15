namespace ConsoleApp1;

public class Za10: IProgramModule
{
    public void Run()
    {
        List<string> rawData = null;

        List<char> downChar = new List<char>();
        List<int> upChar = new List<int>();
        
        Console.WriteLine("Encrypt / Decrypt");
        

        if (Console.ReadLine()![0] == 'E')
        {
            rawData = new List<string>(File.ReadAllLines("Z10_DataSetRaw.dat"));
            Console.WriteLine("Starting Encrypt");
            Console.WriteLine("Enter key-word");

            string key = Console.ReadLine().ToLower();
            
            List<char> downKey = key.ToLower().Select(Convert.ToChar).ToList();


            downKey = downKey.Distinct().ToList();
            downChar = new List<char>(downKey);
            
            for (int i = 1072; i <= 1103; i++)
            {
                downChar.Add((char)i);
            }
            
            downChar = downChar.Distinct().ToList();

            string data = null;
            
            foreach (var str in rawData)
            {
                foreach (var chr in str.ToLower())
                {
                    if (chr >= 1072 && chr <= 1103)
                    {
                        char t =  downChar[((int)chr) - 1072];
                        data += t;
                        continue;
                    }

                    data += chr;
                }

                data += "\n";
            }
            
            File.WriteAllText("Z10_DataSetEncrypt.dat", data);
            Console.WriteLine(data);
        }
        else
        {
            rawData = new List<string>(File.ReadAllLines("Z10_DataSetEncrypt.dat"));
            Console.WriteLine("Starting Decrypt");
            Console.WriteLine("Enter key-word");
            string key = Console.ReadLine();
            
            List<char> downKey = key.ToLower().Select(Convert.ToChar).ToList();

            downKey = downKey.Distinct().ToList();
            downChar = new List<char>(downKey);
            
            
            for (int i = 1072; i <= 1103; i++)
            {
                downChar.Add((char)i);
            }
            
            downChar = downChar.Distinct().ToList();

            string data = null;
            
            foreach (var str in rawData)
            {
                foreach (var chr in str.ToLower())
                {
                    if (chr >= 1072 && chr <= 1103)
                    {
                        int index = downChar.FindIndex((x => x == chr));
                        if (index >= 0)
                        {
                            char t = (char)(1072 + index);
                            data += t;   
                            continue;
                        }
                        data += chr;
                        continue;
                    }

                    data += chr;
                }

                data += "\n";
            }
            
            File.WriteAllText("Z10_DataSetDecrypt.dat", data);
            Console.WriteLine(data);
        }
    }
}