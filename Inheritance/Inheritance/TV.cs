using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class TV : ElectricalDevice
    {
        public TV(bool isOn, string brand) : base(isOn, brand)
        {
            IsOn = isOn;
            Brand = brand;
        }

        public void WatchTv()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching TV!");
            }
            else
            {
                Console.WriteLine("TV is switched off, switch it on first");
            }
        }
    }
}
