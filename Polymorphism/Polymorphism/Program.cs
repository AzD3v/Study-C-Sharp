using System;
using System.Collections.Generic;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Audi(200, "blue", "A4"),
                new BMW(250, "red", "M3")
            };

            foreach (var car in cars)
            {
                car.Repair();
            }

            Car bmwz3 = new BMW(200, "black", "Z3");
            Car audiA3 = new Audi(100, "blue", "A3");

            bmwz3.showDetails();
            audiA3.showDetails();

            bmwz3.SetCarIDInfo(1234, "Person 1");
            audiA3.SetCarIDInfo(1231, "Person 2");

            bmwz3.GetCarIDInfo();
            audiA3.GetCarIDInfo();

            BMW bmwM5 = new BMW(330, "white", "m5");
            bmwM5.showDetails();

            Car carB = (Car)bmwM5;
            carB.showDetails();

            M3 myM3 = new M3(250, "grey", "M3 Turbo");
            myM3.Repair();

            Console.ReadKey();
        }
    }
}
