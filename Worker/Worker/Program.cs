using System;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Doe", "John", 2000);

            employee1.Work();
            employee1.Pause();

            Boss boss1 = new Boss("Henrique", "Macedo", 1500, "Mercedes");
            Trainee trainee1 = new Trainee("Cunha", "Paulo", 700, 5, 5);

            boss1.Lead();
            trainee1.Work();

            Console.Read();
        }
    }
}
