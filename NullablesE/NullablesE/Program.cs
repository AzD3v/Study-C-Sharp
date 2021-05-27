using System;

namespace NullablesE
{
    class Program
    {
        static void Main(string[] args)
        {
            int? num1 = null;
            int? num2 = 1337;
            int num5;

            double? num3 = new Double?();
            double? num4 = 3.14564;

            bool? boolval = new bool?();

            Console.WriteLine("Out nullable numbers are: {0}, {1}, {2}, {3}", num1, num2, num3, num4);
            Console.WriteLine("The nullable boolean value is {0}", boolval);

            bool? isMale = null;

            if (isMale == true)
            {
                Console.WriteLine("User is male");
            } else if (isMale == false)
            {
                Console.WriteLine("User is female");
            } else
            {
                Console.WriteLine("No gender could be found");
            }

            double? num6 = 13.1;
            double? num7 = null;
            double num8;

            if (num6 == null)
            {
                num8 = 0.0;
            }
            else
            {
                num8 = (double)num6;
            }

            Console.WriteLine($"value of num8 is {num8}");

            // Shorter: the null coalescing operator
            num8 = num6 ?? 8.33;
            Console.WriteLine($"value of num8 is {num8}");
            num8 = num7 ?? 8.33;
            Console.WriteLine($"value of num8 is {num8}");

            Console.Read();
        }
    }
}
