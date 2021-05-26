using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    // A bmw is a car
    class BMW : Car
    {
        private string brand = "BMW Brand";
        public string Model { get; set; }

        public BMW(int hP, string color, string model) : base(hP, color)
        {
            Model = model;
        }

        public new void showDetails()
        {
            Console.WriteLine("{0} has {1} HP and it's color is {2}", brand, HP, Color);
        }

        public override void Repair()
        {
            Console.WriteLine("{0} was repaired!", brand);
        }
    }
}
