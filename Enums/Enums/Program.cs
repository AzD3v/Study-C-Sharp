using System;

namespace Enums
{
    enum Day { Mo, Tu, We, Th, Fr, Sa = 12, Su };

    class Program
    {
        static void Main(string[] args)
        {
            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;

            Console.WriteLine(fr == a);
            Console.WriteLine(Day.Mo);
            Console.WriteLine((int)Day.Mo);
            Console.WriteLine((int)Day.Su);

            Console.Read();
        }
    }
}
