using System;

namespace AnonymousMethods
{
    class Program
    {
        public delegate string GetTextDelegate(string name);
        public delegate double GetResultDelegate(double a, double b);
        
        static void Main()
        {
            GetTextDelegate getTextDelegate = delegate (string name)
            {
                return "Hello " + name;
            };

            // Expression lambda 
            GetTextDelegate getHelloText = (string name) => { return "Hello, " + name; };

            // Statement lambda
            GetTextDelegate getGoodbyeText = (string name) => {
                Console.WriteLine("I'm inside of a statement lambda");
                return "Goodbye, " + name;
            };

            GetTextDelegate getWelcomeText = name => "Welcome, " + name;
            GetResultDelegate getSum = (a, b) => a + b;
            GetResultDelegate getProduct = (a, b) => a * b;

            DisplayNum(getSum);
            DisplayNum(getProduct);

            Console.WriteLine(getTextDelegate("Paulo"));
            Console.WriteLine(getWelcomeText("Paulo"));
            Display(getTextDelegate);
        }

        static void DisplayNum(GetResultDelegate getResultDelegate)
        {
            Console.WriteLine(getResultDelegate(3.5, 2.5));
        }

        static void Display(GetTextDelegate getTextDelegate)
        {
            Console.WriteLine(getTextDelegate("World"));
        }

        public static void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
