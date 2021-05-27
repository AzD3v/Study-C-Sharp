using System;

namespace MainArgsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("This is an app that uses args ;). Please provide arguments next time. Pass Help if you want more details.");
                Console.ReadKey();
                return; 
            }

            if (args[0] == "help")
            {
                Console.WriteLine("*********** Instructions:");
                Console.WriteLine("* use one of the following commands followed by 2 numbers");
                Console.WriteLine("* 'add' : to add 2 numbers");
                Console.WriteLine("* 'sub' : to subtract 2 numbers");
                Console.WriteLine("************************:");
            }

            if (args.Length != 3)
            {
                Console.WriteLine("Invalid arguments, please use the help command for instructions");
                Console.ReadKey();
                return;
            }

            bool isNum1Parsed = float.TryParse(args[1], out float num1);
            bool isNum2Parsed = float.TryParse(args[2], out float num2);

            if (!isNum1Parsed || !isNum2Parsed)
            {
                Console.WriteLine("Invalid arguments, please use the help command for instructions");
                Console.ReadKey();
                return;
            }

            float result;

            switch (args[0])
            {
                case "add":
                    result = num1 + num2;
                    Console.WriteLine($"The sum of {num1} and {num2} is {result}", num1, num2, result);
                    break;
                case "sub":
                    result = num1 - num2;
                    Console.WriteLine($"The sub of {num1} and {num2} is {result}", num1, num2, result);
                    break;
                default:
                    Console.WriteLine("Invalid arguments, use help for isntructriosn");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
