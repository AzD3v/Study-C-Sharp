using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Audi : Car
    {
        private string brand = "Audi Brand";
        public string Model { get; set; }

        public Audi(int hP, string color, string model) : base(hP, color)
        {
            Model = model;
        }

        public new void showDetails()
        {
            Console.WriteLine("{0} has {1} HP and it's color is {2}", brand, HP, Color);
        }

        public override void Repair()
        {
            Console.WriteLine("Car was repaired!");
        }
    }
}
