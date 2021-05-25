using System;

namespace Inheritance
{
    class Radio : ElectricalDevice
    {
        public Radio(bool isOn, string brand):base(isOn, brand)
        {
            IsOn = isOn;
            Brand = brand;
        }

        public void ListenRadio()
        {
            if (IsOn)
            {
                Console.WriteLine("Listening to the radio!");
            } 
            else
            {
                Console.WriteLine("Radio is switched off, switch it on first");
            }
        }
    }
}
