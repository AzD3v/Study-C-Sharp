using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Car
    {
        public int HP { get; set; }
        public string Color { get; set; }

        // Has a relationship
        protected CarIDInfo carIDInfo = new CarIDInfo();

        public void SetCarIDInfo(int idNum, string owner)
        {
            carIDInfo.IDNum = idNum;
            carIDInfo.Owner = owner;
        }

        public void GetCarIDInfo()
        {
            Console.WriteLine("The car has the id of {0} and is owned by {1}", carIDInfo.IDNum, carIDInfo.Owner);
        }

        public Car(int hP, string color)
        {
            HP = hP;
            Color = color;
        }

        public void showDetails()
        {
            Console.WriteLine("This car has {0} HP and it's color is {1}", HP, Color);
        }

        public virtual void Repair()
        {
            Console.WriteLine("Car was repaired!");
        }
    }
}
