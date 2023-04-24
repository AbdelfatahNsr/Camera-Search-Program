
class Program
{
    static void Main(string[] args)
    {
        // Check if there are any arguments
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments provided.");
            return;
        }

        // Loop through each argument and process them
        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];

            switch (arg)
            {
                case "-h":
                case "--help":
                    // Handle help argument
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n");
                    Console.WriteLine("Help information");
                    Console.WriteLine("Use the following example to search for camera names in the format '--name Neude' or '--name Mariastraat' in your console application.");
                    Console.WriteLine("\n");
                    Console.ResetColor();
                    break;

                case "-n":
                case "--name":
                    // Handle name argument
                    if (i + 1 < args.Length)
                    {
                        string name = args[i + 1];
                        int itemsFound = 0;
                        
                        var cameraCsvDataReader = new CameraCsvDataReader.CameraCsvDataReader();
                        var readResults = cameraCsvDataReader.ReadCsv(name);

                        Console.WriteLine("\n");
                        Console.WriteLine($"Name: {name}");

                        if (readResults.Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("We couldn't find a camera with that name.");
                            Console.ResetColor();
                            break;
                        }

                        Console.WriteLine($"Id | Name | Latitude | Longitude");

                        foreach (var items in readResults)
                        {
                            Console.WriteLine($"{items.Number} | {items.Name} | {items.Latitude} | {items.Longitude}");
                            itemsFound++;
                        }

                        Console.WriteLine($"\n{itemsFound} Item(s) found\n");
                        i++; 
                    }
                    else
                    {
                        Console.WriteLine("No value provided for name argument.");
                    }
                    break;

                default:
                    // Handle unrecognized argument
                    Console.WriteLine($"Unrecognized argument: {arg}");
                    break;
            }
        }


          
    }



}
