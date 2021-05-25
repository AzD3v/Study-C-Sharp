using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Radio myRadio = new Radio(false, "Sony");
            myRadio.SwitchOn();
            myRadio.ListenRadio();

            TV myTv = new TV(false, "Samsung");
            myTv.SwitchOn();
            myTv.WatchTv();
        }
    }
}
