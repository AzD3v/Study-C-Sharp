using System;

namespace singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Team.Instance.SayHello();
        }
    }
}
